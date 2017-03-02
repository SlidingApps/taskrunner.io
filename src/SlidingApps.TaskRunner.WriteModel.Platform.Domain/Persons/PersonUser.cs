
using SlidingApps.TaskRunner.Domain.WriteModel.Platform.Persons.Intents;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Encryption;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons;
using SlidingApps.TaskRunner.WriteModel.Platform.Domain.Model.Persons.Intents;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Domain.Persons
{
    public class PersonUser
        : DomainEntity<Guid, Entities.PersonUser>
    {
        public PersonUser(Entities.PersonUser entity)
        {
            this.entity = entity;
        }

        public virtual string Name
        {
            get { return this.entity.Name; }
            private set { this.entity.Name = value; }
        }

        public virtual string Password
        {
            get { return this.entity.Password; }
            private set { this.entity.Password = value; }
        }

        public virtual string Salt
        {
            get { return this.entity.Salt; }
            private set { this.entity.Salt = value; }
        }

        public virtual DateTime ValidFrom
        {
            get { return this.entity.ValidFrom; }
            private set { this.entity.ValidFrom = value; }
        }

        public virtual DateTime ValidUntil
        {
            get { return this.entity.ValidUntil; }
            private set { this.entity.ValidUntil = value; }
        }

        public PersonEvent<ChangePersonUser> Apply(PersonCommand<ChangePersonUser> command)
        {
            PersonEvent<ChangePersonUser> domainEvent = new PersonEvent<ChangePersonUser>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(PersonEvent<ChangePersonUser> domainEvent)
        {
            this.Name = domainEvent.Arguments.Name;

            var cryptor = new BlowFish(Constant.PASSWORD_ENCRYPTION_KEY);
            cryptor.IV = Constant.PASSWORD_ENCRYPTION_INIT_VECTOR.ToBytes();

            this.Salt = !string.IsNullOrEmpty(this.Salt) ? this.Salt : Guid.NewGuid().ToString().Replace("-", string.Empty).ToUpper().ToHexString();
            this.Password = cryptor.Encrypt_CBC(string.Format(Constant.PASSWORD_SALTING_TEMPLATE, domainEvent.Arguments.Password, this.Salt));

            this.DomainEvents.Add(domainEvent);
        }

        public PersonEvent<ChangePersonUserPeriod> Apply(PersonCommand<ChangePersonUserPeriod> command)
        {
            PersonEvent<ChangePersonUserPeriod> domainEvent = new PersonEvent<ChangePersonUserPeriod>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(PersonEvent<ChangePersonUserPeriod> domainEvent)
        {
            this.ValidFrom = domainEvent.Arguments.ValidFrom;
            this.ValidUntil = domainEvent.Arguments.ValidUntil;
            this.DomainEvents.Add(domainEvent);
        }
    }
}
