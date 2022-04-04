using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoreUsersApp.Entities
{
    public class Image
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }

        [Required]
        [ForeignKey("Dog")]
        public int DogId { get; set; }

       public virtual Dog Dog { get; set; }

        public string Extension { get; set; }

    }
}
