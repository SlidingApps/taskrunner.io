
using System;
using System.Text.RegularExpressions;
using System.Web.Routing;

namespace SlidingApps.TaskRunner.Foundation.Infrastructure.Extension
{
    public static class StringExtension
    {
        public static string FormatWith(this string format, object source)
        {
            return FormatWith(format, null, source);
        }

        public static string FormatWith(this string format, IFormatProvider provider, object source)
        {
            Argument.StringIsRequired(format, "format");            

            var properties = new RouteValueDictionary(source);
            foreach (var key in properties.Keys)
            {
                format = Regex.Replace(format, "{" + key + "}", properties[key] != null ? properties[key].ToString() : string.Empty, RegexOptions.IgnoreCase);
            }

            return format;
        }
    }
}
