
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;
using System.Collections.Generic;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Persons.Entities
{
    public class Person
        : AuditableDataEntity<Guid>
    {
        public virtual string EmailAddress { get; set; }

        public virtual PersonIdentity Profile { get; set; }

        public virtual PersonUser User { get; set; }

        public virtual IList<Role> Roles { get; set; }
    }
}
