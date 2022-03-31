using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IRunes.Models
{
    public class AlbumCreateViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Cover")]
        public string Cover { get; set; }

        [Required]
        [Range(0.00, double.MaxValue)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}
