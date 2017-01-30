
using SlidingApps.TaskRunner.Foundation.Web;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Domain.Persons
{
    public class UnconfirmedAccountException
        : AuthorizationException
    {
        /// <summary>
        ///  Initializes a new instance of the WrappedException class with a specified error message.
        ///  </summary>
        /// <param name="message">The message that describes the error.</param>
        public UnconfirmedAccountException(string message)
            : base(message)
        { }
    }
}
