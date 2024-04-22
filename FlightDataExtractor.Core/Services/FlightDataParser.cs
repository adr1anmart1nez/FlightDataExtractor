using System.Text.RegularExpressions;
using FlightDataExtractor.Core.Interfaces;
using FlightDataExtractor.Core.Models;

namespace FlightDataExtractor.Core.Services;

public class FlightDataParser : IPdfParser
{
    public Flight ParseFlightData(string pageText)
    {
        var flight = new Flight
        {
            Date = Formatter.FormatDateString(ParseField(pageText, @"Date:\s*(\d{2}[A-Z]{3}\d{2})")),
            AircraftRegistration = ParseField(pageText, @"Reg.:\s*([A-Z0-9]+)"),
            RouteFrom = ParseField(pageText, @"From:\s{0,15}([A-Z]{4})"),
            RouteTo = ParseField(pageText, @"To:\s{0,15}([A-Z]{4})"),
            AlternateAirdrome1 = ParseField(pageText, @"ALTN1:\s{0,15}([A-Z]{4})"),
            AlternateAirdrome2 = ParseField(pageText, @"ALTN2:\s{0,15}([A-Z]{4})"),
            FlightNumber = ParseField(pageText, @"FltNr:\s*(\w+)"),
            ATCCallSign = ParseField(pageText, @"ATC:\s*(\w+)"),
            ZeroFuelMass = ParseField(pageText, @"ZFM:\s*(\d+) kg"),
            MinimumFuelRequired = double.Parse(ParseField(pageText, @"MIN:\s*(\d{1,2}:\d{2})\s*(\d+.\d)", 2)),
        };
        
        ParseTimes(pageText, flight);
        ParseFuelData(pageText, flight);
        ParseNavigationPoints(pageText, flight);
        ParseGainLoss(pageText, flight);
        
        return flight;
    }

    public Crew ParseCrewData(string pageText)
    {
        // Ignore irrelevant crew briefing pages
        if (!pageText.Contains("Func") || !pageText.Contains("3LC")) return null;

        var crew = new Crew();
        // TODO: Parsing logic
        return crew;
    }
    
    private static string ParseField(string text, string pattern, int groupIndex = 1)
    {
        var match = Regex.Match(text, pattern);
        return match.Success ? match.Groups[groupIndex].Value : null;
    }

    private static void ParseTimes(string text, Flight flight)
    {
        var match = Regex.Match(text, @"STD:\s*(\d{2}:\d{2})\s*STA:\s*(\d{2}:\d{2})");
        if (match.Success)
        {
            flight.DepartureTime = match.Groups[1].Value;
            flight.ArrivalTime = match.Groups[2].Value;
        }
    }

    private static void ParseFuelData(string text, Flight flight)
    {
        var destPattern = Regex.Escape(flight.RouteTo) + @":\s*(\d{1,2}:\d{2})\s*(\d+\.\d+)";
        var destMatch = Regex.Match(text, destPattern);
        if (destMatch.Success)
        {
            flight.TimeToDestination = destMatch.Groups[1].Value;
            flight.FuelToDestination = double.Parse(destMatch.Groups[2].Value);
        }
        
        var altPattern = Regex.Escape(flight.AlternateAirdrome1) + @":\s*(\d{1,2}:\d{2})\s*(\d+\.\d+)";
        var altMatch = Regex.Match(text, altPattern);
        if (altMatch.Success)
        {
            flight.TimeToAlternate = altMatch.Groups[1].Value;
            flight.FuelToAlternate = double.Parse(altMatch.Groups[2].Value);
        }
    }

    private static void ParseNavigationPoints(string text, Flight flight)
    {
        // TODO: Won't match despite it working on https://regex101.com/
        var match = Regex.Match(text, @"To DEST:\s+(\S+).*\s+(\S+)(?:\S+)?$", RegexOptions.Multiline);
        if (match.Success)
        {
            Console.WriteLine("Match!");
            var firstWaypoint = match.Groups[1].Value;
            var lastWaypoint = match.Groups[2].Value;
            flight.RouteFirstAndLastNavigationPoint = $"{firstWaypoint} - {lastWaypoint}";
        }
    }

    private static void ParseGainLoss(string text, Flight flight)
    {
        var pattern = @"Gain \/ Loss:\s*(GAIN|LOSS)\s*(\d+)\$\/TON";
        var match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);
        
        if (match.Success)
        {
            var isLoss = match.Groups[1].Value.Equals("LOSS");
            var value = int.Parse(match.Groups[2].Value);
            flight.GainLoss = isLoss ? -value : value;
        }
    }
}