using DentalSystem.Abstractions;
using DentalSystem.Domain;
using DentalSystem.Models.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DentalSystem.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly UserManager<ApplicationUser> _userManager;

        public int GlobalMessageKey { get; private set; }

        public PatientsController(IPatientService patientService, UserManager<ApplicationUser> userManager)
        {
            _patientService = patientService;
            _userManager = userManager;
        }


        // GET: PatientController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PatientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Authorize]
        // GET: PatientController/Create
        public ActionResult Become()
        { 
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var userIdAlreadyPatient = this._patientService
                    .GetPatients()
                    .Any(d => d.UserId == userId);

            if (userIdAlreadyPatient)
            {
                
                return RedirectToAction("Index", "Hours");
            }
            return View();
        }
     
        // POST: PatientController/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Become(BecomePatientVM patient)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userIdAlreadyPatient = this._patientService
                .GetPatients()
                .Any(d => d.UserId == userId);

            

            if (!ModelState.IsValid)
            {
                return View(patient);
            }



            var created = _patientService.CreatePacient(patient.FirstName, patient.LastName, patient.EGN, patient.Phone, patient.BirthDay, userId);

            return RedirectToAction("Index", "Hours");

            //   var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

              

        }

        // GET: PatientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientController/Edit/5
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

        // GET: PatientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientController/Delete/5
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
