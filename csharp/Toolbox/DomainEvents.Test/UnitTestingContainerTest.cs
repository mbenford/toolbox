using System.Collections.Generic;
using NUnit.Framework;

namespace Toolbox.DomainEvents.Test
{
    public class UnitTestingContainerTest
    {
        public class Provides_An_Event_Handler_And_Keeps_Track_Of_Its_Use
        {
            [Test]
            public void Gets_A_Handler_For_The_Provided_Event()
            {
                // Arrange
                var sut = new UnitTestingContainer();

                // Act
                IEnumerable<IHandlerOf<DummyEvent>> result = sut.GetHandlersFor<DummyEvent>();

                // Assert
                Assert.NotNull(result);
            }                       
            
            [Test]
            public void WasRaised_Should_Return_True_When_The_Handler_Was_Invoked()
            {
                // Arrange
                var sut = new UnitTestingContainer();
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
                var sut = new UnitTestingContainer();
                DomainEvents.Container = sut;

                // Assert
                Assert.IsFalse(sut.WasRaised<DummyEvent>());
            }

            [Test]
            public void WasRaised_Should_Return_False_When_The_Handler_Is_Reset()
            {
                // Arrange
                var sut = new UnitTestingContainer();
                DomainEvents.Container = sut;
                DomainEvents.Raise(new DummyEvent());

                // Act
                sut.Reset<DummyEvent>();

                // Assert
                Assert.IsFalse(sut.WasRaised<DummyEvent>());
            }
        }
    }
}
