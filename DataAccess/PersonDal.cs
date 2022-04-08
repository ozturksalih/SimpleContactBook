using System.Collections.Generic;
using FinalProjectSalihOzturk.Entities;

namespace FinalProjectSalihOzturk.DataAccess
{
    public class PersonDal:IPersonDal
    {
        private List<Person> _persons;
        public PersonDal()
        {
            _persons = new List<Person>
            {
                new Person {id = 1, Email = "salabi@salabi.com",Name = "salih",Surname = "ozturk",TelephoneNumber = "124"},
                new Person {id = 1, Email = "kel@salabi.com",Name = "ahmet",Surname = "ozturk",TelephoneNumber = "142"},
                new Person {id = 1, Email = "salasdfabi@salabi.com",Name = "akif",Surname = "kuz",TelephoneNumber = "124"},
                new Person {id = 1, Email = "asd@salabi.com",Name = "beko",Surname = "philips",TelephoneNumber = "3213"},
                new Person {id = 1, Email = "asdf@salabi.com",Name = "ali",Surname = "arsl",TelephoneNumber = "123"}

            };
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