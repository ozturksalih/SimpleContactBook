using System.Collections.Generic;
using FinalProjectSalihOzturk.Entities;

namespace FinalProjectSalihOzturk.DataAccess
{
    public interface IPersonDal
    {
        bool Add(Person person);
        bool Delete(Person person);
        Person GetPerson(int id);
        List<Person> GetAllPersons();
    }
}