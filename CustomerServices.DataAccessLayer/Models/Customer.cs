using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerServices.DataAccessLayer.Models
{
    public class Customer
    {
        public Customer(string name, string address, string vatIdentyficationNumber, DateTime creationDate)
        {
            Name = name;
            Address = address;
            VatIdentyficationNumber = vatIdentyficationNumber;
            CreationDate = creationDate;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string VatIdentyficationNumber { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
