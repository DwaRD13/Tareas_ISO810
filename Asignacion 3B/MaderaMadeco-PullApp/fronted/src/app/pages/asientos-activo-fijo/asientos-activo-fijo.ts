import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { AsientosActivoFijoService } from '../../services/asientos-activo-fijo.service';
import { CurrencyPipe, DatePipe, NgClass } from '@angular/common';

@Component({
  selector: 'app-asientos-activo-fijo',
  imports: [CurrencyPipe, DatePipe, NgClass],
  templateUrl: './asientos-activo-fijo.html',
  styleUrl: './asientos-activo-fijo.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AsientosActivoFijoComponent {
  movimientos = signal<any[]>([]);
  resumen = signal<any>({
    totalRegistros: 0,
    totalDebitos: 0,
    totalCreditos: 0,
    balanceado: true,
  });
  ultimoEncabezado = signal<any | null>(null);
  selectedFile: File | null = null;
  loading = signal(false);
  message = signal('');
  messageType = signal('');
  asientosService = inject(AsientosActivoFijoService);

  ngOnInit() {
    this.cargarMovimientos();
  }

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }

  subirArchivo() {
    if (!this.selectedFile) {
      this.showMessage('Por favor selecciona un archivo XML', 'error');
      return;
    }

    this.loading.set(true);
    this.asientosService.subirXml(this.selectedFile).subscribe({
      next: (response) => {
        this.ultimoEncabezado.set(response.encabezado);
        this.showMessage(
          `XML procesado: ${response.resumen.cantidadMovimientos} movimientos cargados`,
          'success',
        );
        this.cargarMovimientos();
        this.selectedFile = null;
        const fileInput = document.getElementById('fileInput') as HTMLInputElement;
        if (fileInput) fileInput.value = '';
        this.loading.set(false);
      },
      error: (error) => {
        this.showMessage(
          'Error al procesar el XML: ' + (error.error?.error || 'Error desconocido'),
          'error',
        );
        this.loading.set(false);
      },
    });
  }

  cargarMovimientos() {
    this.loading.set(true);
    this.asientosService.obtenerMovimientos().subscribe({
      next: (data) => {
        this.movimientos.set(data.movimientos || []);
        this.resumen.set(
          data.resumen || {
            totalRegistros: 0,
            totalDebitos: 0,
            totalCreditos: 0,
            balanceado: true,
          },
        );
        this.loading.set(false);
      },
      error: () => {
        this.showMessage('Error al cargar movimientos', 'error');
        this.loading.set(false);
      },
    });
  }

  limpiarRegistros() {
    if (confirm('¿Estás seguro de que deseas eliminar todos los registros?')) {
      this.loading.set(true);
      this.asientosService.limpiarRegistros().subscribe({
        next: () => {
          this.showMessage('Todos los registros han sido eliminados', 'success');
          this.cargarMovimientos();
          this.loading.set(false);
        },
        error: () => {
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
}
