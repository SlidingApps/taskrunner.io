
using MediatR;
using NHibernate;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Intents;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Extension;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System.Linq;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons
{
    public class PersonService :
        ICommandHandler<PersonCommand<CreatePerson>>,
        ICommandHandler<PersonCommand<ChangePersonName>>,
        ICommandHandler<PersonCommand<ChangePersonPeriod>>
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
            var result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.Save(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }

        public ICommandResult Handle(PersonCommand<ChangePersonName> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Person>().Where(x => x.TenantId == command.TenantId && x.Id == command.PersonId).Single();
            Person entity = new Person(existing, this.validator.CreateFor<Person>());
            var result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.SaveOrUpdate(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }

        public ICommandResult Handle(PersonCommand<ChangePersonPeriod> command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Person>().Where(x => x.TenantId == command.TenantId && x.Id == command.PersonId).Single();
            Person entity = new Person(existing, this.validator.CreateFor<Person>());
            var result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.SaveOrUpdate(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }
    }
}
