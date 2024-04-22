using FlightDataExtractor.Core.Models;

namespace FlightDataExtractor.Tests;

public class FlightTest
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
    public void NumberOfFlightsInPdf()
    {
        // Pdf file has 4 flights
        Assert.That(_flights.Count, Is.EqualTo(4));
    }

    [Test]
    public void TestDate()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].Date, Is.EqualTo("2024-03-19"));
            Assert.That(_flights[1].Date, Is.EqualTo("2024-03-19"));
            Assert.That(_flights[2].Date, Is.EqualTo("2024-03-19"));
            Assert.That(_flights[3].Date, Is.EqualTo("2024-03-19"));
        });
    }
    
    [Test]
    public void TestFlightNumbers()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].FlightNumber, Is.EqualTo("LX1612"));
            Assert.That(_flights[1].FlightNumber, Is.EqualTo("LX1613"));
            Assert.That(_flights[2].FlightNumber, Is.EqualTo("LX1072"));
            Assert.That(_flights[3].FlightNumber, Is.EqualTo("LX1073"));
        });
    }

    [Test]
    public void TestRouteFrom()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].RouteFrom, Is.EqualTo("LSZH"));
            Assert.That(_flights[1].RouteFrom, Is.EqualTo("LIMC"));
            Assert.That(_flights[2].RouteFrom, Is.EqualTo("LSZH"));
            Assert.That(_flights[3].RouteFrom, Is.EqualTo("EDDF"));
        });
    }

    [Test]
    public void TestRouteTo()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].RouteTo, Is.EqualTo("LIMC"));
            Assert.That(_flights[1].RouteTo, Is.EqualTo("LSZH"));
            Assert.That(_flights[2].RouteTo, Is.EqualTo("EDDF"));
            Assert.That(_flights[3].RouteTo, Is.EqualTo("LSZH"));
        });
    }
    
        [Test]
    public void TestAircraftRegistrations()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].AircraftRegistration, Is.EqualTo("HBJVY"));
            Assert.That(_flights[1].AircraftRegistration, Is.EqualTo("HBJVY"));
            Assert.That(_flights[2].AircraftRegistration, Is.EqualTo("HBJVN"));
            Assert.That(_flights[3].AircraftRegistration, Is.EqualTo("HBJVN"));
        });
    }

    [Test]
    public void TestDepartureTimes()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].DepartureTime, Is.EqualTo("08:00"));
            Assert.That(_flights[1].DepartureTime, Is.EqualTo("09:40"));
            Assert.That(_flights[2].DepartureTime, Is.EqualTo("11:15"));
            Assert.That(_flights[3].DepartureTime, Is.EqualTo("13:45"));
        });
    }

    [Test]
    public void TestArrivalTimes()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].ArrivalTime, Is.EqualTo("08:55"));
            Assert.That(_flights[1].ArrivalTime, Is.EqualTo("10:45"));
            Assert.That(_flights[2].ArrivalTime, Is.EqualTo("12:20"));
            Assert.That(_flights[3].ArrivalTime, Is.EqualTo("14:40"));
        });
    }

    [Test]
    public void TestAtcCallSigns()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].ATCCallSign, Is.EqualTo("SWR612Q"));
            Assert.That(_flights[1].ATCCallSign, Is.EqualTo("SWR2TM"));
            Assert.That(_flights[2].ATCCallSign, Is.EqualTo("SWR2ET"));
            Assert.That(_flights[3].ATCCallSign, Is.EqualTo("SWR890M"));
        });
    }

    [Test]
    public void TestZeroFuelMasses()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].ZeroFuelMass, Is.EqualTo("34066"));
            Assert.That(_flights[1].ZeroFuelMass, Is.EqualTo("35337"));
            Assert.That(_flights[2].ZeroFuelMass, Is.EqualTo("33107"));
            Assert.That(_flights[3].ZeroFuelMass, Is.EqualTo("31536"));
        });
    }

    [Test]
    public void TestTimesToDestination()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].TimeToDestination, Is.EqualTo("0:48"));
            Assert.That(_flights[1].TimeToDestination, Is.EqualTo("0:48"));
            Assert.That(_flights[2].TimeToDestination, Is.EqualTo("0:57"));
            Assert.That(_flights[3].TimeToDestination, Is.EqualTo("0:40"));
        });
    }

    [Test]
    public void TestFuelsToDestination()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].FuelToDestination, Is.EqualTo(1.7));
            Assert.That(_flights[1].FuelToDestination, Is.EqualTo(1.7));
            Assert.That(_flights[2].FuelToDestination, Is.EqualTo(1.9));
            Assert.That(_flights[3].FuelToDestination, Is.EqualTo(1.4));
        });
    }
    
    [Test]
    public void TestTimesToAlternate()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].TimeToAlternate, Is.EqualTo("0:20"));
            Assert.That(_flights[1].TimeToAlternate, Is.EqualTo("0:39"));
            Assert.That(_flights[2].TimeToAlternate, Is.EqualTo("0:47"));
            Assert.That(_flights[3].TimeToAlternate, Is.EqualTo("0:44"));
        });
    }

    [Test]
    public void TestFuelsToAlternate()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].FuelToAlternate, Is.EqualTo(0.8));
            Assert.That(_flights[1].FuelToAlternate, Is.EqualTo(1.5));
            Assert.That(_flights[2].FuelToAlternate, Is.EqualTo(1.6));
            Assert.That(_flights[3].FuelToAlternate, Is.EqualTo(1.7));
        });
    }

    [Test]
    public void TestMinimumFuelsRequired()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].MinimumFuelRequired, Is.EqualTo(3.6));
            Assert.That(_flights[1].MinimumFuelRequired, Is.EqualTo(4.3));
            Assert.That(_flights[2].MinimumFuelRequired, Is.EqualTo(4.6));
            Assert.That(_flights[3].MinimumFuelRequired, Is.EqualTo(4.2));
        });
    }

    [Test]
    public void TestGainLoss()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].GainLoss, Is.EqualTo(0));
            Assert.That(_flights[1].GainLoss, Is.EqualTo(-40));
            Assert.That(_flights[2].GainLoss, Is.EqualTo(-96));
            Assert.That(_flights[3].GainLoss, Is.EqualTo(60));
        });
    }

    [Test]
    public void TestAlternateAirdrome()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].AlternateAirdrome1, Is.EqualTo("LIML"));
            Assert.That(_flights[0].AlternateAirdrome2, Is.EqualTo(null));
            
            Assert.That(_flights[3].AlternateAirdrome1, Is.EqualTo("LFSB"));
            Assert.That(_flights[3].AlternateAirdrome2, Is.EqualTo(null));
        });
    }

    [Test]
    public void TestNavigationPoints()
    {
        // TODO: Test fails because regex isn't working as intended
        Assert.Multiple(() =>
        {
            Assert.That(_flights[0].RouteFirstAndLastNavigationPoint, Is.EqualTo("VEBIT – RIXUV"));
            Assert.That(_flights[1].RouteFirstAndLastNavigationPoint, Is.EqualTo("PEPAG – KELIP"));
            Assert.That(_flights[2].RouteFirstAndLastNavigationPoint, Is.EqualTo("DEGES – SPESA4C"));
            Assert.That(_flights[3].RouteFirstAndLastNavigationPoint, Is.EqualTo("ANEKI1Y – RILAX"));
        });
    }
}