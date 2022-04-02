﻿using MoreUsersApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreUsersApp.Abstractions
{
    public interface IDogService
    {
        bool Create(string name, int age, int breedId, string picture);
        bool UpdateDog(int dogId, string name, int age, int breedId, string picture);
        List<Dog> GetDogs();
        Dog GetDogById(int dogId);
        bool RemoveById(int dogId);
        List<Dog> GetDogs(string searchStringBreed, string searchStringName);
    }
}
