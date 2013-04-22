using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Toolbox.DomainEvents.Test
{
    public class DefaultContainerTest
    {
        public class Loads_All_Handlers_Of_An_Event_From_The_Provided_Assembly
        {
            private IEnumerable<IHandlerOf<DummyEvent>> result;

            [TestFixtureSetUp]
            public void TestFixtureSetUp()
            {
                // Arrange
                var sut = new DefaultContainer(Assembly.GetExecutingAssembly());

                // Act
                result = sut.GetHandlersOf<DummyEvent>();
            }

            [Test]
            public void Result_Should_Not_Be_Null()
            {
                Assert.NotNull(result);
            }

            [Test]
            public void Result_Count_Should_Be_3()
            {
                Assert.AreEqual(3, result.Count());
            }

            [Test]
            public void Result_Should_Contain_DummyHandler1()
            {
                Assert.True(result.Any(a => a.GetType() == typeof(DummyHandler1)));
            }

            [Test]
            public void Result_Should_Contain_DummyHandler2()
            {
                Assert.True(result.Any(a => a.GetType() == typeof(DummyHandler2)));
            }

            [Test]
            public void Result_Should_Contain_DummyHandler3()
            {
                Assert.True(result.Any(a => a.GetType() == typeof(DummyHandler3)));
            }

        }

        public class Does_Not_Allow_A_Container_With_An_Invalid_Assembly
        {
            [Test]
            public void Throws_ArgumentNullException_When_The_Provided_Assembly_Is_Null()
            {
                Assert.Throws<ArgumentNullException>(() => new DefaultContainer(null));
            }
        }
    }
}
