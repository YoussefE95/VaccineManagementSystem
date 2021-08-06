namespace VaccineManager.Models
{
	public class Vaccine
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int DosesRequired { get; set; }
		public int? DaysBetween { get; set; }	// null if DosesRequired == 1
		public long TotalDoses { get; set; }

		public Vaccine() { }

		public Vaccine(int Id, string Name, int DosesRequired, int? DaysBetween, long TotalDoses)
		{
			this.Id = Id;
			this.Name = Name;
			this.DosesRequired = DosesRequired;
			this.DaysBetween = DaysBetween;
			this.TotalDoses = TotalDoses;
		}

		public Vaccine(string Name, int DosesRequired, int? DaysBetween, long TotalDoses)
		{
			this.Name = Name;
			this.DosesRequired = DosesRequired;
			this.DaysBetween = DaysBetween;
			this.TotalDoses = TotalDoses;
		}
		
		public Vaccine(string Name, long TotalDoses)
		{
			this.Name = Name;
			this.DosesRequired = 1;
			this.DaysBetween = null;
			this.TotalDoses = TotalDoses;
		}
	}
}