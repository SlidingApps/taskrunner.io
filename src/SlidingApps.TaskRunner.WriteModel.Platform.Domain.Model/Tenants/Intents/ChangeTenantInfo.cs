
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Tenants.Intents
{
    public class ChangeTenantInfo
        : IIntent
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
