using System.Collections.Generic;
using FinalProjectSalihOzturk.Entities;

namespace FinalProjectSalihOzturk.DataAccess
{
    public interface IContactDal
    {
        IEnumerable<Contact> GetContacts();
        void Save(IEnumerable<Contact> contacts);
    }
}