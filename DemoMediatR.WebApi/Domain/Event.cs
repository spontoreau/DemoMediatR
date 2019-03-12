using System;

namespace DemoMediatR.WebApi.Domain
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EventAttribute : Attribute
    {
        public EventAttribute(EventType type)
        {
            Type = type;
        }

        public EventType Type { get; }
    }
}
