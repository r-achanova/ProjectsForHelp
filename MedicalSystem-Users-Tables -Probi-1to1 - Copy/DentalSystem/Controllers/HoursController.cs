using DentalSystem.Abstractions;
using DentalSystem.Models.Doctors;
using DentalSystem.Models.Hour;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalSystem.Controllers
{
    
    public class HoursController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IHourService _hourService;

        public HoursController(IDoctorService doctorService, IPatientService patientService, IHourService hourService)
        {
            _doctorService = doctorService;
            _patientService = patientService;
            _hourService = hourService;
        }

        // GET: HoursController
        public ActionResult Index()
        {
            List<AllHoursVM> hours = _hourService.GetHours()
               .Select(item => new AllHoursVM()
               {
                   Id = item.Id,
                   FreeHour=item.FreeHour,
                   IsBusy=item.IsBusy,
                   DoctorFullName=item.Doctor.FirstName+" "+item.Doctor.LastName
                   
               }).ToList();
            return View(hours);
        }

        // GET: HoursController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HoursController/Create
        public ActionResult Create()
        {
            var hour = new AddHourVM();
            hour.FreeHour = DateTime.Now;
            hour.Doctors = _doctorService.GetDoctors()
                .Select(c => new DoctorPairVM()
                {
                    DoctorId = c.Id,
                    FullName = c.FirstName + " " + c.LastName
                })
                .ToList();
            return View(hour);
        }

        // POST: HoursController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] AddHourVM model)
        {
            var createdId = _hourService.CreateHour(model.FreeHour, model.DoctorId);

            if (createdId)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: HoursController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HoursController/Edit/5
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

        // GET: HoursController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HoursController/Delete/5
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
