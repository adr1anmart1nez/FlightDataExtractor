using FlightDataExtractor.Core.Interfaces;
using FlightDataExtractor.Core.Models;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

namespace FlightDataExtractor.Core.Services;

public class FlightDataExtractor : IPdfExtractor
{
    private readonly IPdfParser _parser = new FlightDataParser();

    // Title of relevant pages
    private const string FlightPageTitle = "E-Jet Operational Flight Plan";
    private const string CrewBriefingPageTitle = "Flight Crew Briefing";

    public List<Flight> ExtractFlightData(string pdfPath)
    {
        var flights = new List<Flight>();
        var crewDataMap = new Dictionary<string, Crew>();

        using var pdfDoc = new PdfDocument(new PdfReader(pdfPath));
        for (var i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
        {
            var text = ExtractTextFromPage(pdfDoc, i);
            ProcessPageText(text, flights, crewDataMap);
        }

        // AssociateCrewData(flights, crewDataMap);
        return flights;
    }

    private string ExtractTextFromPage(PdfDocument pdfDoc, int pageNumber)
    {
        var page = pdfDoc.GetPage(pageNumber);
        return PdfTextExtractor.GetTextFromPage(page, new LocationTextExtractionStrategy());
    }

    private void ProcessPageText(string text, List<Flight> flights, Dictionary<string, Crew> crewDataMap)
    {
        if (text.Contains(FlightPageTitle))
        {
            var flight = _parser.ParseFlightData(text);
            if (flight != null) flights.Add(flight);
        }
        else if (text.Contains(CrewBriefingPageTitle))
        {
            var crew = _parser.ParseCrewData(text);
            if (crew != null)
            {
                // TODO: Uncomment as soon as crew have flight number
                // crewDataMap[crew.FlightNumber] = crew;
            }
        }
    }

    // Associates crews with flights using a mapping of crews and their respective flight number.
    private void AssociateCrewData(List<Flight> flights, IDictionary<string, Crew> crewDataMap)
    {
        foreach (var flight in flights)
        {
            if (crewDataMap.TryGetValue(flight.FlightNumber, out var crew))
            {
                flight.Crew = crew;
            }
        }
    }
}