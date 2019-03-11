using DemoMediatR.DomainBehaviors;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            List<Assembly> assemblies = Assembly
                                            .GetCallingAssembly()
                                            .GetReferencedAssemblies()
                                            .Select(Assembly.Load)
                                            .ToList();

            assemblies.Add(Assembly.GetCallingAssembly());
            services.AddMediatR(assemblies.ToArray());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TelemetryBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            IEnumerable<Type> types = assemblies.SelectMany(x => x.GetTypes());

            foreach (Type t in types)
            {
                if (t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>)))
                    services.AddScoped(t.GetInterface(typeof(IValidator<>).Name), t);
            }

            return services;
        }
    }
}
