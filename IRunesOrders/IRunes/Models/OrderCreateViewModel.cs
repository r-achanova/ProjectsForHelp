using IRunes.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IRunes.Models
{
    public class OrderCreateViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        [Required]
        [Range(0, 30)]
         [Display(Name = "CountAlbums")]
        public int CountAlbums { get; set; }

        [Required]
        public DateTime OrderedOn { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }


    }
}
