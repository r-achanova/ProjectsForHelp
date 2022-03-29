using DentalSystem.Abstractions;
using DentalSystem.Data;
using DentalSystem.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalSystem.Services
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PatientService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public bool CreatePacient(string firstName, string lastName, string egn, string phone, DateTime birthDay, string userId)
        {
            if (_context.Patients.Any(p => p.UserId == userId))
            {
                throw new InvalidOperationException("Patient with the same EGN already exist.");
            }
            var patient = new Patient
            {
                FirstName=firstName,
                LastName=lastName,
                EGN=egn,
                Phone=phone,
               BirthDay=birthDay,
               UserId=userId,
            };
            
            _context.Patients.Add(patient);
           return _context.SaveChanges()!=0;
        }

        public List<Examination> GetExaminationsByPatient(int patientId)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientById(int patientId)
        {
            return _context.Patients.Find(patientId);
        }

        public Patient GetPatientByUserId(string userId)
        {
            return _context.Patients.FirstOrDefault(p => p.UserId == userId);
        }

        public List<Patient> GetPatients()
        {
            List<Patient> patients = _context.Patients
                .ToList();
            return patients;
        }

        public List<Reservation> GetReservationsByPatient(int patientId)
        {
            return _context.Reservations
                .Where(r => r.PatientId == patientId)
                .ToList();
        }

                public bool RemoveById(int patientId)
        {
            var item = _context.Patients
                  .FirstOrDefault(p => p.Id == patientId);
            if (item != null)
            {
                _context.Patients
                    .Remove(item);
                return _context.SaveChanges() != 0;

            }
            else
            {
                //I'm deleting non-existent ID
                return false;
            }
        }

        
    }
}
