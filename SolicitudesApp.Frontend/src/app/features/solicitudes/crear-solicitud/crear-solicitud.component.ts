import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SolicitudService } from '../../../core/services/solicitud.service';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-crear-solicitud',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './crear-solicitud.component.html',
  styleUrls: ['./crear-solicitud.component.scss']
})
export class CrearSolicitudComponent {
  tipo: string = '';
  estado: number | null = null;
  datosDinamicos: any = {};
  campos: { nombre: string, valor: any }[] = [];
  mensaje = '';
  mensajeError = '';

  constructor(private solicitudService: SolicitudService, private router: Router) {}

  agregarCampo() {
    this.campos.push({ nombre: '', valor: '' });
  }

  eliminarCampo(index: number) {
    this.campos.splice(index, 1);
  }

  enviarSolicitud() {
    this.mensaje = '';
    this.mensajeError = '';

    // Validación básica
    if (!this.tipo.trim() || !this.estado === null) {
      this.mensajeError = 'Por favor completa los campos "Tipo" y "Estado".';
      return;
    }

    // Validar que los campos dinámicos tengan nombre
    const datos = this.campos.reduce((acc, campo) => {
      if (campo.nombre.trim()) {
        acc[campo.nombre] = campo.valor;
      }
      return acc;
    }, {} as any);

    const payload = {
      tipo: this.tipo,
      estado: this.estado,
      datos
    };

    this.solicitudService.create(payload).subscribe({
      next: () => {
       // this.mensaje = '✅ Solicitud creada exitosamente.';
       // this.tipo = '';
       // this.estado = '';
       // this.campos = [];
       this.router.navigate(['/solicitudes'],
        { 
          state: {mensaje: 'Solicitud creada exitosamente.'},
        });
      },
      error: (err) => {
        console.error('Error al crear solicitud:', err);
        this.mensajeError = '❌ Ocurrió un error al crear la solicitud.';
      }
    });
  }
}
