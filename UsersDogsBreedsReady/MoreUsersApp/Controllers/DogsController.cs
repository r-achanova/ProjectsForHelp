using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoreUsersApp.Abstractions;
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
            return View();
        }

        // GET: DogsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            return View();
        }

        // POST: DogsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DogsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DogsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
