namespace ContactList.Data.Repository
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(ContactListContext dbContext) : base(dbContext)
        {
        }
    }
}
