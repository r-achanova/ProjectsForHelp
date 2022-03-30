using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IRunes.Models
{
    public class AlbumsAllViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Cover { get; set; }

        [Required]
        [Range(0.00, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
