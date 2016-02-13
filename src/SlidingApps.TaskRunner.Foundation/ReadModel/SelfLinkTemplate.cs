
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;

namespace SlidingApps.TaskRunner.Foundation.ReadModel
{
    public class SelfLinkTemplate
        : LinkTemplate
    {
        private const string LINK_NAME = "self";

        public SelfLinkTemplate(string template)
            : base(LINK_NAME, template) { }

        public override string Formatter(string template, IFormatValues values)
        {
            return template.FormatWith(values);
        }
    }
}
