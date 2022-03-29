using DentalSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalSystem.Abstractions
{
  public  interface IDoctorService
    {
        
        List<Doctor> GetDoctors();
        Doctor GetDoctorById(int doctorId);
        List<Hour> GetHoursByDoctor(int doctorId);
        List<Examination> GetExaminationsByDoctor(int doctorId);
        public bool RemoveById(int doctorId);
        string GetFullName(int doctorId);
    }
}
