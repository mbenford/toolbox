namespace Toolbox.DomainEvents.Test
{
    public class DummyHandler3 : IHandlerOf<DummyEvent>
    {
        public void Handle(DummyEvent domainEvent)
        {
            throw new System.NotImplementedException();
        }
    }
}