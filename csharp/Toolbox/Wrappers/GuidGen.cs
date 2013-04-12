using System;

namespace Toolbox.Wrappers
{
    public static class GuidGen
    {
        private static Func<Guid> newGuid;

        public static Guid Empty
        {
            get { return Guid.Empty; }
        }

        public static void LockTo(Guid guid)
        {
            newGuid = () => guid;
        }

        public static Guid NewGuid()
        {
            return newGuid();
        }

        public static void Unlock()
        {
            newGuid = () => Guid.NewGuid();
        }
    }
}
