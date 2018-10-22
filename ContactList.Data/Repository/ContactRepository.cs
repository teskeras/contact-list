namespace ContactList.Data.Repository
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(ContactListContext dbContext) : base(dbContext)
        {
        }
    }
}
