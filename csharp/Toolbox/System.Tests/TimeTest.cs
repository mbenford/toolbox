using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.Tests
{
    public class TimeTest
    {
        public class Freezes_Time_So_The_Same_Value_Is_Always_Returned
        {
            [TestCase("2013-01-01 01:00:00")]
            [TestCase("2013-01-01 02:30:00")]
            [TestCase("2100-12-31 23:59:59")]
            public void Returns_The_Same_Value_When_Time_Is_Frozen(string timeAsString)
            {
                // Arrange
                var time = DateTime.Parse(timeAsString, CultureInfo.InvariantCulture);

                // Act
                Time.Freeze(time);

                // Assert
                Assert.AreEqual(time, Time.Now);
            }
        }

        public class Unfreezes_Time_So_The_Latest_Value_Is_Always_Returned
        {            
        }
    }

    public static class Time
    {
        private static DateTime _time;
        
        public static void Freeze(DateTime time)
        {
            _time = time;
        }

        public static DateTime Now
        {
            get { return _time; }
        }
    }
}
