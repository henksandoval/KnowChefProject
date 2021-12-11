namespace Chef.Infrastructure.Configurations.Models
{
	internal class ErrorDetail
	{
		public string? Title { get; internal set; }
		public int? Status { get; internal set; }
		public string? CodeError { get; internal set; }
		public string? Type { get; internal set; }
		public string? Detail { get; internal set; }
		public string? TraceId { get; internal set; }
		public string? StackTrace { get; internal set; }
	}
}
