using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VaccineManager.Models;

namespace VaccineManager.Controllers
{
	public class PatientManagementController : Controller
	{
		private readonly IPatientService _patientService;
		private readonly IVaccineService _vaccineService;

		public PatientManagementController(IPatientService patientService, IVaccineService vaccineService)
		{
			_patientService = patientService;
			_vaccineService = vaccineService;
		}

		public IActionResult DisplayPatients()
		{
			ViewBag.Patients = _patientService.GetPatients();
			ViewBag.Vaccines = _vaccineService;
			return View();
		}

		public IActionResult RecieveSecondDose(int id)
		{
			_patientService.RecieveSecondDose(id);
			_vaccineService.DoseReceived(_patientService.GetPatient(id).VaccineId);
			return RedirectToAction("DisplayPatients");
		}

		[HttpGet]
		public IActionResult AddPatient()
		{
			ViewBag.Vaccines = _vaccineService.GetVaccines();
			return View();
		}

		[HttpPost]
		public IActionResult AddPatient(string name, int vaccineId)
		{
			_patientService.AddPatient(new Patient(name, vaccineId, DateTime.Now));
			_vaccineService.DoseReceived(vaccineId);
			return RedirectToAction("DisplayPatients");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}