using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType 
    {
        Boing,
        Airbus
    }
    public class Plane
    {
        public int PlaneId { get; set; }
        [Range(0,int.MaxValue)] //positif
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public PlaneType planetype { get; set; }
        public ICollection<Flight> flights { get; set; }
        public Plane() { }

        //  Constructeur avec paramètres
        public Plane(PlaneType pt, int capacity, DateTime date)
        {
            planetype = pt;
            Capacity = capacity;
            ManufactureDate = date;
        }

        public override string? ToString()
        {
            return "capacity" + Capacity + "ManufacturDate" + ManufactureDate;
        }
    }
}
