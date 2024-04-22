using System.Globalization;

namespace FlightDataExtractor.Core.Services;

/// <summary>
/// Provides utility functions for formatting dates and other values.
/// </summary>
public static class Formatter
{
    private const string OldFormat = "ddMMMyy";
    private const string NewFormat = "yyyy-MM-dd";

    /// <summary>
    /// Formats a date string from "ddMMMyy" format to "yyyy-MM-dd" format.
    /// </summary>
    /// <param name="date">The date string to format.</param>
    /// <returns>The date in "yyyy-MM-dd" format.</returns>
    /// <exception cref="ArgumentException">Thrown when the input string is not in the expected format.</exception>
    public static string FormatDateString(string date)
    {
        try
        {
            var parsedDate = DateTime.ParseExact(date, OldFormat, CultureInfo.InvariantCulture);
            return parsedDate.ToString(NewFormat);
        }
        catch (FormatException ex)
        {
            throw new ArgumentException($"The date string is not in the '{OldFormat}' format.", ex);
        }
    }
}