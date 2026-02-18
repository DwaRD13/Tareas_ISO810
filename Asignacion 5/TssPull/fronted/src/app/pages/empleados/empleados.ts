import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { EmpleadosService } from '../../services/empleados.service';
import { CurrencyPipe, DatePipe, NgClass } from '@angular/common';

@Component({
  selector: 'app-empleados',
  imports: [CurrencyPipe, DatePipe, NgClass],
  templateUrl: './empleados.html',
  styleUrl: './empleados.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EmpleadosComponent {
  empleados = signal<any[]>([]);
  loading = signal(false);
  message = signal('');
  messageType = signal('');
  empleadosService = inject(EmpleadosService);

  ngOnInit() {
    this.cargarEmpleados();
  }

  cargarEmpleados() {
    this.loading.set(true);
    this.empleadosService.obtenerEmpleados().subscribe({
      next: (data) => {
        this.empleados.set(data);
        this.loading.set(false);
      },
      error: () => {
        this.showMessage('Error al cargar empleados', 'error');
        this.loading.set(false);
      },
    });
  }

  cargarDesdeFerrAme() {
    this.loading.set(true);
    this.empleadosService.cargarDesdeFerrAme().subscribe({
      next: (response) => {
        this.showMessage(response.message, 'success');
        this.cargarEmpleados();
      },
      error: (error) => {
        this.showMessage(
          'Error al conectar con FerrAmeManager: ' + (error.error?.error || 'Error desconocido'),
          'error',
        );
        this.loading.set(false);
      },
    });
  }

  showMessage(message: string, type: string) {
    this.message.set(message);
    this.messageType.set(type);
    setTimeout(() => this.message.set(''), 5000);
  }

  calcularTotalSueldos(): number {
    return this.empleados().reduce((sum, emp) => sum + (parseFloat(emp.sueldo) || 0), 0);
  }

  calcularTotalDescuentos(): number {
    return this.empleados().reduce((sum, emp) => sum + (parseFloat(emp.descuento_seguro) || 0), 0);
  }

  calcularTotalNeto(): number {
    return this.empleados().reduce((sum, emp) => sum + (parseFloat(emp.sueldo_neto) || 0), 0);
  }
}
