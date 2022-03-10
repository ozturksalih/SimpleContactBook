using System;

namespace FinalProjectSalihOzturk.Entities
{
    public class Person : IPerson
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}