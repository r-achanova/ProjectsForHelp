using MoreUsersApp.Abstractions;
using MoreUsersApp.Data;
using MoreUsersApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreUsersApp.Services
{
    public class DogService : IDogService
    {
        private readonly ApplicationDbContext _context;

        public DogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(string name, int age, int breedId, string picture)
        {
            var dog = new Dog
            {
                Name=name,
                Age=age,
                Breed=_context.Breeds.Find(breedId),
                Picture=picture,
            };
           
            _context.Dogs.Add(dog);
            
            return _context.SaveChanges()!=0;
        }

        public Dog GetDogById(int dogId)
        {
            return _context.Dogs.Find(dogId);

        }

        public List<Dog> GetDogs()
        {
            List<Dog> dogs = _context.Dogs
               .ToList();
            return dogs;
        }

        public List<Dog> GetDogs(string searchStringBreed, string searchStringName)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int dogId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDog(int dogId, string name, int age, int breedId, string picture)
        {
            throw new NotImplementedException();
        }
    }
}
