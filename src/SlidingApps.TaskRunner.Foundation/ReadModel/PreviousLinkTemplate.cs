
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using ImpromptuInterface;
using System;

namespace SlidingApps.TaskRunner.Foundation.ReadModel
{
    public class PreviousLinkTemplate
        : LinkTemplate
    {
        /// <summary>
        /// The HAL+JSON link name.
        /// </summary>
        private const string LINK_NAME = "previous";

        /// <summary>
        /// Constructor with parameter.
        /// </summary>
        /// <param name="template">The HAL+JSON link template.</param>
        public PreviousLinkTemplate(string template)
            : base(PreviousLinkTemplate.LINK_NAME, template) { }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="template">The HAL+JSON link template.</param>
        /// <param name="values">The formatting values to replace the placeholders in the template.</param>
        /// <returns></returns>
        public override string Formatter(string template, IFormatValues values)
        {
            return this.Formatter(template, (IPagingFormatValues)values);
        }

        #region - Private & protected methods -

        private string Formatter(string template, IPagingFormatValues values)
        {
            var previousPageIndex = Math.Max(0, values.Page - 1);
            var linkTemplate = new PreviousLinkTemplate(template.FormatWith((new { Page = previousPageIndex, values.PageSize }).ActLike<IPagingFormatValues>()));
            string link = linkTemplate.Template.FormatWith(values);

            return link;
        }

        #endregion
    }
}
