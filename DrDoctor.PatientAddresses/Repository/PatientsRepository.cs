using System;
using System.Collections.Generic;
using System.Linq;
using DrDoctor.PatientAddresses.Entities;

namespace DrDoctor.PatientAddresses.Repository
{
    public class PatientsRepository : IPatientsRepository
    {
        public IEnumerable<Patient> GetAll()
        {
            return this.Collection;
        }

        public Patient Get(int id)
        {
            var patient = this.Collection.SingleOrDefault(p => p.Id == id);

            return patient;
        }

        public Patient Update(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException();
            }

            var existing = this.Collection.SingleOrDefault(p => p.Id == patient.Id);

            if (existing != null)
            {
                this.Collection = this.Collection.Except(new List<Patient> { existing }).ToList();

                this.Collection.Add(patient);

                existing = patient;
            }

            return existing;
        }

        #region In Memory Collection

        public PatientsRepository()
        {
            this.Collection = InMemoryCollection;
        }

        private IList<Patient> Collection { get; set; }

        private static IList<Patient> InMemoryCollection { get; } = new List<Patient>
        {
            new Patient
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
            },
            new Patient
            {
                Id = 2,
                FirstName = "Brian",
                LastName = "Allen",
                Gender = "Male",
                NhsNumber = "9411534872",
                HospitalNumber = "40111848",
                DateOfBirth = new DateTime(1967, 03, 28),
                DateOfDeath = null,
                AddressLine1 = "47 Church Street",
                AddressLine2 = "Chester", 
                PostCode = "CH99 6UZ"
            },
            new Patient
            {
                Id = 3,
                FirstName = "Courtney",
                LastName = "Arnold",
                Gender = "Female",
                NhsNumber = "4709265615",
                HospitalNumber = "07277352",
                DateOfBirth = new DateTime(1944, 01, 22),
                DateOfDeath = null,
                AddressLine1 = "     15 West Street",
                AddressLine3 = "Milton Keynes",
                PostCode = "MK55 7JE"
            },
            new Patient
            {
                Id = 4,
                FirstName = "Gabriel",
                LastName = "Francis",
                Gender = "Unknown",
                NhsNumber = "6254268000",
                HospitalNumber = "14325132",
                DateOfBirth = new DateTime(1997, 09, 03),
                DateOfDeath = null,
                AddressLine2 = "35 Queens Road",
                AddressLine3 = "Darlington",
                PostCode = "DL43 3JZ"
            },
            new Patient
            {
                Id = 5,
                FirstName = "George",
                LastName = "Edwards",
                Gender = "Male",
                NhsNumber = "9086077900",
                HospitalNumber = "59672534",
                DateOfBirth = new DateTime(1929, 11, 11),
                DateOfDeath = new DateTime(2020, 03, 07),
                AddressLine1 = "60 St. John’s Road",
                AddressLine2 = "  Stevenage",
                AddressLine4 = "",
                PostCode = "SG59 0TH"
            },
            new Patient
            {
                Id = 6,
                FirstName = "Imogen",
                LastName = "Kent",
                Gender = "Female",
                NhsNumber = "3112926641",
                HospitalNumber = "42360407",
                DateOfBirth = new DateTime(1986, 09, 07),
                DateOfDeath = null,
                AddressLine1 = "90 Main Street",
                AddressLine2 = "Ilford         ",
                PostCode = "IG4 8QI"
            }
        };

        #endregion
    }
}
