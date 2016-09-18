using SlidingApps.TaskRunner.Foundation.Web;
using System;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Accounts
{
    public class NotAuthorizedException
        : AuthorizationException
    {
        /// <summary>
        ///  Initializes a new instance of the WrappedException class with a specified error message.
        ///  </summary>
        /// <param name="message">The message that describes the error.</param>
        public NotAuthorizedException(string message)
            : base(message)
        { }
    }
}
