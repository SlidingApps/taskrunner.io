
using System;

namespace SlidingApps.TaskRunner.Foundation.Cqrs
{
    /// <summary>
    /// The abstract base implementation of <see cref="ICommand{TResult}"/>.
    /// </summary>
    public abstract class Command
        : ICommand<ICommandResult>
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Command()
        {
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// The command identifier, also used as correlation identifier.
        /// </summary>
        public Guid Id { get; set; }
    }
}
