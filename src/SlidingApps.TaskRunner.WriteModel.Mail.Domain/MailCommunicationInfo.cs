
using SlidingApps.TaskRunner.WriteModel.Mail.Domain.Entities;
using System;

namespace SlidingApps.TaskRunner.WriteModel.Mail.Domain
{
    public sealed class MailCommunicationInfo
        : CommunicationInfo
    {
        public string ExternalId
        {
            get { return this.Parent.Mail.ExternalId; }
            private set { this.Parent.Mail.ExternalId = value; }
        }

        public string Recipient
        {
            get { return this.Parent.Mail.Recipient; }
            private set { this.Parent.Mail.Recipient = value; }
        }

        public string Content
        {
            get { return this.Parent.Mail.Content; }
            private set { this.Parent.Mail.Content = value; }
        }

        public MailStatus Status
        {
            get { return this.Parent.Mail.Status; }
            private set { this.Parent.Mail.Status = value; }
        }

        public override void SetParent(Communication communication)
        {
            base.SetParent(communication);

            if (this.Parent.Mail == null)
            {
                this.Parent.Mail = new Entities.MailCommunication(Guid.NewGuid());
                this.Parent.Mail.Communication = this.Parent;
            }
        }
    }
}
