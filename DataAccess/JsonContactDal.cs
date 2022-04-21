using System.Collections.Generic;
using System.IO;
using FinalProjectSalihOzturk.Entities;
using Newtonsoft.Json;

namespace FinalProjectSalihOzturk.DataAccess
{
    public class JsonContactDal :IContactDal
    {
        private readonly string _dataPath = "Data.json";

        public IEnumerable<Contact> GetContacts()
        {
            if (!File.Exists(_dataPath))
            {
                File.Create(_dataPath).Close();
            }

            var serializedContacts = File.ReadAllText(_dataPath);
            var contacts = JsonConvert.DeserializeObject<IEnumerable<Contact>>(serializedContacts);

            if (contacts == null)
                return new List<Contact>();

            return contacts;
        }

        public void Save(IEnumerable<Contact> contacts)
        {
            var serializedContacts = JsonConvert.SerializeObject(contacts);
            File.WriteAllText(_dataPath, serializedContacts);
        }
    }
}