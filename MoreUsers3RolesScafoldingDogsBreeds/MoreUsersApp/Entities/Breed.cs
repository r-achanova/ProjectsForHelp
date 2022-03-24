using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoreUsersApp.Entities
{
    public class Breed
    {

        [Key]
            public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual IEnumerable<Dog> Dogs { get; set; }
    }
}
