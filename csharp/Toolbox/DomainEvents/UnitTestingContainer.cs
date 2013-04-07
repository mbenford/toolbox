using System;
using System.Collections.Generic;

namespace Toolbox.DomainEvents
{
    public class UnitTestingContainer : IHandlerContainer
    {
        private readonly IDictionary<Type, object> handlers;

        public UnitTestingContainer()
        {
            handlers = new Dictionary<Type, object>();
        }

        public IEnumerable<IHandlerOf<T>> GetHandlersFor<T>() where T : IDomainEvent
        {
            Handler<T> handler = GetHandler<T>();

            if (handler == null)
            {
                handler = new Handler<T>();
                handlers.Add(typeof(T), handler);
            }

            return new[] { handler };
        }

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