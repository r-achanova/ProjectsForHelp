using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalSystem.Domain
{
    public class Doctor
    {
        public Doctor()
        {
            this.Hours = new HashSet<Hour>();
            this.Examinations = new HashSet<Examination>();
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
        [Required]
        [MaxLength(30)]
        public string Speciality { get; set; }

        [Required]
        public string Biography { get; set; }

        [Required]
        public virtual string UserId { get; set; }

       public virtual ApplicationUser User { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Hour> Hours { get; set; }
        public virtual ICollection<Examination> Examinations { get; set; }
    }
}
