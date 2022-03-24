using MoreUsersApp.Abstractions;
using MoreUsersApp.Data;
using MoreUsersApp.Entities;
using MoreUsersApp.Models.Dog;
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

        public bool Create(CreateDogVM dog)
        {
            var dogToDb = new Dog
            {
                Name = dog.Name,
                Age = dog.Age,
                Breed = _context.Breeds.Find(dog.BreedId),

            };
            _context.Dogs.Add(dogToDb);
            return _context.SaveChanges() != 0;
        }

        public List<Breed> GetBreeds()
        {
            List<Breed> breeds = _context.Breeds.ToList();
            return breeds;
        }
    }
}
