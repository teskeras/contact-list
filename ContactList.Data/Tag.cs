using ContactList.Data.Repository;

namespace ContactList.Data
{
    public class Tag : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
