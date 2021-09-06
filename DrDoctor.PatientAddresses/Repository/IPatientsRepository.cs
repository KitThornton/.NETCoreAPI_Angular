using System.Collections.Generic;
using DrDoctor.PatientAddresses.Entities;

namespace DrDoctor.PatientAddresses.Repository
{
    public interface IPatientsRepository
    {
        IEnumerable<Patient> GetAll();

        Patient Get(int id);

        Patient Update(Patient patient);
    }
}
