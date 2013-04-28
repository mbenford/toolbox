namespace Toolbox.DomainEvents
{
    /// <summary>
    /// Raises events for registered handlers
    /// </summary>
    public static class DomainEvents
    {
        /// <summary>
        /// Container of event handlers
        /// </summary>
        public static IHandlerContainer Container { get; set; }

        /// <summary>
        /// Raises an event
        /// </summary>
        /// <typeparam name="T">Type of the event</typeparam>
        /// <param name="domainEvent">Content of the event</param>
        public static void Raise<T>(T domainEvent) where T: IDomainEvent
        {
            if (Container == null) throw new ContainerNotProvidedException();

            foreach (var handler in Container.GetHandlersOf<T>())
            {
                handler.Handle(domainEvent);
            }
        }
    }
}
