using ContactList.Data.Repository;

namespace ContactList.Data
{
    public class Email : IEntity
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
