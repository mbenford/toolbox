namespace Toolbox.DomainEvents
{
    /// <summary>
    /// Represents an event handler
    /// </summary>
    /// <typeparam name="T">Type of the event to be handled</typeparam>
    public interface IHandlerOf<T> where T : IDomainEvent
    {
        /// <summary>
        /// Handles the event
        /// </summary>
        /// <param name="domainEvent">Content of the event</param>
        void Handle(T domainEvent);
    }
}