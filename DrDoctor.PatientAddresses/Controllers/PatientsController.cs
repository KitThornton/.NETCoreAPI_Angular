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
            // Empty list will be returned even with 0 patients in repo
            IEnumerable<Patient> patients = _patientRepository.GetAll();
            
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
            if ( ReferenceEquals(null, patientReturn) )
            {
                return NotFound();
            }
            
            // Return updated patient
            return Ok(patientReturn);
        }
    }
}