using System;
using System.Runtime.Serialization;

namespace Toolbox.DomainEvents
{
    /// <summary>
    /// The exception that is thrown when an event is raised but no event handler container is provided
    /// </summary>
    public class ContainerNotProvidedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the ContainerNotProvidedException class with a default error message
        /// </summary>
        public ContainerNotProvidedException()
            : base("No event handler container was provided")
        {
        }       
    }
}