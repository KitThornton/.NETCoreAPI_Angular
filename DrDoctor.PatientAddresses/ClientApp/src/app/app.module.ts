import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { PatientListComponent } from "./patients/patient-list/patient-list.component";
import { PatientComponent } from "./patients/patient/patient.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    PatientListComponent,
    PatientComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: PatientListComponent, pathMatch: 'full' },
      { path: 'patient/:id', component: PatientComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
