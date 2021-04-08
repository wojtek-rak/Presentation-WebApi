using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebApiExampleApp
{

    public record Contact(int ContactId, string Name, string Address, string City);

    //public class Contact
    //{
    //    public int ContactId { get; set; }

    //    public string Name { get; set; }

    //    public string Address { get; set; }

    //    public string City { get; set; }
    //}
}
