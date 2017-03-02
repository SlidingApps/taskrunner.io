
using SlidingApps.TaskRunner.Foundation.Cqrs;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Intents
{
    public class ChangePersonUserPeriod
        : IIntent
    {
        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }
    }
}
