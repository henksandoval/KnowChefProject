namespace ChefCore.Domains.Entities
{
	public class TimePreparation
	{
		public int Time { get; set; } = 0;
		public TimeMeasurement TimeMeasurement { get; set; }
	}
}
