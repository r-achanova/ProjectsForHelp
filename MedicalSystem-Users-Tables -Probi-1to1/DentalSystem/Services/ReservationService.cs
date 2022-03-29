using DentalSystem.Abstractions;
using DentalSystem.Data;
using DentalSystem.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DentalSystem.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateReservation(int hourId, string userId, string reazon)
        {
            var patient = _context.Patients.FirstOrDefault(x => x.UserId == userId);
            var reservation = new Reservation
            {
                HourId=hourId,
                PatientId=patient.Id,
                Reazon=reazon

            };
           
            _context.Reservations.Add(reservation);
            _context.SaveChanges(); 
            var hour = _context.Hours.Find(hourId);
            hour.ReservationId = reservation.Id;
            _context.Update(hour);
            return _context.SaveChanges() != 0;

        }
    }
}
