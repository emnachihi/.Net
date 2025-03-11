using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {
       IEnumerable<DateTime> GetFlightDates(string destination);
        IEnumerable<Flight> GetFlights(string filterType, string filterValue);
        void ShowFlightDetails(Plane plane);
        public int ProgrammedFlightNumber(DateTime startDate);
        double DurationAverage(string destination);
        //q13
        IEnumerable<Flight> OrderedDurationFlights();
        //q14
        IEnumerable<Traveller> SeniorTravellers(Flight flight);
        //q15 
        IEnumerable<IGrouping<string, Flight>> DestinationGroupeFlight();



    }


}
