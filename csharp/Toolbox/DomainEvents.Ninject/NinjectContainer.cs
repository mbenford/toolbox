using System.Collections.Generic;
using Ninject;

namespace Toolbox.DomainEvents.Ninject
{
    public class NinjectContainer : IHandlerContainer
    {
        private readonly IKernel kernel;

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
