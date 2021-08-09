namespace VaccineManager.Models
{
	public class Vaccine
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int DosesRequired { get; set; }
		public int? DaysBetween { get; set; }	// null if DosesRequired == 1
		public long TotalDosesLeft { get; set; }
		public long TotalDosesReceived { get; set; }

		public Vaccine() { }

		public Vaccine(int Id, string Name, int DosesRequired, int? DaysBetween, long TotalDosesLeft)
		{
			this.Id = Id;
			this.Name = Name;
			this.DosesRequired = DosesRequired;
			this.DaysBetween = DaysBetween;
			this.TotalDosesLeft = TotalDosesLeft;
			this.TotalDosesReceived = 0;
		}

		public Vaccine(string Name, int DosesRequired, int? DaysBetween, long TotalDosesLeft)
		{
			this.Name = Name;
			this.DosesRequired = DosesRequired;
			this.DaysBetween = DaysBetween;
			this.TotalDosesLeft = TotalDosesLeft;
			this.TotalDosesReceived = 0;
		}
		
		public Vaccine(string Name, long TotalDosesLeft)
		{
			this.Name = Name;
			this.DosesRequired = 1;
			this.DaysBetween = null;
			this.TotalDosesLeft = TotalDosesLeft;
			this.TotalDosesReceived = 0;
		}
	}
}