using System.Collections.Generic;

namespace Toolbox.DomainEvents
{
    /// <summary>
    /// Represents an event handler container
    /// </summary>
    public interface IHandlerContainer
    {
        /// <summary>
        /// Get all handlers of the provided event type
        /// </summary>
        /// <typeparam name="T">Type of the event</typeparam>
        /// <returns></returns>
        IEnumerable<IHandlerOf<T>> GetHandlersOf<T>() where T: IDomainEvent;
    }
}