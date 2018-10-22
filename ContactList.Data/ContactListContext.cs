using Microsoft.EntityFrameworkCore;

namespace ContactList.Data
{
    public class ContactListContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public ContactListContext() { }
        public ContactListContext(DbContextOptions<ContactListContext> options)
            : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source=STESKERA-W10;Initial Catalog=ContactList;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contact>().ToTable("Contacts","dbo").HasKey(c => c.Id);
            builder.Entity<Phone>().ToTable("Phones","dbo").HasKey(p => p.Id);
            builder.Entity<Phone>().HasOne(p => p.Contact).WithMany(c => c.Phones).HasForeignKey(p => p.ContactId).IsRequired();
            builder.Entity<Email>().ToTable("Emails","dbo").HasKey(e => e.Id);
            builder.Entity<Email>().HasOne(e => e.Contact).WithMany(c => c.Emails).HasForeignKey(e => e.ContactId).IsRequired();
            builder.Entity<Tag>().ToTable("Tags","dbo").HasKey(t => t.Id);
            builder.Entity<Tag>().HasOne(t => t.Contact).WithMany(c => c.Tags).HasForeignKey(t => t.ContactId).IsRequired();
        }
    }
}
