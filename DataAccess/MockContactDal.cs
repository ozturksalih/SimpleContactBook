using System.Collections.Generic;
using FinalProjectSalihOzturk.Entities;

namespace FinalProjectSalihOzturk.DataAccess
{
    public class MockContactDal:IContactDal
    {
        
        public IEnumerable<Contact> GetContacts()
        {
            throw new System.NotImplementedException();
        }

        public void Save(IEnumerable<Contact> contacts)
        {
            throw new System.NotImplementedException();
        }
    }
}