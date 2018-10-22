using Autofac;
using ContactList.Data.Repository;

namespace ContactList.Data
{
    public class IocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContactListContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ContactRepository>().As<IContactRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EmailRepository>().As<IEmailRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PhoneRepository>().As<IPhoneRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TagRepository>().As<ITagRepository>().InstancePerLifetimeScope();
        }
    }
}
