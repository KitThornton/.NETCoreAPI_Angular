import { Component, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Patient } from "../patient";
import { IPatient } from "../ipatient";

@Component({
  selector: 'patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css']
})
export class PatientListComponent {
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http
      .get<IPatient[]>(baseUrl + 'api/patients')
      .subscribe(patients => this.patients = patients.map(x => new Patient(x)));
  }

  public patients : Patient[];
}
