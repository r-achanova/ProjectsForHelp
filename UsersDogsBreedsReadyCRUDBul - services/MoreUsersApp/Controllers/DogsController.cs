using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoreUsersApp.Abstractions;
using MoreUsersApp.Entities;
using MoreUsersApp.Models.Breed;
using MoreUsersApp.Models.Dog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreUsersApp.Controllers
{
    public class DogsController : Controller
    {
        private readonly IDogService _dogService;
        private readonly IBreedService _breedService;

        public DogsController(IDogService dogService, IBreedService breedService)
        {
            _dogService = dogService;
            _breedService = breedService;
        }

        // GET: DogsController
        public ActionResult Index()
        {
          
            List<DogListVM> dogsFromDb = _dogService.GetDogs()
               .Select(item => new DogListVM()
               {
                  Id = item.Id,
                  Name=item.Name,
                  Age=item.Age,
                  BreedName=item.Breed.Name,
                  Picture=item.Picture

               }).ToList();
            return View(dogsFromDb);
        }

     

        public ActionResult Search(int searchAge)
        {
              List<DogListVM> dogsFromDb = _dogService.GetDogs(searchAge)
               .Select(item => new DogListVM()
               {
                   Id = item.Id,
                   Name = item.Name,
                   Age = item.Age,
                   BreedName = item.Breed.Name,
                   Picture = item.Picture

               }).ToList();
            return View(dogsFromDb);
        }

        // GET: DogsController/Details/5
        public ActionResult Details(int id)
        {
            Dog item = _dogService.GetDogById(id);
            if (item == null)
            {
                return NotFound();
            }
            DogDetailsVM dog = new DogDetailsVM()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                BreedName = item.Breed.Name,
                Picture = item.Picture
            };
            return View(dog);
        }
        

        // GET: DogsController/Create
        public ActionResult Create()
        {
            var dog = new DogCreateVM();
            dog.Breeds = _breedService.GetBreeds()
                .Select(c => new BreedPairVM()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
            return View(dog);
        }

        // POST: DogsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] DogCreateVM dog)
        {
            if (ModelState.IsValid)
            {
                var createdId = _dogService.Create(dog.Name, dog.Age, dog.BreedId, dog.Picture);
                if (createdId)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
           
                return View();
         
        }

        // GET: DogsController/Edit/5
        public ActionResult Edit(int id)
        {
            Dog item = _dogService.GetDogById(id);
            if (item == null)
            {
                return NotFound();
            }
            DogCreateVM dog = new DogCreateVM()
            {
                Id = item.Id,
                Name = item.Name,
               BreedId=item.BreedId,
                Age=item.Age,
                Picture=item.Picture
            };
            dog.Breeds = _breedService.GetBreeds()
                .Select(c => new BreedPairVM()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
            return View(dog);
        }

        // POST: DogsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DogCreateVM bindingModel)
        {
            if (ModelState.IsValid)
            {
                var updated = _dogService.UpdateDog(id, bindingModel.Name, bindingModel.Age, bindingModel.BreedId,  bindingModel.Picture);
                if (updated)
                {
                    return this.RedirectToAction("Index");
                }
            }
            return View(bindingModel);
        }

        // GET: DogsController/Delete/5
        public ActionResult Delete(int id)
        {
            Dog item = _dogService.GetDogById(id);
            if (item == null)
            {
                return NotFound();
            }
            DogDetailsVM dog = new DogDetailsVM()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                BreedName = item.Breed.Name,
                Picture = item.Picture
            };
            return View(dog);
        }

        // POST: DogsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _dogService.RemoveById(id);

            if (deleted)
            {
                return this.RedirectToAction("Index", "Dogs");
            }
            else
            {
                return View();
            }
        }

        public ActionResult All()
        {

            List<DogListVM> dogsFromDb = _dogService.GetDogs()
               .Select(item => new DogListVM()
               {
                   Id = item.Id,
                   Name = item.Name,
                   Age = item.Age,
                   BreedName = item.Breed.Name,
                   Picture = item.Picture

               }).ToList();
            return View(dogsFromDb);
        }

        public IActionResult Statistic()
        {
            var statistic = new StatisticVM();
            statistic.CountAllDogs = _dogService.GetDogs().Count();
            statistic.CountHuskiDogs = _dogService.GetDogs().Where(x => x.Breed.Name == "Husky").Count();
            return View(statistic);
        }
    }
}
