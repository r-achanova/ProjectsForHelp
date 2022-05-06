using MoreUsersApp.Abstractions;
using MoreUsersApp.Data;
using MoreUsersApp.Entities;
using MoreUsersApp.Models.Breed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreUsersApp.Services
{
    public class BreedService : IBreedService
    {
        private readonly ApplicationDbContext _context;

        public BreedService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Breed GetBreedById(int breedId)
        {
            return _context.Breeds.Find(breedId);
        }

        public List<Breed> GetBreeds()
        {
            List<Breed> breeds = _context.Breeds.ToList();
            return breeds;
        }

       
        public List<Dog> GetDogsByBreed(int breedId)
        {
            return _context.Dogs
                .Where(x => x.BreedId ==
                breedId)
                .ToList();
        }
    }
}
