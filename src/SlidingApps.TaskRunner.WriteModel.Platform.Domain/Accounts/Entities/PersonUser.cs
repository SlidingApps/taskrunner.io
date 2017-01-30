
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Persons.Entities
{
    public class PersonUser
           : AuditableDataEntity<Guid>
    {
        public PersonUser()
            : base()
        {
            this.ValidFrom = Constant.DEFAULT_START_DATE;
            this.ValidUntil = Constant.DEFAULT_END_DATE;
        }

        public PersonUser(Guid id)
            : base(id)
        {
            this.ValidFrom = Constant.DEFAULT_START_DATE;
            this.ValidUntil = Constant.DEFAULT_END_DATE;
        }

        public virtual Guid AccountId { get; set; }

        public virtual string Name { get; set; }

        public virtual string Password { get; set; }

        public virtual string Salt { get; set; }

        public virtual DateTime ValidFrom { get; set; }

        public virtual DateTime ValidUntil { get; set; }

        public virtual Person Account { get; set; }
    }
}
