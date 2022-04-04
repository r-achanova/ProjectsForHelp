using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

      //  [Required]
        public string ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}
