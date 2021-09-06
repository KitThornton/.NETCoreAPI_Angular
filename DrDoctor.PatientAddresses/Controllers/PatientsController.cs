using System;
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
            //
            // Implement an endpoint that returns the full list of Patients
            // from the PatientRepository.
            //
            // If there are no Patients returned from the PatientRepository
            // then an empty list should be returned.

            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // TODO: Step 2
            //
            // Implement an endpoint that returns a single Patient from the
            // PatientRepository based on the given id parameter.
            //
            // If null is returned from the PatientRepository for the supplied
            // id, then a 404 NotFound should be returned.

            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Patient patient)
        {
            // TODO: Step 3
            //
            // Implement an endpoint that receives an updated Patient object
            // and updates a Patient for the given the id parameter.
            //
            // If the Patient has been successfully updated, the updated
            // Patient should be returned from the endpoint.
            //
            // If null is returned from the PatientRepository then a
            // 404 NotFound should be returned.

            throw new NotImplementedException();
        }
    }
}
