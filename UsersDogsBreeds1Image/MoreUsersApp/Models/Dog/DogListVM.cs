using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreUsersApp.Models.Dog
{
    public class DogListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int BreedId { get; set; }
        public string BreedName { get; set; }
        public string ImageUrl { get; set; }
    }
}
