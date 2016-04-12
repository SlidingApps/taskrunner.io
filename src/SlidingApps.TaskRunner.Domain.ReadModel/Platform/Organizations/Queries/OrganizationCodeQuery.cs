
using SlidingApps.TaskRunner.Domain.ReadModel.Platform.Organizations.Representations;
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.Domain.ReadModel.Platform.Organizations.Queries
{
    public class OrganizationCodeQuery
        : IQuery<Organization>
    {
        public OrganizationCodeQuery(string code)
        {
            this.Code = code;
        }

        public string Code { get; set; }
    }
}
