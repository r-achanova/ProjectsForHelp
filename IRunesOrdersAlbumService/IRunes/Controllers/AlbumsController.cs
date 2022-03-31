using IRunes.Abstarctions;
using IRunes.Data;
using IRunes.Domain;
using IRunes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRunes.Controllers
{
    public class AlbumsController : Controller
    {
        
        private readonly IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AlbumCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var created = _albumService.Create(bindingModel.Name, bindingModel.Cover, bindingModel.Price);
                if (created)
                {
                return this.RedirectToAction("All");
                }
            }
            return View(); //za da se vidi pak formata
        }

        public IActionResult Edit(int id)
        {
            Album item = _albumService.GetAlbumById(id);
            if (item == null)
            {
                return NotFound();
            }
            AlbumCreateViewModel album = new AlbumCreateViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Cover = item.Cover,
                Price = item.Price
            };
            return View(album);
        }

        [HttpPost]
        public IActionResult Edit(AlbumCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var update = _albumService.Update(bindingModel.Id, bindingModel.Name, bindingModel.Cover, bindingModel.Price);
                if (update)
                {
                    return this.RedirectToAction("All");
                }
                
            }
            return View(bindingModel);

        }

        public IActionResult Delete(int id)
        {
            Album item = _albumService.GetAlbumById(id);
            if (item == null)
            {
                return NotFound();
            }
            AlbumCreateViewModel album = new AlbumCreateViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Cover = item.Cover,
                Price = item.Price
            };
            return View(album);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _albumService.RemoveById(id);

            if (deleted)
            {
                return this.RedirectToAction("All", "Albums");
            }
            else
            {
                return View();
            }
        }

        // GET: Albums/Details/5
        public IActionResult Details(int id)
        {
            Album item = _albumService.GetAlbumById(id);
            if (item == null)
            {
                return NotFound();
            }
            AlbumCreateViewModel album = new AlbumCreateViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Cover = item.Cover,
                Price = item.Price
            };
            return View(album);
        }
        public IActionResult All()
        {
            var albums=_albumService.GetAlbums()
                .Select(a => new AlbumsAllViewModel
                {
                    Id=a.Id, //непременно да се вземе от БД
                    Name = a.Name,
                    Cover = a.Cover,
                    Price = a.Price
                }).ToList();
            return this.View(albums);
        }

  
            
        /*  private bool AlbumExists(int id)
          {
              return context.Albums.Any(e => e.Id == id);
          }*/
    }
}
