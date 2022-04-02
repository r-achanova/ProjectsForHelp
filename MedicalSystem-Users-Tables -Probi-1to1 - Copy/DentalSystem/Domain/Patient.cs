using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalSystem.Domain
{
    public class Patient
    {
        public Patient()
        {
            
            this.Examinations = new HashSet<Examination>();
            this.Reservations = new HashSet<Reservation>();
        }

        [Key]
        public int Id { get; set; }

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
        public DateTime BirthDay { get; set; }

        [Required]
        public virtual string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Examination> Examinations { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
