using System;
using System.Globalization;
using System.Threading;
using NUnit.Framework;

namespace Toolbox.Wrappers.Test
{
    public class TimeTest
    {
        public class Freezes_Time_So_The_Same_Value_Is_Always_Returned
        {
            [TestCase("2013-01-01 01:00:00")]
            [TestCase("2013-01-01 02:30:00")]
            [TestCase("2100-12-31 23:59:59")]
            public void Freezes_Time_To(string timeAsString)
            {
                // Arrange
                var time = DateTime.Parse(timeAsString, CultureInfo.InvariantCulture);

                // Act
                Time.FreezeAt(time);

                // Assert
                Assert.AreEqual(time, Time.Now);
            }
        }

        public class Unfreezes_Time_So_The_Latest_Value_Is_Always_Returned
        {
            [TestCase("2013-01-01 01:00:00")]
            [TestCase("2013-01-01 02:30:00")]
            [TestCase("2100-12-31 23:59:59")]
            public void Unfreezes_Time_From(string timeAsString)
            {
                // Arrange
                var time = DateTime.Parse(timeAsString, CultureInfo.InvariantCulture);
                Time.FreezeAt(time);

                // Act
                Time.Unfreeze();

                // Assert                                
                Thread.Sleep(1000); // Let's wait for one sec so time passes on
                TimeSpan difference = (DateTime.Now - Time.Now);                                
                
                Assert.Less(difference.TotalMilliseconds, 500);
            }
        }
    }
}
