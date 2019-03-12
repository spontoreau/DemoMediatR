using System;

namespace DemoMediatR.Domain
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EventAttribute : Attribute
    {
        public EventAttribute(string domainName, EventType type)
        {
            DomainName = domainName;
            Type = type;
        }

        public EventType Type { get; }
        public string DomainName { get; }
    }
}
