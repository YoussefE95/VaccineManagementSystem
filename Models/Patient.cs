using System;

namespace VaccineManager.Models
{
	public class Patient
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int VaccineId { get; set; }
		public DateTime FirstDose { get; set; }
		public DateTime? SecondDose { get; set; }

		public Patient() { }

		public Patient(int Id, string Name, int VaccineId , DateTime FirstDose, DateTime SecondDose)
		{
			this.Id = Id;
			this.Name = Name;
			this.VaccineId = VaccineId;
			this.FirstDose = FirstDose;
			this.SecondDose = SecondDose;
		}

		public Patient(string Name, int VaccineId , DateTime FirstDose)
		{
			this.Name = Name;
			this.VaccineId = VaccineId;
			this.FirstDose = FirstDose;
			this.SecondDose = null;
		}
	}
}