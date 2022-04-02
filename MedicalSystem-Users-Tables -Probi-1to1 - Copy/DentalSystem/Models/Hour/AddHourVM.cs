using DentalSystem.Models.Doctors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalSystem.Models.Hour
{
    public class AddHourVM
    {
        public AddHourVM()
        {
            Doctors = new List<DoctorPairVM>();
        }

        
        public DateTime FreeHour { get; set; }

        [Required]
        [DisplayName("Doctor")]
        public int DoctorId { get; set; }

        public virtual List<DoctorPairVM> Doctors { get; set; }


    }
}
