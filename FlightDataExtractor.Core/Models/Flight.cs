namespace FlightDataExtractor.Core.Models;

/// <summary>
/// Represents an individual flight with all the relevant information.
/// </summary>
public class Flight
{
    public string Date { get; set; }
    public string AircraftRegistration { get; set; }
    public string RouteFrom { get; set; }
    public string RouteTo { get; set; }
    public string AlternateAirdrome1 { get; set; }
    public string AlternateAirdrome2 { get; set; }
    public string FlightNumber { get; set; }
    public string ATCCallSign { get; set; }
    public string DepartureTime { get; set; }
    public string ArrivalTime { get; set; }
    public string ZeroFuelMass { get; set; }
    public string TimeToDestination { get; set; }
    public double FuelToDestination { get; set; }
    public string TimeToAlternate { get; set; }
    public double FuelToAlternate { get; set; }
    public double MinimumFuelRequired { get; set; }
    public string RouteFirstAndLastNavigationPoint { get; set; }
    public double GainLoss { get; set; }

    public Crew Crew { get; set; }

    public override string ToString()
    {
        return FlightNumber;
    }
}