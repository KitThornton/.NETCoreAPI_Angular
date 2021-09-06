import { Component, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Patient } from "../patient";
import { ActivatedRoute, Router } from "@angular/router";
import { IPatient } from "../ipatient";

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
        .subscribe(patient => this.patient = new Patient(patient));
    });
  }

  onSubmit(patient: Patient) {
    // TODO: Step 7
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

    throw new Error("Not Implemented!");
  }

  patient : Patient = {} as Patient;
}
