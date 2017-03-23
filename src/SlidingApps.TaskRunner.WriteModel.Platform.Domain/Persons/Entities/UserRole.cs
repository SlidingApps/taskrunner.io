
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Persons.Entities
{
    public class UserRole
        : Role
    {
        public virtual string Name { get; set; }

        public virtual string Password { get; set; }

        public virtual string Salt { get; set; }

        public virtual DateTime ValidFrom { get; set; }

        public virtual DateTime ValidUntil { get; set; }
    }
}
