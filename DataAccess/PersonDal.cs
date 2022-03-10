using System.Collections.Generic;
using FinalProjectSalihOzturk.Entities;

namespace FinalProjectSalihOzturk.DataAccess
{
    public class PersonDal:IPersonDal
    {
        private List<Person> _persons;
        public PersonDal()
        {
            _persons = new List<Person>();

        }

        public bool Add(Person person)
        {
            _persons.Add(person);
            return true;
        }

        public bool Delete(Person person)
        {
            var result =_persons.Remove(person);
            return result;
        }

        public Person GetPerson(int id)
        {
            var personToFind = _persons.Find(person => person.id == id);
            return personToFind ?? null;
        }

        public List<Person> GetAllPersons()
        {
            return _persons;
        }
    }
}