import { Component, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Patient } from "../patient";
import { ActivatedRoute, Router } from "@angular/router";
import { IPatient } from "../ipatient";
import {catchError} from "rxjs/operators";

@Component({
  selector: 'patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent {
  private baseUrl : string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const id = params.get("id");

      this
        .http
        .get<IPatient>(this.baseUrl + `api/patients/${id}`)
        .subscribe(
          patient => this.patient = new Patient(patient),
          error => {
            console.error(error);
            throw error
          }
        )
    })
  }

  onSubmit(patient: Patient) {
    // TODO: Step 7
    // Extract patient id
    const id = patient.id;

    // Create JSON request body and indicate header will be in JSON format
    const body = JSON.stringify(patient);
    const headers = { 'content-type': 'application/json'}

    // Execute O̶r̶d̶e̶r̶ ̶6̶6̶ PUT request to update patient details
    // Return the updated patient and re-populate form
    return this
      .http
      .put<IPatient>(this.baseUrl + `api/patients/${id}`, body, {'headers':headers})
      .subscribe(
        updatedPatient => this.patient = new Patient(updatedPatient),
        error => {
          console.error(error);
          throw error
        }
      );
  }

  patient : Patient = {} as Patient;
}


//
// Implement the onSubmit() method.
//
// Send a request to the endpoint created in Step 3
// with the updated patient object.
//
// If the response is successful then the user
// should be navigated back to the list page.
//
// Feel free to use one of:
//  1) Angular HTTP Client (https://angular.io/guide/http)
//  2) Fetch API (https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API)
//  3) Any other suitable method
