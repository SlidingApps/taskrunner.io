
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Representations;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons.Queries
{
    public class PersonQuery
        : IQuery<Person>
    {
        public PersonQuery(string username)
        {
            this.Username = username;
        }

        public string Username { get; set; }
    }
}
