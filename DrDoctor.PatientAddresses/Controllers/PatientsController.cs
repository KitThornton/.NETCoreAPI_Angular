using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using DrDoctor.PatientAddresses.Entities;
using DrDoctor.PatientAddresses.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DrDoctor.PatientAddresses.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsRepository _patientRepository;

        public PatientsController(IPatientsRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            // TODO: Step 1
            // Access PatientRepository and return all entries
            var patients = _patientRepository.GetAll();
            
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // TODO: Step 2
            // Access PatientRepository to return patient through patient Id
            var patient = _patientRepository.Get(id);

            // If patient is null, no patient exists for the supplied Id
            // return 404 NotFound error
            if (ReferenceEquals(null, patient ))
            {
                return NotFound();
            }
            
            // return OkObjectResult with (200 OK) and patient object
            return Ok(patient);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Patient patient)
        {
            // TODO: Step 3
            // Access patient repo and update if a patient matches supplied Id 
            var patientReturn = _patientRepository.Update(patient);
            
            // Return NotFound 404 error if supplied patient does not match entry in repo
            if ( patientReturn == null )
            {
                return NotFound();
            }
            
            // Return updated patient
            return Ok(patientReturn);
        }
    }
}

//
// Implement an endpoint that returns the full list of Patients
// from the PatientRepository.
//
// If there are no Patients returned from the PatientRepository
// then an empty list should be returned.

// Initialise variable and return all patients from PatientRepository
// IEnumerable<Patient> patients = new List<Patient>();

//
// Implement an endpoint that returns a single Patient from the
// PatientRepository based on the given id parameter.
//
// If null is returned from the PatientRepository for the supplied
// id, then a 404 NotFound should be returned.

//
// Implement an endpoint that receives an updated Patient object
// and updates a Patient for the given the id parameter.
//
// If the Patient has been successfully updated, the updated
// Patient should be returned from the endpoint.
//
// If null is returned from the PatientRepository then a
// 404 NotFound should be returned.
            
// Awaiting functionality that will be written in Step 7
// Return 404 error if the patient is null, otherwise update details