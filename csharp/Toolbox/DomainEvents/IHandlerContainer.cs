using System.Collections.Generic;

namespace Toolbox.DomainEvents
{
    public interface IHandlerContainer
    {
        IEnumerable<IHandlerOf<T>> GetHandlersFor<T>() where T: IDomainEvent;
    }
}