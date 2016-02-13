
namespace SlidingApps.TaskRunner.Foundation.ReadModel
{
    public abstract class LinkTemplate 
        : ILinkTemplate
    {
        protected LinkTemplate(string name, string template, int order = 0)
        {
            this.Name = name;
            this.Template = template;
            this.Order = order;
        }

        public string Name { get; protected set; }

        public int Order { get; protected set; }

        public string Template { get; protected set; }

        public abstract string Formatter(string template, IFormatValues values);
    }
}
