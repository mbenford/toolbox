using System.Collections.Generic;
using Ninject;

namespace Toolbox.DomainEvents.Ninject
{
    /// <summary>
    /// Gets event handlers from a Ninject kernel
    /// </summary>
    public class NinjectContainer : IHandlerContainer
    {
        private readonly IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the NinjectContainer class
        /// </summary>
        /// <param name="kernel">Ninject kernel to be used for getting event handlers</param>
        public NinjectContainer(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public IEnumerable<IHandlerOf<T>> GetHandlersOf<T>() where T : IDomainEvent
        {
            return kernel.GetAll<IHandlerOf<T>>();
        }
    }
}
