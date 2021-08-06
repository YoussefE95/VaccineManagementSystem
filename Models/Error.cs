namespace VaccineManager.Models
{
	public class Error
	{
		public int? Id { get; set; }
		public string PreviousAction { get; set; }
		public string Message { get; set; }

		public Error() { }

		public Error(string previousAction, string message)
		{
			PreviousAction = previousAction;
			Message = message;
		}

		public Error(int? id, string previousAction, string message)
		{
			Id = id;
			PreviousAction = previousAction;
			Message = message;
		}
	}
}