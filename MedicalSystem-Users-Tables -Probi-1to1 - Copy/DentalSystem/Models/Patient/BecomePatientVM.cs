using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalSystem.Models.Patient
{
    public class BecomePatientVM
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public string EGN { get; set; }

        [Required]
        [MaxLength(10)]
        public string Phone { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
    }
}
