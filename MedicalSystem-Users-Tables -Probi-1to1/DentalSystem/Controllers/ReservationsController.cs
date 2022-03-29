using DentalSystem.Abstractions;
using DentalSystem.Domain;
using DentalSystem.Models.Reservation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DentalSystem.Controllers
{
    public class ReservationsController : Controller
        
    {
        private readonly IReservationService _reservationService;
        private readonly IHourService _hourService;
        public ReservationsController(IReservationService reservationService, IHourService hourService)
        {
            _reservationService = reservationService;
            _hourService = hourService;
        }

        // GET: ReservationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReservationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservationController/Create
        public ActionResult Create(int id)
        {
            if (id ==0)
            {
                return NotFound();
            }

            Hour item = _hourService.GetHourById(id);
            if (item == null)
            {
                return NotFound();
            }
            AddReservationVM reservation = new AddReservationVM()
            {
                HourId = item.Id,
            };
            return View(reservation);

        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, AddReservationVM model)
        {
            if (!this.ModelState.IsValid)
            {
                return NotFound();
            }
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var created = _reservationService.CreateReservation(id, currentUserId, model.Reazon);
           if (created)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: ReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationController/Edit/5
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

        // GET: ReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationController/Delete/5
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
