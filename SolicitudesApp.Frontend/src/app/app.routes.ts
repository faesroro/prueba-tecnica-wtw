import { Routes } from '@angular/router';
import { ListaSolicitudesComponent } from './features/solicitudes/lista-solicitudes/lista-solicitudes.component';
import { CrearSolicitudComponent } from './features/solicitudes/crear-solicitud/crear-solicitud.component';

export const routes: Routes = [
  { path: '', redirectTo: 'solicitudes', pathMatch: 'full' },
  { path: 'solicitudes', component: ListaSolicitudesComponent },
  { path: 'solicitudes/nueva', component: CrearSolicitudComponent }
];