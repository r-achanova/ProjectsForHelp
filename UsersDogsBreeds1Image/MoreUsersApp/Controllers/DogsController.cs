using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _hostEnvironment;

        public DogsController(IDogService dogService, IBreedService breedService, IWebHostEnvironment hostEnvironment)
        {
            this._dogService = dogService;
           this._breedService = breedService;
            this._hostEnvironment = hostEnvironment;
        }



        // GET: DogsController
        public ActionResult Index()
        {
            var allDogs = _dogService.GetDogs();
            return View(allDogs);
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
        public async Task<ActionResult> Create([FromForm] DogCreateVM input)
        {
            var imagePath = $"{this._hostEnvironment.WebRootPath}";
            if (!ModelState.IsValid)
            {
                input.Breeds= _breedService.GetBreeds()
                .Select(c => new BreedPairVM()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
                return View(input);
             
            }
           await this._dogService.Create(input,imagePath);
                
          return RedirectToAction(nameof(Index));
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
