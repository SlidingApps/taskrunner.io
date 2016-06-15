
using Autofac;
using Autofac.Integration.WebApi;
using HalJsonNet;
using HalJsonNet.Serialization;
using Microsoft.Owin.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using SlidingApps.TaskRunner.Foundation.Configuration;
using SlidingApps.TaskRunner.Foundation.Infrastructure;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Logging;
using SlidingApps.TaskRunner.Foundation.Web;
using System;
using System.Net.Http.Formatting;
using System.Web.Http;
using WebApiProxy.Server;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Api.Host
{
    internal sealed class Startup
	{
	    internal readonly Type[] SERVICES = {
            typeof(ManagementController),
            typeof(TaskRunner.ReadModel.Platform.Api.Controllers.AuthorizationResourceController),
            typeof(TaskRunner.ReadModel.Platform.Api.Controllers.TenantResourceController),
            typeof(TaskRunner.ReadModel.Platform.Api.Controllers.AccountResourceController)
		};

		public void Configuration(IAppBuilder app)
		{
			try
			{
                Program.WriteMessage("Start configuration");

				var config = this.ConfigureHttp();
				var container = this.ConfigureAutofac(config);
				this.ConfigureOwin(app, config, container);
			}
			catch (Exception ex)
			{
				Logger.Log.Error(string.Format("Startup exception: {0}", ex.Message));
			}
            finally
            {
                Console.WriteLine("-----------------------------------------------------------------");
            }
		}

		private HttpConfiguration ConfigureHttp()
		{
			var urlBase = ApplicationConfiguration.Store["hal.urlBase"];
			if(string.IsNullOrEmpty(urlBase)) throw new Exception ("HAL JSON URL base not configured");

			HttpConfiguration config = new HttpConfiguration();
			config.MapHttpAttributeRoutes();

            var jsonFormatter =
                    new JsonMediaTypeFormatter
                    {
                        SerializerSettings = new JsonSerializerSettings
                        {
                            Formatting = Formatting.Indented,
                            ContractResolver = new CamelCasePropertyNamesContractResolver(),
                            NullValueHandling = NullValueHandling.Ignore
                            //,TypeNameHandling = TypeNameHandling.Objects
                        }
                    };

            var halJsonFormatter =
                new JsonMediaTypeFormatter
                {
                    SerializerSettings = new JsonSerializerSettings
                    {
                        Formatting = Formatting.Indented,
                        ContractResolver = new JsonNetHalJsonContactResolver(new HalJsonConfiguration(urlBase)),
                        NullValueHandling = NullValueHandling.Ignore
                        //,TypeNameHandling = TypeNameHandling.Objects
                    }
                };

            config.Formatters.Clear();
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter, halJsonFormatter));


            config.MessageHandlers.Add(new LoggingMessageHandler());
            config.MessageHandlers.Add(new CorsMessageHandler());
            config.RegisterProxyRoutes("$metadata");

            Program.WriteMessage("HTTP configuration DONE");

			return config;
		}

		private IContainer ConfigureAutofac(HttpConfiguration config)
		{
			IContainer container = AutofacConfig.BuildContainer();
			AutofacWebApiDependencyResolver resolver = new AutofacWebApiDependencyResolver(container);
			config.DependencyResolver = resolver;

            Program.WriteMessage("Autofac configuration DONE");

			return container;
		}

		private void ConfigureOwin(IAppBuilder app, HttpConfiguration config, IContainer container)
		{
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
			app.UseAutofacMiddleware(container);
			//app.UseAutofacWebApi(GlobalConfiguration.Configuration);

            Program.WriteMessage("OWIN configuration DONE");
		}
	}
}

