﻿
using SlidingApps.TaskRunner.Foundation.WriteModel;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Accounts.Intents
{
    public class CreateTenantAdminAccount
        : IIntent
    {
        public string EmailAddress { get; set; }
    }
}
