import { ChangeDetectionStrategy, Component, inject, signal, OnInit } from '@angular/core';
import { EmpleadosService } from '../../services/empleados.service';
import { CurrencyPipe, DatePipe, NgClass } from '@angular/common';

@Component({
  selector: 'app-empleados',
  imports: [CurrencyPipe, DatePipe, NgClass],
  templateUrl: './empleados.html',
  styleUrl: './empleados.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EmpleadosComponent implements OnInit {
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
        // 1. Calculamos los descuentos al recibir la data
        const empleadosProcesados = data.map((emp: any) => {
          const sueldoBruto = parseFloat(emp.sueldo) || 0;
          
          const descuento_seguro = sueldoBruto * 0.0304; // SFS: 3.04%
          const descuento_afp = sueldoBruto * 0.0287;    // AFP: 2.87%
          const sueldo_neto = sueldoBruto - descuento_seguro - descuento_afp;

          return {
            ...emp,
            descuento_seguro,
            descuento_afp,
            sueldo_neto
          };
        });

        this.empleados.set(empleadosProcesados);
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
      next: (response: any) => {
        this.showMessage(response.message, 'success');
        this.cargarEmpleados(); 
      },
      error: (error) => {
        this.empleados.set([]); 
        
        this.showMessage(
          error.error?.error || 'Error desconocido al conectar con FerrAmeManager',
          'error'
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
    // 2. Sumamos ambos descuentos en el total
    return this.empleados().reduce((sum, emp) => {
      const seguro = parseFloat(emp.descuento_seguro) || 0;
      const afp = parseFloat(emp.descuento_afp) || 0;
      return sum + seguro + afp;
    }, 0);
  }

  calcularTotalNeto(): number {
    return this.empleados().reduce((sum, emp) => sum + (parseFloat(emp.sueldo_neto) || 0), 0);
  }
}