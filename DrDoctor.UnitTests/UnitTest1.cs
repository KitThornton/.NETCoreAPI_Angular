using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using DrDoctor.PatientAddresses.Controllers;
using DrDoctor.PatientAddresses.Entities;
using DrDoctor.PatientAddresses.Repository;
using Microsoft.AspNetCore.Mvc;
using NUnit.Mocks;
using Moq;

namespace DrDoctor.UnitTests
{
    // These unit tests concern the controller, PatientsController 
    public class Tests
    {

        // Test #1: Ensure that the Get call from the controller returns all
        // hardcoded entries in the repository
        [Test] public void Get_WithPatientsInRepo_ReturnsAll()
        {
            // arrange
            IPatientsRepository repo = new PatientsRepository();
            var controller = new PatientsController(repo);
            
            // act
            var result = controller.Get();
            var okResult = result as OkObjectResult;
            List<Patient> listPatients = (List<Patient>) okResult.Value;
            
            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual( 6, listPatients.Count);
        }
        
        // Test #2: Ensure that Get for individual patient returns the correct 
        // details.
        [Test]
        public void Get_WithPatientsInRepo_ReturnById()
        {
            // arrange
            IPatientsRepository repo = new PatientsRepository();
            var controller = new PatientsController(repo);
            var id = 1;

            // act
            var result = controller.Get(id);
            var okResult = result as OkObjectResult;
            var patient = (Patient) okResult.Value;
            
            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual( 1, patient.Id);
            Assert.AreEqual( 63095840, int.Parse(patient.HospitalNumber));
        }
        
        // Test #3: Ensure that the Put call accepts the updated patient, processes accordingly
        // and then returns the updated patient that will be displayed on UI
        [Test]
        public void Put_WithPatientsInRepo_ById()
        {
            // arrange
            IPatientsRepository repo = new PatientsRepository();
            var controller = new PatientsController(repo);
            var id = 1;
            var patient = PopulateTestPatient(id);

            // act
            var result = controller.Put(id, patient);
            var okResult = result as OkObjectResult;
            var returnedPatient = (Patient) okResult.Value;
            
            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual( "Bob", returnedPatient.FirstName);
            // Assert.AreEqual( 1890, returnedPatient.DateOfBirth. );
        }
        
        // Test #4: 
        [Test]
        public void Put_WithIncorrectPatient_ById()
        {
            // Arrange
            IPatientsRepository repo = new PatientsRepository();
            var controller = new PatientsController(repo);
            var id = 145;
            var patient = new Patient();
            
            // Act
            var result = controller.Put(id, patient);
            var okResult = result as OkObjectResult;

            // Assert. Abort test if there is an OkResult
            Assert.IsNull(okResult);
            
            // Cast to NotFoundResult and assert that 404 code is returned
            var notFoundResult = ((NotFoundResult) result);
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
            
            
            
            // 
            // var returnedPatient = (Patient) okResult.Value;
            // if (returnedPatient == null)
            // {
            //     Assert.Fail();
            // }
        }
        
        private Patient PopulateTestPatient(int id)
        {
            // Different FirstName and DOB to repository patient of ID [argument].
            return new Patient
            {
                Id = id,
                FirstName = "Bob",
                LastName = "Bob",
                Gender = "Male",
                NhsNumber = "0195344936",
                HospitalNumber = "63095840",
                DateOfBirth = new DateTime(1890, 06, 08),
                DateOfDeath = null,
                AddressLine1 = "673 Windsor Road",
                AddressLine2 = "Plymouth",
                AddressLine3 = "Devon",
                PostCode = "PL56 8PJ"
            };
        }
    }
}