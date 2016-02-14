
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Organizations.Commands
{
    public class CreateOrganization 
        : Command
    {
        public CreateOrganization()
            : base()
        { }

        public CreateOrganization(string code, string name, string description, DateTime? validFrom, DateTime? validUntil)
            : this()
        {
            this.Code = code;
            this.Name = name;
            this.Description = description;
            this.ValidFrom = validFrom;
            this.ValidUntil = validUntil;
        }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? ValidFrom { get; set; }

        public DateTime? ValidUntil { get; set; }
    }
}
