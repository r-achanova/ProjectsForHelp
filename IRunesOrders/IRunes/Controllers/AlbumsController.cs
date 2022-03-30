using IRunes.Data;
using IRunes.Domain;
using IRunes.Models;
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
        private readonly ApplicationDbContext context;
        public AlbumsController(ApplicationDbContext context)
        {
            this.context = context;
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
                Album album = new Album
                {
                    Name = bindingModel.Name,
                    Cover = bindingModel.Cover,
                    Price = bindingModel.Price
                };
                context.Albums.Add(album);
                context.SaveChanges();
                return this.RedirectToAction("All");
            }
            return View(); //za da se vidi pak formata
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Album item = context.Albums.Find(id);
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
                Album album = new Album
                {
                    Id=bindingModel.Id,
                    Name = bindingModel.Name,
                    Cover = bindingModel.Cover,
                    Price = bindingModel.Price
                };
                context.Albums.Update(album);
                context.SaveChanges();
                return this.RedirectToAction("All");
            }
            return View(bindingModel);

        }

        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Album item = context.Albums.Find(id);
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
        public IActionResult Delete(int id)
        {
            Album item = context.Albums.Find(id);
            if (item==null)
            {
                return NotFound();
            }
            context.Albums.Remove(item);
            context.SaveChanges();
            return this.RedirectToAction("All", "Albums");
        }

        // GET: Albums/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Album item = context.Albums.Find(id);
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
            var albums = context.Albums
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
