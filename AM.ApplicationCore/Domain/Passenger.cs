using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //public int Id { get; set; }


        [Key] //clé primaire
        [StringLength(7)] //longeur exacte
        public string passportnumber { get; set; }

        [Display(Name ="Date of Birth")] //renommer
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.EmailAddress)]
        //[EmailAddress(ErrorMessage = "L'adresse email n'est pas valide")] //  Vérifie le format email
         public string EmailAdress { get; set; }

        public FullName FullName { get; set; }

        [RegularExpression("^[0.9]{8}$")] //int de 8

        public int TelNumber { get; set; }
        public ICollection<Flight> flights { get; set; }

        public static void UpperFullName()
        {
            throw new NotImplementedException();
        }

        public bool CheckProfile(string firstName, string lastName)
        {
            return FullName.FirstName == firstName && FullName.LastName == lastName;
        }


        
    
 public virtual bool CheckProfile(string firstName, string lastName, string email = null)
        {
            if (email != null)
                return FullName.FirstName == firstName && FullName.LastName == lastName && EmailAdress == email;
            else
                return FullName.FirstName == firstName && FullName.LastName == lastName;
        }
    }
}
