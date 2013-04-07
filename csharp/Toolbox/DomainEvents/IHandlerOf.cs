namespace Toolbox.DomainEvents
{
    public interface IHandlerOf<T> where T : IDomainEvent
    {
        void Handle(T domainEvent);
    }
}