using DentalSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalSystem.Abstractions
{
    public interface IPatientService
    {
       bool CreatePacient(string firstName, string lastName, string egn, string phone, DateTime birthDay,string userId);
        
        List<Patient> GetPatients();
        Patient GetPatientByUserId(string userId);
        Patient GetPatientById(int patientId);
        List<Reservation> GetReservationsByPatient(int patientId);
        List<Examination> GetExaminationsByPatient(int patientId);
        public bool RemoveById(int patientId);
        
       
        
    }
}
