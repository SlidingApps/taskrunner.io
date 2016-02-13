

namespace SlidingApps.TaskRunner.Foundation.Cqrs
{
    /// <summary>
    /// Wrapper used for sending <see cref="Command"/> instance over a <see cref="MediatR"/> request pipeline.
    /// </summary>
    /// <typeparam name="TCommand">The <see cref="ICommand"/> instance.</typeparam>
    public sealed class CommandMessage<TCommand>
        : ICommandMessage<TCommand, ICommandResult>
        where TCommand : ICommand<ICommandResult>
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public CommandMessage() { }

        /// <summary>
        /// Constructor with parameter.
        /// </summary>
        /// <param name="command">The <see cref="Command"/>.</param>
        public CommandMessage(TCommand command)
            : this()
        {
            this.Command = command;
        }

        /// <summary>
        /// The <see cref="Command"/>.
        /// </summary>
        public TCommand Command { get; private set; }
    }
}
