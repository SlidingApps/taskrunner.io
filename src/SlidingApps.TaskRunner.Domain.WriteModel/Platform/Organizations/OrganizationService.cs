
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Organizations.Commands;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Extension;
using SlidingApps.TaskRunner.Foundation.NHibernate;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using MediatR;
using NHibernate;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Organizations
{
    public class OrganizationService :
        ICommandHandler<CreateOrganization>
    {
        private readonly IMediator mediator;

        private readonly IQueryProvider<ISession> queryProvider;

        private readonly IDomainEntityValidatorProvider validator;

        public OrganizationService(IMediator mediator, IQueryProvider<ISession> queryProvider, IDomainEntityValidatorProvider validator)
        {
            this.mediator = mediator;
            this.queryProvider = queryProvider;
            this.validator = validator;
        }

        public ICommandResult Handle(CreateOrganization command)
        {
            Organization entity = new Organization(new Entities.Organization(), this.validator.CreateFor<Organization>());
            var result = entity.Apply(command);

            entity
                .IfValid(e => this.queryProvider.Session.Save(e.GetDataEntity()))
                .ElseThrow();

            return new CommandResult(command.Id, result);
        }
    }
}
