using ContactList.Data.Repository;
using System.Collections.Generic;

namespace ContactList.Data
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string JobTitle { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
