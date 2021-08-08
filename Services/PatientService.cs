using System.Collections.Generic;
using VaccineManager.Models;
using System.Linq;
using System;

namespace VaccineManager
{
	public interface IPatientService
	{
		List<Patient> GetPatients();

		Patient GetPatient(int id);

		void AddPatient(Patient newPatient);

		void RecieveSecondDose(int id);
		
		void SaveChanges();
	}

	public class PatientService : IPatientService
	{
		private readonly AppDbContext _db;
		
		public PatientService(AppDbContext db) => _db = db;

		public List<Patient> GetPatients() => _db.Patients.ToList();

		public Patient GetPatient(int id) => _db.Patients.Where(p => p.Id == id).SingleOrDefault();

		public void AddPatient(Patient newPatient)
		{
			_db.Patients.Add(newPatient);
			SaveChanges();
		}

		public void RecieveSecondDose(int id)
		{
			GetPatient(id).SecondDose = DateTime.Now;
			SaveChanges();
		}

		public void SaveChanges() => _db.SaveChanges();
	}
}