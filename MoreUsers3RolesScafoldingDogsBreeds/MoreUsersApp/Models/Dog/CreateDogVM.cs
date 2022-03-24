using MoreUsersApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoreUsersApp.Models.Dog
{
    public class CreateDogVM
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }
        [Required]
        public int BreedId { get; set; }
        public Breed Breed { get; set; }
    }
}
