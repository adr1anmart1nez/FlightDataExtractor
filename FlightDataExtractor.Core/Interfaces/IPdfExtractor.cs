using FlightDataExtractor.Core.Models;

namespace FlightDataExtractor.Core.Interfaces;

/// <summary>
/// An interface that defines the methods required for extracting the flight information
/// from the PDF file.
/// </summary>
public interface IPdfExtractor
{
    /// <summary>
    /// Extracts flight data from a PDF file.
    /// </summary>
    /// <param name="pdfPath">The file path of the PDF document.</param>
    /// <returns>A collection of Flight objects containing the extracted data.</returns>
    List<Flight> ExtractFlightData(string pdfPath);
}