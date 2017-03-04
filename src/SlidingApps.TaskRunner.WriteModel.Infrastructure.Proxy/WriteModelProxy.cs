//This file is auto-generated by WebApiProxy
//Any changes to this file will be overwritten
//Project site: http://github.com/faniereynders/webapiproxy

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Linq;
using System.Net;
using System.Web;
using SlidingApps.TaskRunner.WriteModel.Infrastructure.Api.Models;

#region Proxies
namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Api
{
	/// <summary>
	/// Client configuration.
	/// </summary>
	public partial class Configuration
	{
		/// <summary>
		/// Web Api Base Address.
		/// </summary>
		public static string WriteModelProxyBaseAddress = "http://localhost:8091";
		
	}
}
#endregion

#region Models
namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Api.Models
{
	public class WebApiProxyResponseException : Exception
	{
		public HttpStatusCode StatusCode { get; private set; }
		public string Content { get; private set; }

		public WebApiProxyResponseException(HttpStatusCode statusCode, string content) : base("A " + statusCode + " (" + (int)statusCode + ") http exception occured. See Content for response body.")
		{
			StatusCode = statusCode;
			Content = content;
		}
	}

	
	/// <summary>
	/// 
	/// </summary>
	public partial class SendPersonConfirmationLink
	{
		#region Constants
		#endregion

		#region Properties
		/// <summary>
		/// 
		/// </summary>
		public virtual String ConfirmationUrl { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual String UserName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual String HtmlContentTemplate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual String Recipient { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual MailStatus Status { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual String Subject { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual String TextContentTemplate { get; set; }
		#endregion
	}	
	
	/// <summary>
	/// 
	/// </summary>
	public partial class SendResetPasswordLink
	{
		#region Constants
		#endregion

		#region Properties
		/// <summary>
		/// 
		/// </summary>
		public virtual String ResetPasswordUrl { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual String UserName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual String HtmlContentTemplate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual String Recipient { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual MailStatus Status { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual String Subject { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual String TextContentTemplate { get; set; }
		#endregion
	}	
	
	/// <summary>
	/// 
	/// </summary>
	public partial class SendTenantConfirmationLink
	{
		#region Constants
		#endregion

		#region Properties
		/// <summary>
		/// 
		/// </summary>
		public virtual String ConfirmationUrl { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual String Code { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual String HtmlContentTemplate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual String Recipient { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual MailStatus Status { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual String Subject { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual String TextContentTemplate { get; set; }
		#endregion
	}	

	
	/// <summary>
	/// 
	/// </summary>
	public enum MailStatus
	{

		/// <summary>
		/// 
		/// </summary>
		NOT_SPECIFIED = 0,

		/// <summary>
		/// 
		/// </summary>
		QUEUED = 1,

		/// <summary>
		/// 
		/// </summary>
		FAILED = 2,

		/// <summary>
		/// 
		/// </summary>
		BOUNCED = 3,

		/// <summary>
		/// 
		/// </summary>
		DELIVERED = 4,
		
	}
	
}
#endregion

#region Interfaces
namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Api.Interfaces
{
	public interface IClientBase : IDisposable
	{
		HttpClient HttpClient { get; }
	}

	
	public partial interface IMailManagementClient : IClientBase
	{	

		/// <returns></returns>
		Task<HttpResponseMessage> PostSendTenantConfirmationLinkAsync(SendTenantConfirmationLink intent);

		/// <returns></returns>
		HttpResponseMessage PostSendTenantConfirmationLink(SendTenantConfirmationLink intent);

		/// <returns></returns>
		Task<HttpResponseMessage> PostSendAccountConfirmationLinkAsync(SendPersonConfirmationLink intent);

		/// <returns></returns>
		HttpResponseMessage PostSendAccountConfirmationLink(SendPersonConfirmationLink intent);

		/// <returns></returns>
		Task<HttpResponseMessage> PostSendResetPasswordLinkAsync(SendResetPasswordLink intent);

		/// <returns></returns>
		HttpResponseMessage PostSendResetPasswordLink(SendResetPasswordLink intent);
				
	}
	
	public partial interface IServiceHealthClient : IClientBase
	{	

		/// <returns></returns>
		Task<HttpResponseMessage> GetAsync();

		/// <returns></returns>
		Boolean Get();
				
	}
	
	public partial interface IServiceManagementClient : IClientBase
	{	

		/// <returns></returns>
		Task<HttpResponseMessage> GetAsync();

		/// <returns></returns>
		Boolean Get();
				
	}

}
#endregion

#region Clients
namespace SlidingApps.TaskRunner.WriteModel.Infrastructure.Api.Clients
{
	/// <summary>
	/// Client base class.
	/// </summary>
	public abstract partial class ClientBase : IDisposable
	{
		/// <summary>
		/// Gests the HttpClient.
		/// </summary>
		public HttpClient HttpClient { get; protected set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ClientBase"/> class.
		/// </summary>
		protected ClientBase()
		{
			HttpClient = new HttpClient()
			{
				BaseAddress = new Uri(Configuration.WriteModelProxyBaseAddress)
			};
		}

		public virtual void EnsureSuccess(HttpResponseMessage response)
		{			
			if (response.IsSuccessStatusCode)				
				return;
													
			var content = response.Content.ReadAsStringAsync().Result;
			throw new WebApiProxyResponseException(response.StatusCode, content);			
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ClientBase"/> class.
		/// </summary>
		/// <param name="handler">The handler.</param>
		/// <param name="disposeHandler">if set to <c>true</c> [dispose handler].</param>
		protected ClientBase(HttpMessageHandler handler, bool disposeHandler = true)
		{
			HttpClient = new HttpClient(handler, disposeHandler)
			{
				BaseAddress = new Uri(Configuration.WriteModelProxyBaseAddress)
			};
		}

		/// <summary>
		/// Releases the unmanaged resources and disposes of the managed resources.       
		/// </summary>
		public void Dispose()
		{
			HttpClient.Dispose();
		}
	}
	/// <summary>
	/// 
	/// </summary>
	public partial class MailManagementClient : ClientBase, Interfaces.IMailManagementClient
	{		

		/// <summary>
		/// 
		/// </summary>
		public MailManagementClient() : base()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public MailManagementClient(HttpMessageHandler handler, bool disposeHandler = true) : base(handler, disposeHandler)
		{
		}

		#region Methods
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual async Task<HttpResponseMessage> PostSendTenantConfirmationLinkAsync(SendTenantConfirmationLink intent)
		{
			return await HttpClient.PostAsJsonAsync<SendTenantConfirmationLink>("command/mail/tenantconfirmation", intent);
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual HttpResponseMessage PostSendTenantConfirmationLink(SendTenantConfirmationLink intent)
		{
						 var result = Task.Run(() => PostSendTenantConfirmationLinkAsync(intent)).Result;		 
			 
			EnsureSuccess(result);
				 
			 			 			 
			 return result.Content.ReadAsAsync<HttpResponseMessage>().Result;
			 		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual async Task<HttpResponseMessage> PostSendAccountConfirmationLinkAsync(SendPersonConfirmationLink intent)
		{
			return await HttpClient.PostAsJsonAsync<SendPersonConfirmationLink>("command/mail/accountconfirmation", intent);
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual HttpResponseMessage PostSendAccountConfirmationLink(SendPersonConfirmationLink intent)
		{
						 var result = Task.Run(() => PostSendAccountConfirmationLinkAsync(intent)).Result;		 
			 
			EnsureSuccess(result);
				 
			 			 			 
			 return result.Content.ReadAsAsync<HttpResponseMessage>().Result;
			 		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual async Task<HttpResponseMessage> PostSendResetPasswordLinkAsync(SendResetPasswordLink intent)
		{
			return await HttpClient.PostAsJsonAsync<SendResetPasswordLink>("command/mail/passwordlink", intent);
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual HttpResponseMessage PostSendResetPasswordLink(SendResetPasswordLink intent)
		{
						 var result = Task.Run(() => PostSendResetPasswordLinkAsync(intent)).Result;		 
			 
			EnsureSuccess(result);
				 
			 			 			 
			 return result.Content.ReadAsAsync<HttpResponseMessage>().Result;
			 		}

		#endregion
	}
	/// <summary>
	/// 
	/// </summary>
	public partial class ServiceHealthClient : ClientBase, Interfaces.IServiceHealthClient
	{		

		/// <summary>
		/// 
		/// </summary>
		public ServiceHealthClient() : base()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public ServiceHealthClient(HttpMessageHandler handler, bool disposeHandler = true) : base(handler, disposeHandler)
		{
		}

		#region Methods
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual async Task<HttpResponseMessage> GetAsync()
		{
			return await HttpClient.GetAsync("$health");
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual Boolean Get()
		{
						 var result = Task.Run(() => GetAsync()).Result;		 
			 
			EnsureSuccess(result);
				 
			 			 			 
			 return result.Content.ReadAsAsync<Boolean>().Result;
			 		}

		#endregion
	}
	/// <summary>
	/// 
	/// </summary>
	public partial class ServiceManagementClient : ClientBase, Interfaces.IServiceManagementClient
	{		

		/// <summary>
		/// 
		/// </summary>
		public ServiceManagementClient() : base()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public ServiceManagementClient(HttpMessageHandler handler, bool disposeHandler = true) : base(handler, disposeHandler)
		{
		}

		#region Methods
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual async Task<HttpResponseMessage> GetAsync()
		{
			return await HttpClient.GetAsync("$management");
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual Boolean Get()
		{
						 var result = Task.Run(() => GetAsync()).Result;		 
			 
			EnsureSuccess(result);
				 
			 			 			 
			 return result.Content.ReadAsAsync<Boolean>().Result;
			 		}

		#endregion
	}
}
#endregion

