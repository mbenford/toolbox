using System.Collections.Generic;

namespace Toolbox.DomainEvents
{
    public interface IHandlerContainer
    {
        IEnumerable<IHandlerOf<T>> GetHandlersOf<T>() where T: IDomainEvent;
    }
}