namespace ContactList.Data.Repository
{
    public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(ContactListContext dbContext) : base(dbContext)
        {
        }
    }
}
