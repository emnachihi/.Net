using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
   
    public class Staff : Passenger
    {
        public DateTime EmployementDate { get; set; }
        [DataType(DataType.Currency)] //  un salaire en monnaie
        public int Salary { get; set; }
        public string Function { get; set; }
       

        public override string? ToString()
        {
            return "DateTime"+EmployementDate+"Salary"+Salary+"Function"+Function;
        }
    }
}