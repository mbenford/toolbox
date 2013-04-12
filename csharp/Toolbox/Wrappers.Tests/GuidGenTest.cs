using System;
using NUnit.Framework;

namespace Toolbox.Wrappers.Test
{
    public class GuidGenTest
    {
        public class Locks_Guid_Generation_So_The_Same_Value_Is_Returned
        {
            [TestCase("CB879C1B-5129-49EA-87AB-60206A95171A")]
            [TestCase("F8A0449F-0F8D-4323-92A9-D07DA7840F4F")]
            [TestCase("F92CDC71-690B-4AD0-8787-1D2E96C0B80F")]
            public void Locks_Guid_Generation_To(string guidAsString)
            {
                // Arrange                
                var guid = new Guid(guidAsString);

                // Act
                GuidGen.LockTo(guid);
                                                   
                // Assert                          
                Assert.AreEqual(guid, GuidGen.NewGuid());
            }
        }

        public class Unlocks_Guid_Generation_So_A_Unique_Value_Is_Returned
        {
            [TestCase("CB879C1B-5129-49EA-87AB-60206A95171A")]
            [TestCase("F8A0449F-0F8D-4323-92A9-D07DA7840F4F")]
            [TestCase("F92CDC71-690B-4AD0-8787-1D2E96C0B80F")]
            public void Unlocks_Guid_Generation_From(string guidAsString)
            {
                // Arrange
                var guid = new Guid(guidAsString);
                GuidGen.LockTo(guid);

                // Act
                GuidGen.Unlock();

                // Assert
                Assert.AreNotEqual(guid, GuidGen.NewGuid());
            }
        }
    }
}