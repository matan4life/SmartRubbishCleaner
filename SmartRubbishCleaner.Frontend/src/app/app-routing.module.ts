import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { MainComponent } from './main/main.component';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';
import { PersonalComponent } from './personal/personal.component';
import { DevicesComponent } from './devices/devices.component';
import { CansComponent } from './cans/cans.component';
import { AddComponent } from './devices/add/add.component';
import { Add1Component } from './cans/add/add.component';
import { CleaningsComponent } from './cleanings/cleanings.component';
import { AdmusersComponent } from './administrate/admusers/admusers.component';
import { AdmsubsComponent } from './administrate/admsubs/admsubs.component';
import { AdmfactoriesComponent } from './administrate/admfactories/admfactories.component';
import { AdmdevicesComponent } from './administrate/admdevices/admdevices.component';
import { AdmsubseditComponent } from './administrate/admsubs/admsubsedit/admsubsedit.component';
import { AdmsubsaddComponent } from './administrate/admsubs/admsubsadd/admsubsadd.component';
import { AdmfactoriesaddComponent } from './administrate/admfactories/admfactoriesadd/admfactoriesadd.component';
import { AdmfactorieseditComponent } from './administrate/admfactories/admfactoriesedit/admfactoriesedit.component';
import { AdmdevicesaddComponent } from './administrate/admdevices/admdevicesadd/admdevicesadd.component';
import { AdmdeviceseditComponent } from './administrate/admdevices/admdevicesedit/admdevicesedit.component';

const routes: Routes = [
  { path: '', redirectTo: '/main', pathMatch: 'full' },
  { path: 'register', component: RegisterComponent },
  { path: 'main', component: MainComponent },
  { path: 'login', component: LoginComponent },
  { path: 'logout', component: LogoutComponent },
  { path: 'personal', component: PersonalComponent },
  { path: 'devices', component: DevicesComponent },
  { path: 'cans', component: CansComponent },
  { path: 'devices/add', component: AddComponent },
  { path: 'cans/add', component: Add1Component },
  { path: 'cleanings', component: CleaningsComponent },
  { path: 'administrate/users', component: AdmusersComponent },
  { path: 'administrate/subs', component: AdmsubsComponent },
  { path: 'administrate/factories', component: AdmfactoriesComponent },
  { path: 'administrate/devices', component: AdmdevicesComponent },
  { path: 'administrate/subs/edit', component: AdmsubseditComponent },
  { path: 'administrate/subs/add', component: AdmsubsaddComponent },
  { path: 'administrate/factories/add', component: AdmfactoriesaddComponent },
  { path: 'administrate/factories/edit', component: AdmfactorieseditComponent },
  { path: 'administrate/devices/add', component: AdmdevicesaddComponent },
  { path: 'administrate/devices/edit', component: AdmdeviceseditComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
