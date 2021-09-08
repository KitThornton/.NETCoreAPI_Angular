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
    public class Tests
    {

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
        
        private List<Patient> GetTestPatients()
        {
            var patients = new List<Patient>();
            patients.Add(new Patient()
            {
                Id = 1,
                FirstName = "Bo",
                LastName = "Bob",
                Gender = "Male",
                NhsNumber = "0195344936",
                HospitalNumber = "63095840",
                DateOfBirth = new DateTime(1990, 06, 08),
                DateOfDeath = null,
                AddressLine1 = "673 Windsor Road", 
                AddressLine2 = "Plymouth",
                AddressLine3 = "Devon",
                PostCode = "PL56 8PJ"
            });
            
            return patients;
        }
    }
}