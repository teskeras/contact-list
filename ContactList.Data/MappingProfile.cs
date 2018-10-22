using AutoMapper;
using System.Linq;

namespace ContactList.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact, Preview>();
            CreateMap<Contact, Details>()
                .ForMember(d => d.Phones, o => o.MapFrom(src => src.Phones.Select(p => p).ToList()))
                .ForMember(d => d.Emails, o => o.MapFrom(src => src.Emails.Select(e => e).ToList()))
                .ForMember(d => d.Tags, o => o.MapFrom(src => src.Tags.Select(t => t).ToList()));
            CreateMap<PhoneDTO, Phone>().ForMember(d => d.Id, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.Number, o => o.MapFrom(src => src.Number))
                .ForMember(d => d.ContactId, o => o.MapFrom(src => src.ContactId))
                .ForMember(d => d.Contact, o => o.Ignore());
            CreateMap<EmailDTO, Email>().ForMember(d => d.Id, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.Address, o => o.MapFrom(src => src.Address))
                .ForMember(d => d.ContactId, o => o.MapFrom(src => src.ContactId))
                .ForMember(d => d.Contact, o => o.Ignore());
            CreateMap<TagDTO, Tag>().ForMember(d => d.Id, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.Title, o => o.MapFrom(src => src.Title))
                .ForMember(d => d.ContactId, o => o.MapFrom(src => src.ContactId))
                .ForMember(d => d.Contact, o => o.Ignore());
            CreateMap<Details, Contact>()
                .ForMember(d => d.Phones, o => o.MapFrom(src => src.Phones.Select(p => p).ToList()))
                .ForMember(d => d.Emails, o => o.MapFrom(src => src.Emails.Select(e => e).ToList()))
                .ForMember(d => d.Tags, o => o.MapFrom(src => src.Tags.Select(t => t).ToList()));
        }
    }
}
