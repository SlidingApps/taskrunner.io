﻿
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.WriteModel.Communication.Domain.Model;
using SlidingApps.TaskRunner.WriteModel.Communication.Domain.Model.Intent;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Communication.Domain
{
    public sealed class MailCommunicationInfo
        : Communication<MailCommunicationInfo>.ConmmunicationInfo
    {
        public string ExternalId
        {
            get { return this.Parent.GetDataEntity().Mail.ExternalId; }
            set { this.Parent.GetDataEntity().Mail.ExternalId = value; }
        }

        public string Recipient
        {
            get { return this.Parent.GetDataEntity().Mail.Recipient; }
            set { this.Parent.GetDataEntity().Mail.Recipient = value; }
        }

        public string Subject
        {
            get { return this.Parent.GetDataEntity().Mail.Subject; }
            set { this.Parent.GetDataEntity().Mail.Subject = value; }
        }

        public string TextContent
        {
            get { return this.Parent.GetDataEntity().Mail.TextContent; }
            set { this.Parent.GetDataEntity().Mail.TextContent = value; }
        }

        public string HtmlContent
        {
            get { return this.Parent.GetDataEntity().Mail.HtmlContent; }
            set { this.Parent.GetDataEntity().Mail.HtmlContent = value; }
        }

        public MailStatus Status
        {
            get { return this.Parent.GetDataEntity().Mail.Status; }
            set { this.Parent.GetDataEntity().Mail.Status = value; }
        }

        public override void SetParent(Communication<MailCommunicationInfo> parent)
        {
            base.SetParent(parent);

            if (this.Parent.GetDataEntity().Mail == null)
            {
                this.Parent.GetDataEntity().Mail = new Entities.MailCommunication(Guid.NewGuid());
                this.Parent.GetDataEntity().Mail.Communication = this.Parent.GetDataEntity();
            }
        }

        public MailEvent<SendResetPasswordLink> Apply(MailCommand<SendResetPasswordLink> command)
        {
            MailEvent<SendResetPasswordLink> domainEvent = new MailEvent<SendResetPasswordLink>(command);
            this.When(domainEvent);

            return domainEvent;
        }

        public void When(MailEvent<SendResetPasswordLink> domainEvent)
        {
            this.Parent.GetDataEntity().Id = domainEvent.Identifiers.EntityId = Guid.NewGuid();
            this.Recipient = domainEvent.Arguments.Recipient;
            this.Subject = domainEvent.Arguments.Subject;
            this.TextContent = domainEvent.Arguments.TextContentTemplate.FormatWith(domainEvent.Arguments);
            this.HtmlContent = domainEvent.Arguments.HtmlContentTemplate.FormatWith(domainEvent.Arguments);
            this.Status = domainEvent.Arguments.Status;

            this.Parent.DomainEvents.Add(domainEvent);
        }
    }
}
