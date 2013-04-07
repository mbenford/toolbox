using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Toolbox.DomainEvents.Test
{
    public class TestContainerTest
    {
        public class Provides_An_Event_Handler_And_Keeps_Track_Of_Its_Use
        {
            [Test]
            public void WasRaised_Should_Return_True_When_The_Handler_Was_Invoked()
            {
                // Arrange
                var sut = new TestContainer();
                DomainEvents.Container = sut;

                // Act
                DomainEvents.Raise(new DummyEvent());

                // Assert
                Assert.IsTrue(sut.WasRaised<DummyEvent>());
            }

            [Test]
            public void WasRaised_Should_Return_False_When_The_Handler_Wasnt_Invoked()
            {
                // Arrange
                var sut = new TestContainer();
                DomainEvents.Container = sut;

                // Assert
                Assert.IsFalse(sut.WasRaised<DummyEvent>());
            }
        }
    }
}
