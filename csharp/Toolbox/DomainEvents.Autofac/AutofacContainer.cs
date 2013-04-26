using System.Collections.Generic;
using Autofac;

namespace Toolbox.DomainEvents.Autofac
{
    public class AutofacContainer : IHandlerContainer
    {
        private readonly IContainer container;

        public AutofacContainer(IContainer container)
        {
            this.container = container;
        }

        public IEnumerable<IHandlerOf<T>> GetHandlersOf<T>() where T : IDomainEvent
        {            
            return container.Resolve<IEnumerable<IHandlerOf<T>>>();
        }
    }
}
