namespace AudtingAPI.ViewModel
{
	public class AuditViewModel
	{
		public Guid Id { get; set; }
		public string? Actionname { get; set; }
		public string? Username { get; set; }
		public string? Employeename { get; set; }

		public DateTime timestamp { get; set; }
	}
}
