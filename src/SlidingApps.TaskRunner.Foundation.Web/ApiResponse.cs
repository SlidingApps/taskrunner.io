
using SlidingApps.TaskRunner.Foundation.Cqrs;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;

namespace SlidingApps.TaskRunner.Foundation.Web
{
    public static class ApiResponse
    {
        public static HttpResponseMessage CommandResponse(ICommand<ICommandResult> command)
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Accepted,
                Content =
                    new ObjectContent(
                        typeof (object),
                        new CommandResponse(command.Id),
                        new JsonMediaTypeFormatter
                        {
                            SerializerSettings =
                                new JsonSerializerSettings
                                {
                                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                                }
                        })
            };
        }

        public static TRepresentation Found<TRepresentation>(TRepresentation representation)
            where TRepresentation : class
        {
            if (representation != default(TRepresentation))
            {
                return representation;
            }

            throw new NotFoundException();
        }

        public static HttpResponseMessage OK<TRepresentation>(TRepresentation representation)
            where TRepresentation : class
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content =
                    new ObjectContent(
                        typeof(object),
                        representation,
                        new JsonMediaTypeFormatter
                        {
                            SerializerSettings =
                                new JsonSerializerSettings
                                {
                                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                                }
                        })
            };
        }

        public static HttpResponseMessage Exception<TRepresentation>(HttpStatusCode statusCode, TRepresentation representation)
            where TRepresentation : class
        {
            return new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content =
                    new ObjectContent(
                        typeof(object),
                        representation,
                        new JsonMediaTypeFormatter
                        {
                            SerializerSettings =
                                new JsonSerializerSettings
                                {
                                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                                }
                        })
            };
        }

        public static string GetQuerystring()
        {
            List<string> values = new List<string>();

            HttpContext.Current.Request.QueryString.AllKeys.ToList()
                .ForEach(key =>
                {
                    string[] _values = HttpContext.Current.Request.QueryString.GetValues(key);
                    if (_values != null)
                    {
                        _values.ToList().ForEach(value => values.Add(string.Format("{0}={1}", key, value)));
                    }
                });

            string join = string.Join("&", values);
            string querystring = string.IsNullOrEmpty(@join) ? string.Empty : string.Format("?{0}", @join);

            return querystring;
        }
    }
}