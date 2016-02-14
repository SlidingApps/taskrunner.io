
using System;
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Commands;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Extension;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using MediatR;
using NHibernate;
using System.Linq;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons
{
    public class PersonService :
        ICommandHandler<CreatePerson>,
        ICommandHandler<ChangePersonName>,
        ICommandHandler<ChangePersonPeriod>
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

        public ICommandResult Handle(CreatePerson command)
        {
            Person entity = new Person(new Entities.Person(), this.validator.CreateFor<Person>());
            var result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.Save(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }

        public ICommandResult Handle(ChangePersonName command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Person>().Where(x => x.OrganizationId == command.OrganizationId && x.Id == command.PersonId).Single();
            Person entity = new Person(existing, this.validator.CreateFor<Person>());
            var result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.SaveOrUpdate(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }

        public ICommandResult Handle(ChangePersonPeriod command)
        {
            var existing = this.queryProvider.CreateQuery<Entities.Person>().Where(x => x.OrganizationId == command.OrganizationId && x.Id == command.PersonId).Single();
            Person entity = new Person(existing, this.validator.CreateFor<Person>());
            var result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.SaveOrUpdate(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }
    }
}
