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
	public class VaccineManagementController : Controller
	{
		private readonly IVaccineService _vaccineService;

		public VaccineManagementController(IVaccineService vaccineService) => _vaccineService = vaccineService;

		public IActionResult DisplayVaccines()
		{
			ViewBag.Vaccines = _vaccineService.GetVaccines();
			return View();
		}

		[HttpGet]
		public IActionResult AddVaccine() => View();

		[HttpPost]
		public IActionResult AddVaccine(Vaccine newVaccine)
		{
			if(newVaccine.DosesRequired == 2 && newVaccine.DaysBetween <= 0)
				return RedirectToAction("InputError", new Error("AddVaccine", "A vaccine with two required doses must have days between each dose"));
			else if(newVaccine.DosesRequired == 1 && newVaccine.DaysBetween != 0)
				return RedirectToAction("InputError", new Error("AddVaccine", "A vaccine with only one required dose cannot have days between"));

			_vaccineService.AddVaccine(newVaccine);
			return RedirectToAction("DisplayVaccines");
		}

		[HttpGet]
		public IActionResult AddDoses()
		{
			ViewBag.Vaccines = _vaccineService.GetVaccines();
			return View();
		}

		[HttpPost]
		public IActionResult AddDoses(int id, long newDoses)
		{
			if(newDoses <= 0)
				return RedirectToAction("InputError", new Error("AddDoses", "Only values greater than zero can be added to a vaccine's doses"));

			_vaccineService.AddDoses(id, newDoses);
			return RedirectToAction("DisplayVaccines");
		}

		[HttpGet]
		public IActionResult EditVaccine(int id) => View(_vaccineService.GetVaccine(id));

		[HttpPost]
		public IActionResult EditVaccine(Vaccine updatedVaccine)
		{
			if(updatedVaccine.DosesRequired == 2 && updatedVaccine.DaysBetween <= 0)
				return RedirectToAction("InputError", new Error(updatedVaccine.Id, "EditVaccine", "A vaccine with two required doses must have days between each dose"));
			else if(updatedVaccine.DosesRequired == 1 && updatedVaccine.DaysBetween != 0)
				return RedirectToAction("InputError", new Error(updatedVaccine.Id, "EditVaccine", "A vaccine with only one required dose cannot have days between"));

			_vaccineService.EditVaccine(updatedVaccine);
			return RedirectToAction("DisplayVaccines");
		}

		public IActionResult InputError(Error error) => View(error);

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}