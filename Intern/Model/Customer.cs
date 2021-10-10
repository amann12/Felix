using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intern.Model
{
    public class Customer
    {
        public int Id{ get; set; }
        public string UserName{ get; set; }
        public long PhoneNumber { get; set; }
        public string EmailId{ get; set; }
        public string Role{ get; set; }
        public string Address{ get; set; }

    }
}
