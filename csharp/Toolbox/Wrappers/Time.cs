using System;

namespace Toolbox.Wrappers
{
    public static class Time
    {
        private static Func<DateTime> now;
        
        public static void FreezeAt(DateTime time)
        {
            now = () => time;
        }

        public static DateTime Now
        {
            get { return now(); }
        }

        public static void Unfreeze()
        {
            now = () => DateTime.Now;
        }
    }
}