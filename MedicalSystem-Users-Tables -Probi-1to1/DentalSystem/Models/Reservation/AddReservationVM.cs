using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalSystem.Models.Reservation
{
    public class AddReservationVM
    {
        public int Id { get; set; }
        public int HourId { get; set; }
        public string Reazon { get; set; }
    }
}
