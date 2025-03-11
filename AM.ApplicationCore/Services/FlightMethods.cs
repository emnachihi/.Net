using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Numerics;
using System.Xml.Xsl;
using Plane = AM.ApplicationCore.Domain.Plane;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        // Method using FOR loop
        public IEnumerable<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> dateVols = new List<DateTime>();

            for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].destination == destination)
                {
                    dateVols.Add(Flights[i].flightdate);
                }
            }

            return dateVols;
        }

        // Method using FOREACH loop
        public IEnumerable<DateTime> GetFlightDatesWithForeach(string destination)
        {
            List<DateTime> dateVols = new List<DateTime>();

            foreach (Flight f in Flights)
            {
                if (f.destination == destination)
                {
                    dateVols.Add(f.flightdate);
                }
            }

            return dateVols;
        }

        // Method using Lambda expression (LINQ)
        public IEnumerable<DateTime> GetFlightDatesWithLambda(string destination)
        {
            return Flights.Where(f => f.destination == destination)
                          .Select(f => f.flightdate);
        }

        // Method to filter flights based on a given filter type and value
        public IEnumerable<Flight> GetFlights(string filterType, string filterValue)
        {
            return filterType switch
            {
                "Destination" => Flights.Where(f => f.destination == filterValue),
                "FlightDate" => DateTime.TryParse(filterValue, out DateTime flightDate)
                    ? Flights.Where(f => f.flightdate.Date == flightDate.Date)
                    : Enumerable.Empty<Flight>(),
                "EstimatedDuration" => int.TryParse(filterValue, out int duration)
                    ? Flights.Where(f => f.EstimatedDuration == duration)
                    : Enumerable.Empty<Flight>(),
                _ => Enumerable.Empty<Flight>()
            };
        }

        // Method using LINQ to show flight details for a specific plane
        public void ShowFlightDetails(Plane plane)
        {
            //lambda
            //var flightperplane = Flights
            //                     .Where(f => f.plane == plane)
            //                     .Select(f => new { f.flightdate, f.destination });


            var query = from f in Flights
                                  where f.plane == plane
                                  select new { f.flightdate, f.destination };

            foreach (var f in query)
            {
                Console.WriteLine(f);
            }
        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var flightcount = from f in Flights
                              where (f.flightdate - startDate).TotalDays >= 0
                                    && (f.flightdate - startDate).TotalDays < 8
                              select f;

            return flightcount.Count();


            ////lambda
            //var req = TestData.listFlights
            //            .Where(f => f.flightdate > startDate    
            //            && (f.flightdate - startDate).TotalDays < 8);




        }
        public double DurationAverage(string destination)
        {
            var query = from F in Flights
                        where F.destination == destination
                        select F.EstimatedDuration;
            return query.Average();
        }
        //q13 tp2
        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var query = from F in Flights
                        orderby F.EstimatedDuration descending
                        select F;
            return query;
        }
        //q14 tp2

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            var query = from t in flight.passengers.OfType<Traveller>()
                        orderby t.BirthDate
                        select t;
            return query.Take(3);
        }
        //q15
        public IEnumerable<IGrouping<string, Flight>> DestinationGroupeFlight()
        {
            var query = from F in Flights
                        group F by F.destination;
            foreach (var g in query)
            {
                Console.WriteLine("Destination" + g.Key);
                foreach (var F in g) Console.WriteLine(F);
            }
            return query;

        }
        public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDel;

        public FlightMethods()
        {
            // Délégué pour afficher les détails des vols d'un avion donné
            FlightDetailsDel = pl =>
            {
                var query = from f in TestData.listFlights // Accès correct aux vols
                            where f.plane == pl // Utilisation correcte du paramètre pl
                            select new { f.flightdate, f.destination };

                foreach (var f in query)
                {
                    Console.WriteLine($"Date du vol: {f.flightdate}, Destination: {f.destination}");
                }
            };

            // Délégué pour calculer la durée moyenne des vols vers une destination donnée
            DurationAverageDel = destination =>
            {
                var query = from f in TestData.listFlights
                            where f.destination == destination
                            select f.EstimatedDuration;

                return query.Any() ? query.Average() : 0; // Évite une erreur si aucun vol trouvé
            };
        }
    }

}

