using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDirectory.Entities;

namespace TelephoneDirectory.Entities
{
    class PhoneNumbers
    {
        public PhoneNumbers()
        {
         
           PhoneNumber = new List<string>();
        }

        public int UserId { get; set; }

        public List<string> PhoneNumber { get; set; }
               
    }
}
