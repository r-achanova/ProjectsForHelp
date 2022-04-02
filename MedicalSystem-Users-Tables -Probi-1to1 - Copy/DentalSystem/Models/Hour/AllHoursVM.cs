using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalSystem.Models.Hour
{
    public class AllHoursVM
    {
        public int Id { get; set; }
        public DateTime FreeHour { get; set; }

       public bool IsBusy { get; set; }

       public string DoctorFullName { get; set; }

    }
}
