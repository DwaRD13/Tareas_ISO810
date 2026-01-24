import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { EmpleadosService } from '../../services/empleados.service';
import { CurrencyPipe, DecimalPipe, NgClass } from '@angular/common';

@Component({
  selector: 'app-empleados',
  imports: [CurrencyPipe, NgClass],
  templateUrl: './empleados.html',
  styleUrl: './empleados.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EmpleadosComponent {
  empleados = signal<any[]>([]);
  selectedFile: File | null = null;
  loading = signal(false);
  message = signal('');
  messageType = signal('');
  empleadosService = inject(EmpleadosService);

  ngOnInit() {
    this.cargarEmpleados();
  }

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }

  subirArchivo() {
    if (!this.selectedFile) {
      this.showMessage('Por favor selecciona un archivo TXT', 'error');
      return;
    }

    this.loading.set(true);
    this.empleadosService.subirArchivo(this.selectedFile).subscribe({
      next: (response) => {
        this.showMessage(`Archivo procesado: ${response.registros} empleados cargados`, 'success');
        this.cargarEmpleados();
        this.selectedFile = null;
        // Limpiar input file
        const fileInput = document.getElementById('fileInput') as HTMLInputElement;
        if (fileInput) fileInput.value = '';
        this.loading.set(false);
      },
      error: (error) => {
        this.showMessage(
          'Error al procesar el archivo: ' + (error.error?.error || 'Error desconocido'),
          'error',
        );
        this.loading.set(false);
      },
    });
  }

  cargarEmpleados() {
    this.loading.set(true);
    this.empleadosService.obtenerEmpleados().subscribe({
      next: (data) => {
        this.empleados.set(data);
        this.loading.set(false);
      },
      error: (error) => {
        this.showMessage('Error al cargar empleados', 'error');
        this.loading.set(false);
      },
    });
  }

  generarArchivo() {
    this.loading.set(true);
    this.empleadosService.generarArchivo().subscribe({
      next: (blob) => {
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = `empleados_procesados_${Date.now()}.txt`;
        a.click();
        window.URL.revokeObjectURL(url);
        this.showMessage('Archivo generado exitosamente', 'success');
        this.loading.set(false);
      },
      error: (error) => {
        this.showMessage('Error al generar archivo', 'error');
        this.loading.set(false);
      },
    });
  }

  limpiarRegistros() {
    if (confirm('¿Estás seguro de que deseas eliminar todos los registros?')) {
      this.loading.set(true);
      this.empleadosService.limpiarRegistros().subscribe({
        next: (response) => {
          this.showMessage('Todos los registros han sido eliminados', 'success');
          this.cargarEmpleados();
          this.loading.set(false);
        },
        error: (error) => {
          this.showMessage('Error al limpiar registros', 'error');
          this.loading.set(false);
        },
      });
    }
  }

  showMessage(message: string, type: string) {
    this.message.set(message);
    this.messageType.set(type);
    setTimeout(() => {
      this.message.set('');
    }, 5000);
  }

  calcularTotalSueldos(): number {
    return this.empleados().reduce((sum, emp) => {
      const val = typeof emp.sueldo === 'number' ? emp.sueldo : parseFloat(emp.sueldo) || 0;
      return sum + val;
    }, 0);
  }

  calcularTotalDescuentos(): number {
    return this.empleados().reduce((sum, emp) => {
      const val = typeof emp.descuento_seguro === 'number' ? emp.descuento_seguro : parseFloat(emp.descuento_seguro) || 0;
      return sum + val;
    }, 0);
  }

  calcularTotalNeto(): number {
    return this.empleados().reduce((sum, emp) => {
      const val = typeof emp.sueldo_neto === 'number' ? emp.sueldo_neto : parseFloat(emp.sueldo_neto) || 0;
      return sum + val;
    }, 0);
  }
}
