using Eventures2022.Data;
using Eventures2022.Domain;
using Eventures2022.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Eventures2022.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext context;
        public EventsController(ApplicationDbContext context)
        {
            this.context = context;
        }
       
        public IActionResult All(string searchString)
        {
            List<EventAllViewModel> events= context.Events
                 .Select(e => new EventAllViewModel
                 {
                     Id=e.Id,
                     Name = e.Name,
                     Place = e.Place,
                     Start = e.Start.ToString("dd-MM-yyyy hh:mm", CultureInfo.InvariantCulture),
                     End = e.End.ToString("dd-MM-yyyy hh:mm", CultureInfo.InvariantCulture),
                     Owner = e.Owner.UserName
                 })
                 .ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                events = events.Where(s => s.Place.Contains(searchString)).ToList(); 
            }

            return this.View(events);
        }

        [Authorize(Roles ="Administrator")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create(EventCreateBindingModel bindingModel)
        {
            
            if (this.ModelState.IsValid)
            {
                string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Event eventForDb = new Event
                {
                    Name = bindingModel.Name,
                    Place = bindingModel.Place,
                    Start = bindingModel.Start,
                    End = bindingModel.End,
                    TotalTickets = bindingModel.TotalTickets,
                    PricePerTicket = bindingModel.PricePerTicket,
                    OwnerId = currentUserId
                };
                context.Events.Add(eventForDb);
                context.SaveChanges();
                return this.RedirectToAction("All");
            }
            
            return this.View();
        }

        [Authorize]
        public IActionResult My(string searchString)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user =  this.context.Users.SingleOrDefault(u => u.Id==currentUserId);
            if (user == null)
            {
                return null;
            }

           
            List<OrderListingViewModel> orders = this.context.Orders
                .Where(o => o.CustomerId == user.Id)
                .Select(o => new OrderListingViewModel
                {
                    Id = o.Id,
                    EventId=o.EventId,
                    EventName = o.Event.Name,
                    EventStart = o.Event.Start.ToString("dd-mm-yyyy hh:mm", CultureInfo.InvariantCulture),
                    EventEnd = o.Event.End.ToString("dd-mm-yyyy hh:mm", CultureInfo.InvariantCulture),
                    EventPlace = o.Event.Place,
                    OrderedOn= o.OrderedOn.ToString("dd-mm-yyyy hh:mm", CultureInfo.InvariantCulture),
                    CustomerId =o.CustomerId,
                    CustomerUsername=o.Customer.UserName,
                    TicketsCount=o.TicketsCount
                })
                .ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(o => o.EventPlace.Contains(searchString)).ToList();
            }

            return this.View(orders);
        }

    }
}
