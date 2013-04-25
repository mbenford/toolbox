namespace Toolbox.DomainEvents.Test
{
    public class DummyHandler2 : IHandlerOf<DummyEvent>
    {
        public void Handle(DummyEvent domainEvent)
        {
            throw new System.NotImplementedException();
        }
    }
}