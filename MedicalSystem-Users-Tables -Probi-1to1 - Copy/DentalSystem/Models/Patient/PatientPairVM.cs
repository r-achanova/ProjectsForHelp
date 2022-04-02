using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalSystem.Models.Patients
{
    public class PatientPairVM
    {
        [Key]
        public int PatientId { get; set; }
        public string FullName { get; set; }
    }
}
