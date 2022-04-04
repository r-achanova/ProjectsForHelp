using MoreUsersApp.Entities;
using MoreUsersApp.Models.Dog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreUsersApp.Abstractions
{
    public interface IDogService
    {
       Task Create(DogCreateVM model, string imagePath);
        bool UpdateDog(int dogId, string name, int age, int breedId);
        List<DogListVM> GetDogs();
        Dog GetDogById(int dogId);
        bool RemoveById(int dogId);
        List<Dog> GetDogs(string searchStringBreed, string searchStringName);
    }
}
