using System;

namespace TelephoneDirectory.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime Created { get; set; }
    }
}