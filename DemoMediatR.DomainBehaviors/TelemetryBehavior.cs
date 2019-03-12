using DemoMediatR.Domain;
using MediatR;
using Microsoft.ApplicationInsights;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace DemoMediatR.DomainBehaviors
{
    public class TelemetryBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TelemetryClient telemetryClient = new TelemetryClient();
            var attribute = request
                .GetType()
                .GetCustomAttributes()
                .SingleOrDefault(a => a.GetType() == typeof(EventAttribute)) as EventAttribute;

            if(attribute !=  null)
            {
                var properties = new Dictionary<string, string>
                {
                    { nameof(attribute.DomainName), attribute.DomainName },
                    { "Content", JsonConvert.SerializeObject(request) }
                };
                telemetryClient.TrackEvent(attribute.Type.ToString(), properties);
            }
            
            return await next();
        }
    }
}
