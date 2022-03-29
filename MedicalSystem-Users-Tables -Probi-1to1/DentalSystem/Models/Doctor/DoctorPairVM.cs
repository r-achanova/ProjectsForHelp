using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalSystem.Models.Doctors
{
    public class DoctorPairVM
    {
        [Key]
        public int DoctorId { get; set; }
        public string FullName { get; set; }
    }
}
