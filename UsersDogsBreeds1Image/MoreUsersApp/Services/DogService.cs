using Microsoft.AspNetCore.Http;
using MoreUsersApp.Abstractions;
using MoreUsersApp.Data;
using MoreUsersApp.Entities;
using MoreUsersApp.Models.Dog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Hosting;

namespace MoreUsersApp.Services
{
    public class DogService : IDogService
    {
        private readonly ApplicationDbContext _context;
       

        public DogService(ApplicationDbContext context)
        {
            _context = context;
        }

      
        public async Task Create(DogCreateVM model, string imagePath)
        {
            var extension = Path.GetExtension(model.Image.FileName).TrimStart('.');

            var dog = new Dog
            {
                Name = model.Name,
                Age = model.Age,
                BreedId = model.BreedId,
            };

            var dbImage = new Image()
            {
                Dog = dog,
                Extension = extension
            }; 
            //id се създава автоматично при създаване на обект

            dog.ImageId = dbImage.Id; //връзваме снимката за кучето

            Directory.CreateDirectory($"{imagePath}/images/");
            //създаваме папката images, ако не съществува

            var physicalPath = $"{imagePath}/images/{dbImage.Id}.{extension}";
            using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
            await model.Image.CopyToAsync(fileStream);

            await this._context.Images.AddAsync(dbImage);
           
            await this._context.Dogs.AddAsync(dog);
            await this._context.SaveChangesAsync();
        }

        public Dog GetDogById(int dogId)
        {
            return _context.Dogs.Find(dogId);

        }

        public List<DogListVM> GetDogs()
        {
            List<DogListVM> dogs = _context.Dogs
               .Select(d => new DogListVM
               {
                   Id = d.Id,
                   Name = d.Name,
                   Age = d.Age,
                   BreedName = d.Breed.Name,
                   BreedId = d.Breed.Id,
                   ImageUrl = $"/images/{d.ImageId}.{d.Image.Extension}"
               }).ToList();
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
