
using System;

namespace SlidingApps.TaskRunner.Api.WriteModel.V1.Platform.Tenants
{
    public class CreateTenant
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? ValidFrom { get; set; }

        public DateTime? ValidUntil { get; set; }
    }
}
