using MoreUsersApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreUsersApp.Abstractions
{
   public interface IBreedService
    {
        
        List<Breed> GetBreeds();
        Breed GetBreedById(int breedId);
        List<Dog> GetDogsByBreed(int breedId);
        
    }
}
