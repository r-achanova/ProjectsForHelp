using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoreUsersApp.Entities
{
    public class Dog
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(1, 30)]
        public int Age { get; set; }

        [Required]

        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }

        public string Picture { get; set; }
    }
}
