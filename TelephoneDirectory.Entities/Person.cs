using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneDirectory.Entities
{
    public class Person
    {
        public Person()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Address = string.Empty;
            PhoneNumbers = new List<string>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public List<string> PhoneNumbers { get; set; }

    }
}
