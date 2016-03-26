﻿
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Tenants.Intents
{
    public class SetTenantOwner
        : IIntent
    {
        public SetTenantOwner() { }

        public SetTenantOwner(string emailAddress)
            : base()
        {
            this.EmailAddress = emailAddress;
        }

        public string EmailAddress { get; set; }
    }
}
