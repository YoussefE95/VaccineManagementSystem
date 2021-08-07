using System.Collections.Generic;
using VaccineManager.Models;
using System.Linq;
using System;

namespace VaccineManager
{
	public interface IPatientService
	{
		List<Patient> GetPatients();

		void AddPatient(Patient newPatient);

		void RecieveSecondDose(int id, DateTime currentDate);
		
		void SaveChanges();
	}

	public class PatientService : IPatientService
	{
		private readonly AppDbContext _db;
		
		public PatientService(AppDbContext db) => _db = db;

		public List<Patient> GetPatients() => _db.Patients.ToList();

		public void AddPatient(Patient newPatient) => _db.Patients.Add(newPatient);

		public void RecieveSecondDose(int id, DateTime currentDate)
		{

		}

		public void SaveChanges() => _db.SaveChanges();
	}
}