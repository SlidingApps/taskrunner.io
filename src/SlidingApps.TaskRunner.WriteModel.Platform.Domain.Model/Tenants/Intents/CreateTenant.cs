
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants.Intents
{
    public class CreateTenant
        : IIntent
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? ValidFrom { get; set; }

        public DateTime? ValidUntil { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }
    }
}
