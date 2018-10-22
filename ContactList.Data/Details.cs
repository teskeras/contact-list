using System.Collections.Generic;

namespace ContactList.Data
{
    public class Details
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string JobTitle { get; set; }
        public List<PhoneDTO> Phones { get; set; } 
        public List<EmailDTO> Emails { get; set; }
        public List<TagDTO> Tags { get; set; }
    }
}
