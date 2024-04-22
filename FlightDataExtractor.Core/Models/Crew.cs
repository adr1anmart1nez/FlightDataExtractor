namespace FlightDataExtractor.Core.Models;

/// <summary>
/// Represents the crew on board of a flight.
/// </summary>
public class Crew
{
    public int PassengersBusiness { get; set; }
    public int PassengersEconomy { get; set; }
    public double DryOperatingWeight { get; set; }
    public double DryOperatingIndex { get; set; }
    public IEnumerable<CrewMember> CrewMembers { get; set; }

    public string FlightNumber { get; set; }
}

/// <summary>
/// Represents a member of the crew on board of a flight.
/// </summary>
public class CrewMember
{
    public string Name { get; set; }
    public string Role { get; set; }
}