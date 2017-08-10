using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesRegister.Models
{
    class Party
    {
        string partyname = string.Empty, address = string.Empty, city = String.Empty;

        public Party(string partyname, string address, string city)
        {
            this.Partyname = partyname;
            this.Address = address;
            this.City = city;
        }

        public string Partyname { get => partyname; set => partyname = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
    }

}
