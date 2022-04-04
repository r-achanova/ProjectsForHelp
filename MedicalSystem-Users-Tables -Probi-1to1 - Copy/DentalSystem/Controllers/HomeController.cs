using DentalSystem.Abstractions;
using DentalSystem.Models;
using DentalSystem.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DentalSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IHourService _hourService;
        private readonly IReservationService _reservationService;

        public HomeController(ILogger<HomeController> logger, 
            IDoctorService doctorService, IPatientService patientService, 
            IHourService hourService, IReservationService reservationService)
        {
            _logger = logger;
            _doctorService = doctorService;
            _patientService = patientService;
            _hourService = hourService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Statistic()
        {
            StatisticVM statistic = new StatisticVM();

            statistic.countDoctors = _doctorService.CountDoctors();
            statistic.countPatients = _patientService.GetPatients().Count();
            statistic.countHours = _hourService.GetHours().Count();
            return View(statistic);
        }
    }
}
