
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace SlidingApps.TaskRunner.Foundation.Web
{
    public class JsonContentNegotiator : IContentNegotiator
    {
        private readonly JsonMediaTypeFormatter jsonFormatter;

        private readonly JsonMediaTypeFormatter halJsonFormatter;

        public JsonContentNegotiator(JsonMediaTypeFormatter jsonFormatter, JsonMediaTypeFormatter halJsonFormatter)
        {
            this.jsonFormatter = jsonFormatter;
            this.halJsonFormatter = halJsonFormatter;
        }

        public ContentNegotiationResult Negotiate(Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
        {
            ContentNegotiationResult result;

            if (request.Headers.Accept.Contains(MediaTypeWithQualityHeaderValue.Parse("application/hal+json")))
            {
                result = new ContentNegotiationResult(this.halJsonFormatter, new MediaTypeHeaderValue("application/hal+json"));
            }
            else
            {
                result = new ContentNegotiationResult(this.jsonFormatter, new MediaTypeHeaderValue("application/json"));
            }

            return result;
        }
    }
}
