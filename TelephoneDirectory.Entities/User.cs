using System;
using System.Collections.Generic;

namespace TelephoneDirectory.Entities
{
    public class User
    {
        public User()
        {
            PhoneNumbers = new List<TelephoneNumber>();
            Name = string.Empty;
            Address = string.Empty;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime Created { get; set; }

        public List<TelephoneNumber> PhoneNumbers { get; set; }
    }
}