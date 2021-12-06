namespace Chef.Core.Domains.Models
{
	using Chef.Shared.Utilities.Value;

	public class Time : ValueObject
	{
		internal float value;
		internal TimeMeasurement TimeMeasurement { get; set; }

		public Time(float value, TimeMeasurement timeMeasurement)
		{
			this.value = value;
			TimeMeasurement = timeMeasurement;
		}
	}
}
