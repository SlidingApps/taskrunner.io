
using SlidingApps.TaskRunner.Foundation.Infrastructure.ExceptionManagement;

namespace SlidingApps.TaskRunner.Foundation.Web
{
    public class AuthorizationException
        : BusinessException
    {
        /// <summary>
        ///  Initializes a new instance of the WrappedException class with a specified error message.
        ///  </summary>
        /// <param name="message">The message that describes the error.</param>
        public AuthorizationException(string message)
            : base(message)
        { }

        public const string UNSUPPORTED_AUTHORIZATION_SCHEME = "UNSUPPORTED_AUTHORIZATION_SCHEME";

        public const string INVALID_AUTHORIZATION_VALUE = "INVALID_AUTHORIZATION_VALUE";

        public const string INVALID_CREDENTIALS = "INVALID_CREDENTIALS";
    }
}
