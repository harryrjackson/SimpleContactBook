
using System.Collections.Generic;
using SimpleContactBook.Models;

namespace SimpleContactBook.Services
{
    public interface IContactDataService
    {
        IEnumerable<Contact> GetContacts();
        void Save(IEnumerable<Contact> contacts);
    }
}
