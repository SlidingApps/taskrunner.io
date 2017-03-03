
using RestSharp;
using RestSharp.Authenticators;
using SlidingApps.TaskRunner.Foundation.Configuration;
using System;
using System.Linq;

namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Domain.Communications
{
    internal class MailGun
    {
        internal static IRestResponse SendSimpleMessage(MailParameters parameters)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator = new HttpBasicAuthenticator("api", "key-7acae0ee311d00e8239c99e2f1d86bfb");

            RestRequest request = new RestRequest();
            request.AddParameter("domain", parameters.Domain, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", parameters.From);
            parameters.To.ToList().ForEach(x => request.AddParameter("to", MailServiceConfiguration.SandboxAddress ?? x));
            request.AddParameter("subject", parameters.Subject);
            request.AddParameter("text", parameters.Text);
            request.AddParameter("html", parameters.Html);
            request.Method = Method.POST;

            return client.Execute(request);
        }
    }
}
