using Microsoft.AspNetCore.Http;
using MoreUsersApp.Models.Breed;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoreUsersApp.Models.Dog
{
    public class DogCreateVM
    {
        public DogCreateVM()
        {
            Breeds = new List<BreedPairVM>();
        }
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [Required]
        public string Name { get; set; }
        [Range(0,50)]
        public int Age { get; set; }
     
        [Display(Name="Breed")]
        public int BreedId { get; set; }

        [Required]
        public IFormFile Image { get; set; }
        public virtual List<BreedPairVM> Breeds { get; set; }
    }
}
