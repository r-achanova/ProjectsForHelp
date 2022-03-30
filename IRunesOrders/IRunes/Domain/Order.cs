using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IRunes.Domain
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        [Required]
        public DateTime OrderedOn { get; set; }

        [Required]
         public int CountAlbums { get; set; }
        
        public decimal TotalPrice 
        { get
            {
                return CountAlbums * Album.Price;
            }  
        }

    }
}
