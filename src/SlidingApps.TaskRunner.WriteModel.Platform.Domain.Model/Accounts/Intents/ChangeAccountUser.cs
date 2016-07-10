﻿
using SlidingApps.TaskRunner.Foundation.Cqrs;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Accounts.Intents
{
    public class ChangeAccountUser
        : IIntent
    {
        public string Name { get; set; }

        public string Password { get; set; }
    }
}
