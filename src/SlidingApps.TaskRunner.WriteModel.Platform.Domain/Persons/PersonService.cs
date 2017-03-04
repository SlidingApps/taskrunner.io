
using MediatR;
using NHibernate;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Intents;
using SlidingApps.TaskRunner.Foundation.Configuration;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Extension;
using SlidingApps.TaskRunner.Foundation.Infrastructure.ExceptionManagement;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using SlidingApps.TaskRunner.WriteModel.Infrastructure.Api.Clients;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons.Intents;
using System.Linq;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Persons
{
    public class PersonService :
        ICommandHandler<PersonCommand<CreatePerson>>,
        ICommandHandler<PersonCommand<ChangePersonIdentityName>>,
        ICommandHandler<PersonCommand<ChangePersonUserPeriod>>,
        ICommandHandler<PersonCommand<ChangePersonUser>>,
        ICommandHandler<PersonCommand<SendConfirmationLink>>,
        ICommandHandler<PersonCommand<SendResetPasswordLink>>
    {
        private readonly IMediator mediator;

        private readonly IQueryProvider<ISession> queryProvider;

        private readonly IDomainEntityValidatorProvider validator;

        public PersonService(IMediator mediator, IQueryProvider<ISession> queryProvider, IDomainEntityValidatorProvider validator)
        {
            this.mediator = mediator;
            this.queryProvider = queryProvider;
            this.validator = validator;
        }

        public ICommandResult Handle(PersonCommand<CreatePerson> command)
        {
            Person entity = new Person(new Entities.Person(), this.validator.CreateFor<Person>());
            PersonEvent<CreatePerson> result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.Save(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }

        public ICommandResult Handle(PersonCommand<ChangePersonIdentityName> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Person>().Where(x => x.EmailAddress == command.Key.Name || x.User.Name == command.Key.Name).Single();
            Person entity = new Person(existing, this.validator.CreateFor<Person>());
            PersonEvent<ChangePersonIdentityName> result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.SaveOrUpdate(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }

        public ICommandResult Handle(PersonCommand<ChangePersonUserPeriod> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Person>().Where(x => x.EmailAddress == command.Key.Name || x.User.Name == command.Key.Name).Single();
            Person entity = new Person(existing, this.validator.CreateFor<Person>());
            PersonEvent<ChangePersonUserPeriod> result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.SaveOrUpdate(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }
        
        public ICommandResult Handle(PersonCommand<ChangePersonUser> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Person>().Where(x => x.EmailAddress == command.Key.Name || x.User.Name == command.Key.Name).Single();
            Person entity = new Person(existing, this.validator.CreateFor<Person>());
            PersonEvent<ChangePersonUser> result = entity.User.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.SaveOrUpdate(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }

        public ICommandResult Handle(PersonCommand<SendConfirmationLink> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Person>().Where(x => x.EmailAddress == command.Intent.Name || x.User.Name == command.Intent.Name).SingleOrDefault();
            if (existing == null) throw new BusinessException("Unknown user account");

            Person entity = new Person(existing, this.validator.CreateFor<Person>());
            var result = entity.Apply(command);
            string link = MailUtils.GetLink(command.Intent.Name, entity.Link);

            entity
                .IfValid(e => this.queryProvider.Session.SaveOrUpdate(e.GetDataEntity()))
                .ElseThrow();

            using (MailManagementClient mail = new MailManagementClient())
            {
                var url = string.Format("{0}/account/{1}/confirmation/{2}", SiteConfiguration.ApplicationBaseUrl, command.Intent.Name, link);
                mail.PostSendAccountConfirmationLink(new Infrastructure.Api.Models.SendPersonConfirmationLink { ConfirmationUrl = url, Recipient = entity.EmailAddress, UserName = command.Intent.Name });
            }

            return new CommandResult(command.Id, result);
        }

        public ICommandResult Handle(PersonCommand<SendResetPasswordLink> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Person>().Where(x => x.EmailAddress == command.Intent.Name || x.User.Name == command.Intent.Name).Single();
            Person entity = new Person(existing, this.validator.CreateFor<Person>());
            PersonEvent<SendResetPasswordLink> result = entity.Apply(command);
            string link = MailUtils.GetLink(command.Intent.Name, entity.Link);

            // Delegate to the MAIL MANAGEMENT SERVICE to send a e-mail. 
            using (MailManagementClient mail = new MailManagementClient())
            {
                var url = string.Format("{0}/account/{1}/resetpassword/{2}", SiteConfiguration.ApplicationBaseUrl, command.Intent.Name, link);
                mail.PostSendResetPasswordLink(new Infrastructure.Api.Models.SendResetPasswordLink { ResetPasswordUrl = url, UserName = command.Intent.Name, Recipient = entity.EmailAddress });
            }

            return new CommandResult(command.Id, result);
        }
    }
}
