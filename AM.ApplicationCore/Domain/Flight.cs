using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string destination { get; set; }
        public string departure { get; set; }
        public DateTime flightdate { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        
        [ForeignKey("planeFK")]  //foreign key ou  [ForeignKey("plane")]
        public Plane plane { get; set; }
        public int planeFK { get; set; }
        public ICollection<Passenger> passengers { get; set; }

        public override string? ToString()
        {
            return "destination"+destination+"departure"+departure;
        }
    }
}
