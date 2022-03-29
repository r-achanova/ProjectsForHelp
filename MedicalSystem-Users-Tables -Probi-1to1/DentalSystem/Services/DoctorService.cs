using DentalSystem.Abstractions;
using DentalSystem.Data;
using DentalSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalSystem.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _context;

        public DoctorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Doctor GetDoctorById(int doctorId)
        {
            return _context.Doctors.Find(doctorId);
        }

        public List<Doctor> GetDoctors()
        {
            List<Doctor> doctors = _context.Doctors.ToList();
            return doctors;
        }

        public List<Examination> GetExaminationsByDoctor(int doctorId)
        {
            throw new NotImplementedException();
        }

        public string GetFullName(int doctorId)
        {
            Doctor doctor = _context.Doctors.Find(doctorId);
            string fullName = doctor.FirstName + " " + doctor.LastName;
            return fullName;
        }

        public List<Hour> GetHoursByDoctor(int doctorId)
        {
            return _context.Hours
                .Where(d => d.DoctorId == doctorId)
                .ToList();
        }

        public bool RemoveById(int doctorId)
        {
            var item = _context.Doctors
                 .FirstOrDefault(c => c.Id == doctorId);
            if (item != null)
            {
                _context.Doctors
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
