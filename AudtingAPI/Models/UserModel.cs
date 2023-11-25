namespace AudtingAPI.Models
{
	public class UserModel
	{
		public Guid Id { get; set; }
		public string? Name { get; set; }

		public virtual List<AuditModel>? AuditModels { get; set; }
	}
}
