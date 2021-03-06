﻿using DemoMediatR.WebApi.Domain;
using MediatR;
using Microsoft.ApplicationInsights;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace DemoMediatR.WebApi.Behaviors
{
    public class TelemetryBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var reponse = await next();            
            
            var attribute = request
                .GetType()
                .GetCustomAttributes()
                .SingleOrDefault(a => a.GetType() == typeof(EventAttribute)) as EventAttribute;

            if(attribute !=  null)
            {
                TelemetryClient telemetryClient = new TelemetryClient();
                var properties = new Dictionary<string, string>
                {
                    { "Name", request.GetType().Name },
                    { "Content", JsonConvert.SerializeObject(request) }
                };
                telemetryClient.TrackEvent(attribute.Type.ToString(), properties);
            }
            
            return reponse;
        }
    }
}
