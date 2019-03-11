using DemoMediatR.Domain;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoMediatR.DomainBehaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public ValidationBehavior(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        IServiceProvider ServiceProvider { get; }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            IValidator<TRequest> validator = ServiceProvider.GetService<IValidator<TRequest>>();

            if (validator != null)
            {
                var validationResult = await validator.ValidateAsync(request);

                    if (validationResult != null && !validationResult.IsValid)
                        throw new ValidationException("Validation failed!", validationResult.Errors);

            }
            return await next();
        }
    }
}
