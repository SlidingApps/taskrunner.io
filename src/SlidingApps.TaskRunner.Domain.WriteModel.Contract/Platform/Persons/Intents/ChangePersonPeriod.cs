
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Intents
{
    public class ChangePersonPeriod
        : IIntent
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
