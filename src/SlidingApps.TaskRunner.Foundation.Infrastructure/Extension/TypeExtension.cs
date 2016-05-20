
using System;
using System.Collections.Generic;
using System.Linq;

namespace SlidingApps.TaskRunner.Foundation.Infrastructure.Extension
{
    public static class TypeExtension
    {
        public static string ToFriendlyName(this Type type)
        {
            if (type.IsGenericType)
            {
                var namePrefix = type.Name.Split(new[] { '`' }, StringSplitOptions.RemoveEmptyEntries)[0];
                var genericParameters = type.GetGenericArguments().Select(ToFriendlyName).ToCsv();

                return namePrefix + "<" + genericParameters + ">";
            }

            return type.Name;
        }

        public static string ToCsv(this IEnumerable<object> collectionToConvert, string separator = ", ")
        {
            return string.Join(separator, collectionToConvert.Select(o => o.ToString()));
        }

        public static string ToDefinitionTitle(this Type type)
        {
            if (type.IsGenericType)
            {
                var namePrefix = type.Name.Split(new[] { '`' }, StringSplitOptions.RemoveEmptyEntries)[0];
                var genericParameters = type.GetGenericArguments().Select(a => a.Name).ToCsv();

                return namePrefix + "<" + genericParameters + ">";
            }

            return type.Name;
        }
    }
}
