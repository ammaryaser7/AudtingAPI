namespace AudtingAPI.Models
{
	public class AuditModel
	{
		public Guid Id { get; set; }
		public string? Action { get; set; }


		public Guid UserModelId { get; set; }
		public Guid EmployeeModelId { get; set; }

		public DateTime timestamp { get; set; }

		public virtual UserModel? UserModel { get; set; }
		public virtual EmployeeModel? EemployeeModel { get; set; }



	}
}
