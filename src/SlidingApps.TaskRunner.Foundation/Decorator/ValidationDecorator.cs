
using FluentValidation;
using FluentValidation.Results;
using SlidingApps.TaskRunner.Foundation.Cqrs;
using SlidingApps.TaskRunner.Foundation.Infrastructure;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Logging;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace SlidingApps.TaskRunner.Foundation.Decorator
{
    public class ValidationDecorator<TRequest, TRequestResult>
        : IRequestHandler<TRequest, TRequestResult>
        where TRequest : IRequest<TRequestResult>
        where TRequestResult : class
    {
        private readonly IRequestHandler<TRequest, TRequestResult> handler;

        private readonly IValidator<TRequest>[] validators;

        public ValidationDecorator(IValidator<TRequest>[] validators, IRequestHandler<TRequest, TRequestResult> handler)
        {
            this.validators = validators;
            this.handler = handler;
        }

        public TRequestResult Handle(TRequest request)
        {
            string _request = request.ToJson();
            string correlationId = request is ICommand ? (request as ICommand).Id.ToString() : "__UNSPECIFIED__";

            Logger.Log.InfoFormat(Logger.CORRELATED_CONTENT, correlationId, "pipeline -> ", this.GetType().ToFriendlyName());
            Logger.Log.InfoFormat(Logger.CORRELATED_LONG_CONTENT, correlationId, "received command", _request);

            Logger.Log.InfoFormat(Logger.CORRELATED_CONTENT, correlationId, "validation started", typeof(TRequest).ToFriendlyName());
            ValidationContext context = new ValidationContext(request);

            List<ValidationFailure> failures = new List<ValidationFailure>();
            if (!this.validators.Any())
            {
                Logger.Log.WarnFormat(Logger.CORRELATED_CONTENT, correlationId, "no validators for", typeof(TRequest).ToFriendlyName());
            }
            else
            {
                failures =
                    this.validators
                        .Select(v => v.Validate(context))
                        .SelectMany(result => result.Errors)
                        .Where(f => f != null)
                        .ToList();
            }

            if (failures.Any()) throw new ValidationException((new { Request = request, Failures = failures }).ToJson(), failures);

            Logger.Log.InfoFormat(Logger.CORRELATED_CONTENT, correlationId, "validation completed", typeof(TRequest).ToFriendlyName());

            TRequestResult events = this.handler.Handle(request);

            return events;
        }
    }
}
