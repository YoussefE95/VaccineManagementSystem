using System.Collections.Generic;
using VaccineManager.Models;
using System.Linq;

namespace VaccineManager
{
	public interface IVaccineService
	{
		List<Vaccine> GetVaccines();

		Vaccine GetVaccine(int id);

		void AddVaccine(Vaccine newVaccine);

		void AddDoses(int id, long newDoses);
		
		void EditVaccine(Vaccine updatedVaccine);

		void SaveChanges();
	}

	public class VaccineService : IVaccineService
	{
		private readonly AppDbContext _db;

		public VaccineService(AppDbContext db) => _db = db;

		public List<Vaccine> GetVaccines() => _db.Vaccines.ToList();

		public Vaccine GetVaccine(int id) => _db.Vaccines.Where(v => v.Id == id).SingleOrDefault();

		public void AddVaccine(Vaccine newVaccine)
		{
			if(newVaccine.DaysBetween == 0)
				newVaccine.DaysBetween = null;

			_db.Vaccines.Add(newVaccine);

			_db.SaveChanges();
		}

		public void AddDoses(int id, long newDoses)
		{
			_db.Vaccines.Where(v => v.Id == id).SingleOrDefault().TotalDoses += newDoses;
			SaveChanges();
		}

		public void EditVaccine(Vaccine updatedVaccine)
		{
			Vaccine editedVaccine = GetVaccine(updatedVaccine.Id);
			editedVaccine.Name = updatedVaccine.Name;
			editedVaccine.DosesRequired = updatedVaccine.DosesRequired;
			if(updatedVaccine.DaysBetween == 0)
				editedVaccine.DaysBetween = null;
			else
				editedVaccine.DaysBetween = updatedVaccine.DaysBetween;
			
			SaveChanges();
		}

		public void SaveChanges() => _db.SaveChanges();
	}
}