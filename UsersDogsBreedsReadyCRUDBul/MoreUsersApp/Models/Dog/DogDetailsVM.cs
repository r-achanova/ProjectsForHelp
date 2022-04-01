using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoreUsersApp.Models.Dog
{
    public class DogDetailsVM
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Възраст")]
        public int Age { get; set; }

        
        [Display(Name = "Порода")]
        public string BreedName { get; set; }

        [Display(Name = "Снимка")]
        public string Picture { get; set; }
    }
}
