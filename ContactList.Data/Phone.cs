using ContactList.Data.Repository;

namespace ContactList.Data
{
    public class Phone : IEntity
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
