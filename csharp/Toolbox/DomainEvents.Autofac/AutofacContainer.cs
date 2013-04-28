using System.Collections.Generic;
using Autofac;

namespace Toolbox.DomainEvents.Autofac
{
    /// <summary>
    /// Gets event handlers from an Autofac container
    /// </summary>
    public class AutofacContainer : IHandlerContainer
    {
        private readonly IContainer container;

        /// <summary>
        /// Initializes a new instance of the AutofacContainer class
        /// </summary>
        /// <param name="container">Autofac container to be used for getting event handlers</param>
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
