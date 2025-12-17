import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ReservationComponent} from './reservation/reservation.component';
import {ProfilePageComponent} from './profile-page/profile-page.component';
import {SettingsComponent} from './settings/settings.component';
import {ReservationsComponent} from './reservations/reservations.component';
import { ClientMenusComponent } from './menus/menus.component';

const routes: Routes = [
  {path: 'reservation', component: ReservationComponent},
  {path: 'profile', component: ProfilePageComponent},
  {path: 'settings', component: SettingsComponent},
  {path: 'reservations', component: ReservationsComponent},
  {path: 'menus', component: ClientMenusComponent},
  {path: '', redirectTo: 'profile', pathMatch: 'full'}, // Default route
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientRoutingModule {
}
