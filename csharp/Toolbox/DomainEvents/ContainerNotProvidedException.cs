using System;
using System.Runtime.Serialization;

namespace Toolbox.DomainEvents
{
    public class ContainerNotProvidedException : Exception
    {
        public ContainerNotProvidedException()
            : this("No event handler container was provided")
        {
        }

        public ContainerNotProvidedException(string message)
            : base(message)
        {
        }

        public ContainerNotProvidedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ContainerNotProvidedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}