using IRunes.Data;
using IRunes.Domain;
using IRunes.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRunes.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext context;

        public OrdersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int? id)
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
            OrderCreateViewModel order = new OrderCreateViewModel()
            {
                AlbumId = item.Id,
                Price=item.Price,
               
            };
            return View(order);
            
        }
        [HttpPost]
        public IActionResult Create(OrderCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var item = context.Albums.Find(bindingModel.AlbumId);
                if (item == null)
                {
                    return this.RedirectToAction("Create");
                }
                Order order = new Order
                {
                    CountAlbums = bindingModel.CountAlbums,
                    AlbumId=bindingModel.AlbumId,
                    OrderedOn=DateTime.Now,
                };
                context.Orders.Add(order);
                context.SaveChanges();
                return this.RedirectToAction("All","Albums");
            }
            return View(); //za da se vidi pak formata
        }

        

    }
}
