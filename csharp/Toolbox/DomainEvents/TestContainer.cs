using System;
using System.Collections.Generic;

namespace Toolbox.DomainEvents
{
    public class TestContainer : IHandlerContainer
    {
        private IDictionary<Type, object> handlers;

        public TestContainer()
        {
            handlers = new Dictionary<Type, object>();
        }

        public IEnumerable<IHandlerOf<T>> GetHandlersOf<T>() where T : IDomainEvent
        {
            var handler =  new Handler<T>();
            handlers.Add(typeof(T), handler);

            return new[] { handler };
        }

        public bool WasRaised<T>() where T: IDomainEvent
        {
            return handlers.ContainsKey(typeof (T)) && ((Handler<T>) handlers[typeof (T)]).Handled;
        }

        class Handler<T> : IHandlerOf<T> where T : IDomainEvent
        {
            public void Handle(T domainEvent)
            {
                Handled = true;
            }

            public bool Handled { get; private set; }
        }
    }
}