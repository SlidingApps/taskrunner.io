
using System.Collections.Generic;

namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Communications
{
    internal class MailParameters
    {
        private MailParameters()
            : base()
        {
            this.To = new List<string>();
        }

        internal MailParameters(string domain, string from, string subject, string text, string html, params string[] to)
            : this()
        {
            this.Domain = domain;
            this.From = from;
            this.To = new List<string>(to);
            this.Subject = subject;
            this.Text = text;
            this.Html = html;
        }

        public string Domain { get; set; }

        public string From { get; set; }

        public List<string> To { get; set; }

        public string Subject { get; set; }

        public string Text { get; set; }

        public string Html { get; set; }
    }
}
