using System.Linq;

namespace Toolbox.DomainEvents
{
    public static class DomainEvents
    {
        public static IHandlerContainer Container { get; set; }

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
