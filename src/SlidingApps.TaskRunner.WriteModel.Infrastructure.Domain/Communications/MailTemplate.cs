
using FluentValidation;
using FluentValidation.Results;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.WriteModel;
using System;
using SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Communications.Entities;

namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Communications
{
    public class MailTemplate
        : DomainEntity<Guid, Infrastructure.Domain.Communications.Entities.MailTemplate>, IWithValidator<MailTemplate>
    {
        private readonly IValidator<MailTemplate> validator;

        public MailTemplate(IValidator<MailTemplate> validator)
            : base()
        {
            Argument.InstanceIsRequired(validator, "validator");

            this.validator = validator;
        }

        public MailTemplate(Infrastructure.Domain.Communications.Entities.MailTemplate entity, IValidator<MailTemplate> validator)
            : this(validator)
        {
            Argument.InstanceIsRequired(entity, "entity");

            this.entity = entity;
            if (this.entity.Info == null)
            {
                this.entity.Info = new MailTemplateInfo(Guid.NewGuid());
                this.entity.Info.MailTemplate = this.entity;
            };
        }

        private readonly static DateTime DEFAULT_VALIDFROM_DATE = new DateTime(1900, 01, 01);
        private readonly static DateTime DEFAULT_VALIDUNTIL_DATE = new DateTime(9999, 01, 01);

        public string Code
        {
            get { return this.entity.Code; }
            private set { this.entity.Code = value; }
        }

        public string Subject
        {
            get { return this.entity.Info.Subject; }
            private set { this.entity.Info.Subject = value; }
        }

        public string TextTemplate
        {
            get { return this.entity.Info.TextTemplate; }
            private set { this.entity.Info.TextTemplate = value; }
        }

        public string HtmlTemplate
        {
            get { return this.entity.Info.HtmlTemplate; }
            private set { this.entity.Info.HtmlTemplate = value; }
        }

        public ValidationResult Validate()
        {
            ValidationResult result = this.validator.Validate(this);

            return result;
        }
    }
}
