using MoreUsersApp.Entities;
using MoreUsersApp.Models.Dog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreUsersApp.Abstractions
{
  public  interface IDogService
    {
     public bool Create(CreateDogVM dog);
     public List<Breed> GetBreeds();
    }
}
