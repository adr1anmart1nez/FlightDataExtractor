using FlightDataExtractor.Core.Models;

namespace FlightDataExtractor.Core.Interfaces;

/// <summary>
/// An interface that defines the methods required for parsing the extracted text from
/// a PDF file with flight information into Flight and Crew objects.
/// </summary>
public interface IPdfParser
{
    /// <summary>
    /// Parses the flight data from a given page.
    /// </summary>
    /// <param name="pageText">The extracted text from the PDF page.</param>
    /// <returns>A Flight object representing the data from the extracted text.</returns>
    Flight ParseFlightData(string pageText);

    /// <summary>
    /// Parses the crew data from a given page.
    /// </summary>
    /// <param name="pageText">The extracted text from the PDF page.</param>
    /// <returns>A Crew object representing the data from the extracted text.</returns>
    Crew ParseCrewData(string pageText);
}