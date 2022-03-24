using Eventures2022.Data;
using Eventures2022.Domain;
using Eventures2022.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Globalization;
using System.Threading.Tasks;

namespace Eventures2022.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext context;

        public OrdersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult Create(OrderCreateBindingModel bindingModel)
        {

            if (this.ModelState.IsValid)
            {
                string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var user = this.context.Users.SingleOrDefault(u => u.Id == currentUserId);
                var ev = this.context.Events.SingleOrDefault(e => e.Id == bindingModel.EventId);
                if (user == null || ev == null || ev.TotalTickets < bindingModel.TicketsCount)
                {
                    // ако потребителят не съществува или събитието не съществува или няма достатъчно билети
                    return this.RedirectToAction("All", "Events");
                }

                Order orderForDb = new Order //създаваме нова поръчка
                {
                    OrderedOn = DateTime.UtcNow,
                    EventId = bindingModel.EventId,
                    TicketsCount = bindingModel.TicketsCount,
                    CustomerId = currentUserId
                };

                ev.TotalTickets -= bindingModel.TicketsCount; //намаляваме броя на билетите

                this.context.Events.Update(ev);
                this.context.Orders.Add(orderForDb);
                this.context.SaveChanges();


            }
            return this.RedirectToAction("My", "Events");
        }

            [Authorize(Roles = "Administrator")]
            public IActionResult Index()
            {
             List<OrderListingViewModel> orders = this.context.Orders
                .Select(o => new OrderListingViewModel
                {
                 //   Id = o.Id,
                 //   EventId = o.EventId,
                    EventName = o.Event.Name,
                  //  EventStart = o.Event.Start.ToString("dd-MM-yyyy hh:mm", CultureInfo.InvariantCulture),
                  //  EventEnd = o.Event.End.ToString("dd-MM-yyyy hh:mm", CultureInfo.InvariantCulture),
                  //  EventPlace = o.Event.Place,
                  //  CustomerId = o.CustomerId,
                    CustomerUsername = o.Customer.UserName,
                    TicketsCount = o.TicketsCount,
                    OrderedOn = o.OrderedOn.ToString("dd-MM-yyyy hh:mm", CultureInfo.InvariantCulture),
                    //да се преработи да извежда по нашата часова зона
                })
                .ToList();
           
                return this.View(orders);
            }
        }
}
