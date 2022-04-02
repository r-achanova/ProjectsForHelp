using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoreUsersApp.Models.Breed
{
    public class BreedPairVM
    {
        public int Id { get; set; }

      
        [Display(Name="Breed")]
        public string Name { get; set; }
    }
}
