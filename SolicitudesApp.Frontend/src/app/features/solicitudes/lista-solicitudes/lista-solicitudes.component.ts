import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SolicitudService, Solicitud } from '../../../core/services/solicitud.service';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

declare var bootstrap: any;

@Component({
  standalone: true,
  selector: 'app-lista-solicitudes',
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './lista-solicitudes.component.html',
  styleUrls: ['./lista-solicitudes.component.scss']
})
export class ListaSolicitudesComponent implements OnInit {
  mensaje = '';
  solicitudService = inject(SolicitudService);
  solicitudes: Solicitud[] = [];

  filtroTipo: string = '';
  filtroEstado: number | '' = '';
  filtroFecha: string = '';

  estados = [
    { valor: '', nombre: 'Todos' },
    { valor: 0, nombre: 'Pendiente' },
    { valor: 1, nombre: 'Aprobado' },
    { valor: 2, nombre: 'Rechazado' }
  ];

  idSolicitudAEliminar: string | null = null; // ✅ ahora string

  constructor(private router: Router) {}

  ngOnInit(): void {
    // Mostrar mensaje si viene del router state
    const state = history.state as { mensaje?: string };

    if (state?.mensaje) {
      this.mensaje = state.mensaje;

      setTimeout(() => {
        this.mensaje = '';
      }, 3000);
    }

    // Cargar todas las solicitudes
    this.solicitudService.getAll().subscribe({
      next: (data) => this.solicitudes = data,
      error: (err) => console.error('Error al cargar solicitudes:', err)
    });
  }

  aplicarFiltros() {
    const fechaFormateada = this.filtroFecha
      ? new Date(this.filtroFecha).toISOString().split('T')[0]
      : '';

    this.solicitudService.getByFilters(
      this.filtroTipo,
      typeof this.filtroEstado === 'number' ? this.filtroEstado : undefined,
      fechaFormateada
    ).subscribe({
      next: (data) => this.solicitudes = data,
      error: (err) => console.error('Error al aplicar filtros:', err)
    });
  }

  abrirModal(id: string): void {
    this.idSolicitudAEliminar = id;
    const modal = new bootstrap.Modal(document.getElementById('confirmarEliminarModal')!);
    modal.show();
  }

  confirmarEliminacion(): void {
    if (!this.idSolicitudAEliminar) return;

    this.solicitudService.delete(this.idSolicitudAEliminar).subscribe({
      next: () => {
        this.solicitudes = this.solicitudes.filter(s => s.id !== this.idSolicitudAEliminar);
        this.mensaje = '✅ Solicitud eliminada exitosamente.';
        setTimeout(() => this.mensaje = '', 3000);

        // Ocultar el modal manualmente
        const modal = bootstrap.Modal.getInstance(document.getElementById('confirmarEliminarModal')!);
        modal?.hide();

        this.idSolicitudAEliminar = null;
      },
      error: (err) => {
        console.error('Error al eliminar solicitud:', err);
        this.mensaje = '❌ Ocurrió un error al eliminar la solicitud.';
        setTimeout(() => this.mensaje = '', 3000);
      }
    });
  }
}
