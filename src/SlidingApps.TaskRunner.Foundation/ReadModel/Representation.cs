
using HalJsonNet.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace SlidingApps.TaskRunner.Foundation.ReadModel
{
    public abstract class Representation
        : IRepresentation
    {
        /// <summary>
        /// The list of HAL+JSON link templates.
        /// </summary>
        protected readonly List<LinkTemplate> templates = new List<LinkTemplate>();

        /// <summary>
        /// The formated HAL+JSON links.
        /// </summary>
        protected Dictionary<string, Link> links;

        /// <summary>
        /// Formats the links by replacing the placeholders in the templates with the supplied values in <paramref name="values"/>. 
        /// </summary>
        /// <param name="values"></param>
        public virtual void FormatLinks(IFormatValues values)
        {
            this.links = this.templates.Select(x => new { x.Name, x.Order, Link = new Link(x.Formatter(x.Template, values)) }).ToDictionary(x => x.Name, x => x.Link);
        }

        /// <summary>
        /// An operation defined in <see cref="HalJsonNet.Configuration.Interfaces.IHaveHalJsonLinks"/> which adds the HAL+JSON links to a <see cref="IRepresentation"/>.
        /// </summary>
        /// <returns></returns>
        public virtual IDictionary<string, Link> GetLinks()
        {
            return this.links;
        }
    }
}
