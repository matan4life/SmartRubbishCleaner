import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { CookieService } from 'ngx-cookie-service';
import { ApplicationService } from './application.service';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { RegisterComponent } from './register/register.component';
import { FormsModule } from '@angular/forms';
import { MainComponent } from './main/main.component';
import { RegisterService } from './register.service';
import { HeaderService } from './header.service';
import { HeadListenerService } from './head-listener.service';
import { PersonalComponent } from './personal/personal.component';
import { LogoutComponent } from './logout/logout.component';
import { LoginComponent } from './login/login.component';
import { DevicesComponent } from './devices/devices.component';
import { CansComponent } from './cans/cans.component';
import { AgmCoreModule } from '@agm/core';
import { AddComponent } from './devices/add/add.component'
import { Add1Component} from './cans/add/add.component'

import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { CleaningsComponent } from './cleanings/cleanings.component';
import { AdmusersComponent } from './administrate/admusers/admusers.component';
import { AdmdevicesComponent } from './administrate/admdevices/admdevices.component';
import { AdmfactoriesComponent } from './administrate/admfactories/admfactories.component';
import { AdmsubsComponent } from './administrate/admsubs/admsubs.component';
import { AdmsubseditComponent } from './administrate/admsubs/admsubsedit/admsubsedit.component';
import { AdmsubsaddComponent } from './administrate/admsubs/admsubsadd/admsubsadd.component';
import { AdmfactorieseditComponent } from './administrate/admfactories/admfactoriesedit/admfactoriesedit.component';
import { AdmfactoriesaddComponent } from './administrate/admfactories/admfactoriesadd/admfactoriesadd.component';
import { AdmdevicesaddComponent } from './administrate/admdevices/admdevicesadd/admdevicesadd.component';
import { AdmdeviceseditComponent } from './administrate/admdevices/admdevicesedit/admdevicesedit.component';

export function HttpLoaderFactory(http: HttpClient) {

  return new TranslateHttpLoader(http);

}

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    RegisterComponent,
    MainComponent,
    PersonalComponent,
    LogoutComponent,
    LoginComponent,
    DevicesComponent,
    CansComponent,
    AddComponent,
    Add1Component,
    CleaningsComponent,
    AdmusersComponent,
    AdmdevicesComponent,
    AdmfactoriesComponent,
    AdmsubsComponent,
    AdmsubseditComponent,
    AdmsubsaddComponent,
    AdmfactorieseditComponent,
    AdmfactoriesaddComponent,
    AdmdevicesaddComponent,
    AdmdeviceseditComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    AgmCoreModule.forRoot({
      apiKey: "AIzaSyBeFEC_8v3061wgyMUEO6mJ8EmAXzWedTk"
    }),
    TranslateModule.forRoot({

      loader: {

        provide: TranslateLoader,

        useFactory: HttpLoaderFactory,

        deps: [HttpClient]

      }

    })
  ],
  providers: [CookieService, ApplicationService, RegisterService, HeaderService, HeadListenerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
