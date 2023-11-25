namespace AudtingAPI.ViewModel
{
	public class SingleAuditViewModel
	{
		public Guid Id { get; set; }
		public string? Action { get; set; }


		public Guid UserModelId { get; set; }
		public Guid EmployeeModelId { get; set; }

		public DateTime timestamp { get; set; }
	}
}
