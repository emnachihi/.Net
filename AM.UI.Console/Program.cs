using System;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 📌 Création de deux avions
        var plane1 = new Plane
        {
            planetype = PlaneType.Airbus,
            Capacity = 200,
            ManufactureDate = new DateTime(2018, 11, 10)
        };

        var plane2 = new Plane(PlaneType.Boing, 300, DateTime.Now);

        Console.WriteLine($"Plane Type: {plane1.planetype}, Capacity: {plane1.Capacity}, Manufacture Date: {plane1.ManufactureDate}");

        // 📌 Initialisation de FlightMethods avec les données de TestData
        FlightMethods fm = new FlightMethods
        {
            Flights = TestData.listFlights
        };

        // 📌 1. Tester `GetFlights`
        Console.WriteLine("\n📌  q8 Filtering flights by Destination (Paris):");
        foreach (var flight in fm.GetFlights("Destination", "Paris"))
        {
            Console.WriteLine($"Flight Date: {flight.flightdate}, Estimated Duration: {flight.EstimatedDuration}");
        }

        Console.WriteLine("\n📌 Filtering flights by FlightDate (2022-01-01):");
        foreach (var flight in fm.GetFlights("FlightDate", "2022-01-01"))
        {
            Console.WriteLine($"Destination: {flight.destination}, Estimated Duration: {flight.EstimatedDuration}");
        }

        Console.WriteLine("\n📌 Filtering flights by Estimated Duration (110 minutes):");
        foreach (var flight in fm.GetFlights("EstimatedDuration", "110"))
        {
            Console.WriteLine($"Destination: {flight.destination}, Flight Date: {flight.flightdate}");
        }

        // 📌 2. Tester `GetFlightDates`
        Console.WriteLine("\n📌 Flight Dates for Paris:");
        foreach (var date in fm.GetFlightDates("Paris"))
        {
            Console.WriteLine(date);
        }

        // 📌 3. Tester `GetFlightDatesWithForeach`
        Console.WriteLine("\n📌 Flight Dates for Paris (Foreach version):");
        foreach (var date in fm.GetFlightDatesWithForeach("Paris"))
        {
            Console.WriteLine(date);
        }

        // 📌 4. Tester `GetFlightDatesWithLambda`
        Console.WriteLine("\n📌 Flight Dates for Paris (Lambda version):");
        foreach (var date in fm.GetFlightDatesWithLambda("Paris"))
        {
            Console.WriteLine(date);
        }

        // 📌 5. Tester `ShowFlightDetails`
        Console.WriteLine("\n📌 Flight details for Airbus Plane:");
        fm.ShowFlightDetails(TestData.Airbusplane);

        // 📌 6. Tester `DurationAverage`
        Console.WriteLine("\n📌 Average Duration for Paris flights:");
        Console.WriteLine(fm.DurationAverage("Paris"));

        // 📌 7. Tester `OrderedDurationFlights`
        Console.WriteLine("\n📌 Flights ordered by Estimated Duration (descending):");
        foreach (Flight F in fm.OrderedDurationFlights())
        {
            Console.WriteLine($"Destination: {F.destination}, Duration: {F.EstimatedDuration}");
        }

        // 📌 8. Tester `SeniorTravellers`
        Console.WriteLine("\n📌 Oldest 3 travellers in Flight 1:");
        foreach (Traveller t in fm.SeniorTravellers(TestData.flight1))
        {
            //Console.WriteLine($"Name: {t.FirstName} {t.LastName}, BirthDate: {t.BirthDate}");
        }

        // 📌 9. Tester `DestinationGroupeFlight`
        Console.WriteLine("\n📌 Grouped Flights by Destination:");
        foreach (var group in fm.DestinationGroupeFlight())
        {
            Console.WriteLine($"Destination: {group.Key}");
            foreach (Flight F in group)
            {
                Console.WriteLine($"  Flight Date: {F.flightdate}, Estimated Duration: {F.EstimatedDuration}");
            }
        }

        // 📌 10. Tester `ProgrammedFlightNumber`
        DateTime startDate = new DateTime(2022, 01, 01);
        Console.WriteLine($"\n📌 Number of flights programmed after {startDate}: {fm.ProgrammedFlightNumber(startDate)}");

        // 📌 11. Tester `FlightDetailsDel` (Délégué)
        Console.WriteLine("\n📌 Using FlightDetailsDel delegate for Airbus Plane:");
        fm.FlightDetailsDel(TestData.Airbusplane);

        // 📌 12. Tester `DurationAverageDel` (Délégué)
        Console.WriteLine("\n📌 Using DurationAverageDel delegate for Paris:");
        Console.WriteLine(fm.DurationAverageDel("Paris"));

        //// methode d'extension 
        Console.WriteLine("\n Methode d'extension");
       


    }
}
