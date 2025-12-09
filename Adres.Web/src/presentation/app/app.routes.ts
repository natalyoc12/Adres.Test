import { Routes } from '@angular/router';
import { ProcurementComponent } from './pages/procurement/procurement.component';

export const routes: Routes = [
  {
    path: '',
    component: ProcurementComponent,
    title: 'Procurement',
  },
  {
    path: 'details/:id',
    loadComponent: () =>
      import('./pages/procurement/details/details.component').then(
        (mod) => mod.DetailsComponent
      ),
  },
];
