using AutoMapper;
using AutoMapper.QueryableExtensions;
using ContactList.Data;
using ContactList.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ContactList.Core
{
    [Produces("application/json")]
    [Route("api/contacts")]

    public class ContactListService : IContactListService
    {
        private readonly IContactRepository contactRepository;
        private readonly IEmailRepository emailRepository;
        private readonly IPhoneRepository phoneRepository;
        private readonly ITagRepository tagRepository;

        public ContactListService(IContactRepository contactRepository, IEmailRepository emailRepository, IPhoneRepository phoneRepository, ITagRepository tagRepository)
        {
            this.contactRepository = contactRepository;
            this.emailRepository = emailRepository;
            this.phoneRepository = phoneRepository;
            this.tagRepository = tagRepository;
        }

        public IEnumerable<Preview> GetList()
        {
            return contactRepository.Query().ProjectTo<Preview>().ToList();
        }

        public Details GetContact(int id)
        {
            var contact = contactRepository.Query().Include(c => c.Phones).Include(c => c.Emails).Include(c => c.Tags).FirstOrDefault(c => c.Id == id);
            return Mapper.Map<Details>(contact);
        }

        public IEnumerable<Preview> Search(string searching)
        {
            var search = searching.Trim().Split(' ').ToList();
            var result = new List<Preview>();
            foreach (var s in search)
            {
                foreach (var fn in contactRepository.Query().Include(c => c.Tags).Where(c => c.FirstName.Contains(s)).ProjectTo<Preview>())
                    if (!result.Where(c => c.Id == fn.Id).Any()) result.Add(fn);
                foreach (var ln in contactRepository.Query().Include(c => c.Tags).Where(c => c.LastName.Contains(s)).ProjectTo<Preview>())
                    if (!result.Where(c => c.Id == ln.Id).Any()) result.Add(ln);
                foreach (var t in contactRepository.Query().Include(c => c.Tags).Where(c => c.Tags.Select(t => t.Title).Any(x => x.Contains(s))).ProjectTo<Preview>())
                    if (!result.Where(c => c.Id == t.Id).Any()) result.Add(t);
            }
            return result.OrderBy(p => p.Id);
        }

        public Details CreateContact(Details details)
        {
            if (details.Phones.Select(p => p.Number).Any(n => n.Any(c => !char.IsDigit(c))) || details.Emails.Select(e => e.Address).Any(a => !(new EmailAddressAttribute().IsValid(a))))
                return null;
            details.Id = 0;
            var contact = Mapper.Map<Contact>(details);
            contactRepository.Insert(contact);
            contactRepository.Commit();
            return Mapper.Map<Details>(contact);
        }

        public Details EditContact(Details details)
        {
            if (details.Phones.Select(p => p.Number).Any(n => n.Any(c => !char.IsDigit(c))) || details.Emails.Select(e => e.Address).Any(a => !(new EmailAddressAttribute().IsValid(a))))
                return null;
            var edited = Mapper.Map<Contact>(details);
            var original = contactRepository.Query().Include(c => c.Phones).Include(c => c.Emails).Include(c => c.Tags).AsNoTracking().FirstOrDefault(c => c.Id == edited.Id);
            if (original == null) return null;
            contactRepository.Update(edited);
            foreach (var phone in original.Phones)
                if (!edited.Phones.Select(p => p.Id).Any(i => i == phone.Id))
                    this.phoneRepository.Delete(phone);
            foreach (var email in original.Emails)
                if (!edited.Emails.Select(e => e.Id).Any(i => i == email.Id))
                    this.emailRepository.Delete(email);
            foreach (var tag in original.Tags)
                if (!edited.Tags.Select(t => t.Id).Any(i => i == tag.Id))
                    this.tagRepository.Delete(tag);
            contactRepository.Commit();
            return Mapper.Map<Details>(edited);
        }

        public void DeleteContact(int id)
        {
            var contact = contactRepository.Query().FirstOrDefault(c => c.Id == id);
            if (contact == null) return;
            contactRepository.Delete(contact);
            contactRepository.Commit();
        }
    }
}
