using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Traveller : Passenger
    {
        public string HealthInformation { get; set; }
        public string Nationality { get; set; }

        public override bool CheckProfile(string firstName, string lastName, string email = null)
        {
            if (email != null)
                return FullName.FirstName == firstName && FullName.LastName == lastName && EmailAdress == email;
            else
                return FullName.FirstName == firstName && FullName.LastName == lastName;
        }


        public override string? ToString()
        {
            return "healthInformation"+HealthInformation+"Nationality"+Nationality;
        }
    }

} 
