﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalSystem.Domain
{
    public class Examination
    {
        public Examination()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        [Required]
        public string Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Diagnose { get; set; }

        [Required]
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        [Required]
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
