using DentalSystem.Abstractions;
using DentalSystem.Data;
using DentalSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalSystem.Services
{
    public class HourService : IHourService
    {
        private readonly ApplicationDbContext _context;

        public HourService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateHour(DateTime freeHour, int doctorId)
        {
            var hour = new Hour
            {
                FreeHour=freeHour,
                DoctorId=doctorId,
                                
            };
            
            _context.Hours.Add(hour);
          return  _context.SaveChanges()!=0;
             
        }

        public List<Hour> GetFreeHours()
        {
            List<Hour> hours = _context.Hours
                .Where(c=>c.IsBusy==false)
                .ToList();
            return hours;
        }

        public Hour GetHourById(int hourId)
        {
            return _context.Hours.Find(hourId);
        }

        public List<Hour> GetHours()
        {
            List<Hour> hours = _context.Hours
                .ToList();
            return hours;
        }

        public List<Reservation> GetReservationsByHour(int hourId)
        {
            return _context.Reservations
                .Where(r => r.HourId == hourId)
                .ToList();
        }

        public bool RemoveById(int hourId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateHour(int hourId, DateTime freeHour, int doctorId)
        {
            var hour = GetHourById(hourId);
            if (hour == default(Hour))
            {
                return false;
            }
            hour.FreeHour = freeHour;
            hour.DoctorId = doctorId;
            hour.Doctor = _context.Doctors.Find(doctorId);
            

            _context.Update(hour);
            return _context.SaveChanges() != 0; 
        }
    }
}
