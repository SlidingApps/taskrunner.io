
using FluentValidation;
using FluentValidation.Results;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Domain
{
    public partial class Communication<TConmmunicationInfo>
        : DomainEntity<Guid, Entities.Communication>, IWithValidator<Communication<TConmmunicationInfo>> 
        where TConmmunicationInfo: Communication<TConmmunicationInfo>.ConmmunicationInfo, new()
    {
        private readonly IValidator<Communication<TConmmunicationInfo>> validator;

        public Communication(IValidator<Communication<TConmmunicationInfo>> validator)
            : base()
        {
            Argument.InstanceIsRequired(validator, "validator");

            this.validator = validator;
        }

        public Communication(Entities.Communication entity, IValidator<Communication<TConmmunicationInfo>> validator)
            : this(validator)
        {
            Argument.InstanceIsRequired(entity, "entity");

            this.entity = entity;
        }

        private TConmmunicationInfo info;

        public TConmmunicationInfo Info
        {
            get
            {
                if (this.info == default(TConmmunicationInfo))
                {
                    this.info = new TConmmunicationInfo();
                    this.info.SetParent(this);
                }

                return this.info;
            }
        }

        public ValidationResult Validate()
        {
            ValidationResult result = this.validator.Validate(this);

            return result;
        }
    }
}
