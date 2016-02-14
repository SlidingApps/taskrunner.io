
using System;

namespace SlidingApps.TaskRunner.Api.WriteModel.V1.Platform.Persons
{
    public class CreatePerson
    {
        public string Name { get; set; }

        public string FirstName { get; set; }

        public string Info { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
