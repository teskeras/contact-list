namespace ContactList.Data.Repository
{
    public class EmailRepository : BaseRepository<Email>, IEmailRepository
    {
        public EmailRepository(ContactListContext dbContext) : base(dbContext)
        {
        }
    }
}
