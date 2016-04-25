
using SlidingApps.TaskRunner.Foundation.Infrastructure;
using SlidingApps.TaskRunner.Foundation.Infrastructure.ExceptionManagement;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Logging;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace SlidingApps.TaskRunner.Foundation.Web
{
    public class ApiExceptionFilterAttribute
        : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string message;
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            if (actionExecutedContext.Exception is BusinessException)
            {
                if (actionExecutedContext.Exception is AuthorizationException)
                {
                    statusCode = HttpStatusCode.Unauthorized;
                }

                message = (actionExecutedContext.Exception as AuthorizationException).ToString();
                Logger.Log.WarnFormat(Logger.LONG_CONTENT, "business exception", message);
            }
            else if (actionExecutedContext.Exception is TechnicalException)
            {
                message = (actionExecutedContext.Exception as TechnicalException).ToString();
                Logger.Log.WarnFormat(Logger.LONG_CONTENT, "technical exception", message);
            }
            else if (actionExecutedContext.Exception is NotFoundException)
            {
                message = (actionExecutedContext.Exception as NotFoundException).ToString();
                Logger.Log.WarnFormat(Logger.LONG_CONTENT, "not found exception", message);
                statusCode = HttpStatusCode.NotFound;
            }
            else
            {
                message = actionExecutedContext.Exception.Message;
                Logger.Log.WarnFormat(Logger.LONG_CONTENT, "other exception", message);
            }

            actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(statusCode, message);
        }
    }
}
