namespace Chef.Shared.Utilities.Extensions
{

	public static class StringExtensions
	{
		public static string NullToString(this object? value)
			=> value?.ToString() ?? string.Empty;

		/// <summary>
		/// Throws an <see cref="ArgumentNullException" /> if <paramref name="value" /> is null.
		/// Throws an <see cref="ArgumentException" /> if <paramref name="value" /> is an empty string or consists only of white-space.
		/// </summary>
		/// <param name="value"> The string to test.</param>
		/// <param name="parameterName"> Parameter name to be verified</param>
		/// <param name="message">Optional. Custom error message</param>
		/// <returns><paramref name="value" /> If the value is not null, empty or whitespace string</returns>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		public static string ThrowIfNullOrWhiteSpace(this string? value, string parameterName, string? message = null)
		{
			if (value is null)
				if(message is null)
					throw new ArgumentNullException($"The property {parameterName} is null.");
				else
					throw new ArgumentNullException(message, (Exception?) null);

			if (string.IsNullOrWhiteSpace(value))
				if (message is null)
					throw new ArgumentException($"The property {parameterName} is empty or if only white spaces.");
				else
					throw new ArgumentException(message, (Exception?) null);

			return value.NullToString();
		}
	}
}
