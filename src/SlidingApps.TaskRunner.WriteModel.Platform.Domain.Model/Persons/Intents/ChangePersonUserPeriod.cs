
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons.Intents
{
    public class ChangePersonUserPeriod
        : IIntent
    {
        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }
    }
}
