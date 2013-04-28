using System;
using System.Collections.Generic;

namespace Toolbox.DomainEvents
{
    /// <summary>
    /// Fakes event handlers and tracks events invocation
    /// </summary>
    public class UnitTestingContainer : IHandlerContainer
    {
        private readonly IDictionary<Type, object> handlers;

        public UnitTestingContainer()
        {
            handlers = new Dictionary<Type, object>();
        }
        
        public IEnumerable<IHandlerOf<T>> GetHandlersOf<T>() where T : IDomainEvent
        {
            Handler<T> handler = GetHandler<T>();

            if (handler == null)
            {
                handler = new Handler<T>();
                handlers.Add(typeof(T), handler);
            }

            return new[] { handler };
        }

        /// <summary>
        /// Checks if an event was raised
        /// </summary>
        /// <typeparam name="T">Type of the event</typeparam>
        /// <returns>True if the event was raised; False otherwise</returns>
        public bool WasRaised<T>() where T : IDomainEvent
        {
            var handler = GetHandler<T>();

            return handler != null && handler.Handled;
        }

        private Handler<T> GetHandler<T>() where T: IDomainEvent
        {
            Handler<T> handler = null;

            if (handlers.ContainsKey(typeof(T)))
                handler = (Handler<T>)handlers[typeof(T)];

            return handler;
        }

        /// <summary>
        /// Resets the state of an event
        /// </summary>
        /// <typeparam name="T">Type of the event</typeparam>
        public void Reset<T>() where T: IDomainEvent
        {
            var handler = GetHandler<T>();
            handler.Reset();
        }

        class Handler<T> : IHandlerOf<T> where T : IDomainEvent
        {
            public void Handle(T domainEvent)
            {
                Handled = true;
            }

            public bool Handled { get; private set; }

            public void Reset()
            {
                Handled = false;
            }
        }

    }
}