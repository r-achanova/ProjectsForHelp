using MoreUsersApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreUsersApp.Models.Dog
{
    public class ListingDogVM
    {
      
        public int Id { get; set; }
       
        public string Name { get; set; }

      
        public int Age { get; set; }
        
        public int BreedId { get; set; }
        public Breed Breed { get; set; }
    }
}
