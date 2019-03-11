using System;

namespace DemoMediatR.Domain
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DomainEventAttribute : Attribute
    {
        public DomainEventAttribute(string domainName, DomainEventType type)
        {
            DomainName = domainName;
            Type = type;
        }

        public DomainEventType Type { get; }
        public string DomainName { get; }
    }
}
