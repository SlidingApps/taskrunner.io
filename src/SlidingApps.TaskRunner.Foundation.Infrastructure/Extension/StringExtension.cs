﻿
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Routing;

namespace SlidingApps.TaskRunner.Foundation.Infrastructure.Extension
{
    public static class StringExtension
    {
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static string FormatWith(this string format, object source)
        {
            Argument.StringIsRequired(format, "format");

            var properties = new RouteValueDictionary(source);
            foreach (var key in properties.Keys)
            {
                format = Regex.Replace(format, "{" + key + "}", properties[key] != null ? properties[key].ToString() : string.Empty, RegexOptions.IgnoreCase);
            }

            return format;
        }

        //public static string FormatWith(this string format, IFormatProvider provider, object source)
        //{
        //    Argument.StringIsRequired(format, "format");            

        //    var properties = new RouteValueDictionary(source);
        //    foreach (var key in properties.Keys)
        //    {
        //        format = Regex.Replace(format, "{" + key + "}", properties[key] != null ? properties[key].ToString() : string.Empty, RegexOptions.IgnoreCase);
        //    }

        //    return format;
        //}

        public static string ToHexString(this string value)
        {
            return string.Format("{0:X}", value);
        }

        public static byte[] ToBytes(this string value)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();

            return Encoding.Default.GetBytes(value);
        }

        public static string FromBytes(this byte[] value)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();

            return Encoding.Default.GetString(value);
        }

        public static string ToBase64(this string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            string result = Convert.ToBase64String(bytes);

            return result;
        }

        public static string FromBase64(this string value)
        {
            byte[] data = Convert.FromBase64String(value);
            string result = Encoding.UTF8.GetString(data);

            return result;
        }
    }
}
