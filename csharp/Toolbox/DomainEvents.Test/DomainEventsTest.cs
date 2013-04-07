using Moq;
using NUnit.Framework;

namespace Toolbox.DomainEvents.Test
{
    public class DomainEventsTest
    {
        public class Executes_Every_Handler_Found_To_The_Provided_Event
        {
            private Mock<IHandlerOf<DummyEvent>> handler1Mock;
            private Mock<IHandlerOf<DummyEvent>> handler2Mock;
            private Mock<IHandlerOf<DummyEvent>> handler3Mock;
            private Mock<IHandlerContainer> containerMock;
            private DummyEvent dummyEvent;

            [TestFixtureSetUp]
            public void TestFixtureSetUp()
            {
                // Arrange
                handler1Mock = new Mock<IHandlerOf<DummyEvent>>();
                handler2Mock = new Mock<IHandlerOf<DummyEvent>>();
                handler3Mock = new Mock<IHandlerOf<DummyEvent>>();

                var handlers = new[] {handler1Mock.Object, handler2Mock.Object, handler3Mock.Object};

                containerMock = new Mock<IHandlerContainer>();
                containerMock.Setup(mock => mock.GetHandlersFor<DummyEvent>())
                             .Returns(handlers);

                dummyEvent = new DummyEvent();

                DomainEvents.Container = containerMock.Object;

                // Act
                DomainEvents.Raise(dummyEvent);
            }

            [Test]
            public void IHandlerContainer_GetHandlersOf_Should_Be_Called_Once()
            {
                containerMock.VerifyAll();
            }

            [Test]
            public void First_Handler_Should_Be_Invoked_Once()
            {
                handler1Mock.Verify(mock => mock.Handle(dummyEvent), Times.Once());
            }

            [Test]
            public void Second_Handler_Should_Be_Invoked_Once()
            {
                handler2Mock.Verify(mock => mock.Handle(dummyEvent), Times.Once());
            }

            [Test]
            public void Third_Handler_Should_Be_Invoked_Once()
            {
                handler3Mock.Verify(mock => mock.Handle(dummyEvent), Times.Once());
            }
        }

        public class Throws_An_Exception_When_No_Container_Is_Provided
        {
            [Test]
            public void Throws_ContainerNotProvidedException_When_Container_Is_Null()
            {
                // Arrange
                DomainEvents.Container = null;

                // Act/Assert
                Assert.Throws<ContainerNotProvidedException>(() => DomainEvents.Raise(new DummyEvent()));
            }
        }
    }
}
