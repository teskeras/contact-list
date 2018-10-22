using ContactList.Data;
using System.Collections.Generic;

namespace ContactList.Core
{
    public interface IContactListService
    {
        IEnumerable<Preview> GetList();
        Details GetContact(int id);
        IEnumerable<Preview> Search(string searching);
        Details CreateContact(Details details);
        Details EditContact(Details details);
        void DeleteContact(int id);
    }
}
