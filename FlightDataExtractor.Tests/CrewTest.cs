using FlightDataExtractor.Core.Models;

namespace FlightDataExtractor.Tests;

public class CrewTest
{
    private List<Flight> _flights;

    [SetUp]
    public void Setup()
    {
        var baseDir = AppContext.BaseDirectory;
        var filepath = Path.Combine(baseDir, "sample-file.pdf");

        var extractor = new Core.Services.FlightDataExtractor();
        _flights = extractor.ExtractFlightData(filepath);
    }
    
    [Test]
    public void CrewLx1612Test()
    {
        var crew = _flights[0].Crew;
        Assert.Multiple(() => { Assert.That(crew.CrewMembers.Count(), Is.EqualTo(5)); });
    }

    [Test]
    public void CrewRolesTest()
    {
        // TODO: Test whether the crew members have the correct role
    }
    
    [Test]
    public void CrewNamesTest()
    {
        // TODO: Test whether the crew members have the correct names
    }

    [Test]
    public void CrewFlightNumberTest()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].Crew.FlightNumber, Is.EqualTo(_flights[0].FlightNumber));
            Assert.That(_flights[1].Crew.FlightNumber, Is.EqualTo(_flights[1].FlightNumber));
            Assert.That(_flights[2].Crew.FlightNumber, Is.EqualTo(_flights[2].FlightNumber));
            Assert.That(_flights[3].Crew.FlightNumber, Is.EqualTo(_flights[3].FlightNumber));
        });
    }
    
    [Test]
    public void PassengersTest()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].Crew.PassengersBusiness, Is.EqualTo(9));
            Assert.That(_flights[0].Crew.PassengersEconomy, Is.EqualTo(42));

            Assert.That(_flights[1].Crew.PassengersBusiness, Is.EqualTo(18));
            Assert.That(_flights[1].Crew.PassengersEconomy, Is.EqualTo(50));

            Assert.That(_flights[2].Crew.PassengersBusiness, Is.EqualTo(9));
            Assert.That(_flights[2].Crew.PassengersEconomy, Is.EqualTo(31));

            Assert.That(_flights[3].Crew.PassengersBusiness, Is.EqualTo(1));
            Assert.That(_flights[3].Crew.PassengersEconomy, Is.EqualTo(26));
        });
    }

    [Test]
    public void OperatingWeightTest()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].Crew.DryOperatingWeight, Is.EqualTo(28822));
            Assert.That(_flights[1].Crew.DryOperatingWeight, Is.EqualTo(28822));
            Assert.That(_flights[2].Crew.DryOperatingWeight, Is.EqualTo(28916));
            Assert.That(_flights[3].Crew.DryOperatingWeight, Is.EqualTo(28916));
        });
    }

    [Test]
    public void OperatingIndexTest()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].Crew.DryOperatingIndex, Is.EqualTo(0));
            Assert.That(_flights[1].Crew.DryOperatingIndex, Is.EqualTo(0));
            Assert.That(_flights[2].Crew.DryOperatingIndex, Is.EqualTo(68.7));
            Assert.That(_flights[3].Crew.DryOperatingIndex, Is.EqualTo(68.7));
        });
    }
}