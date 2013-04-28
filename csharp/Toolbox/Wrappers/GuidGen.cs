using System;

namespace Toolbox.Wrappers
{
    /// <summary>
    /// Represents a GUID generator that can be used in unit tests
    /// </summary>
    public static class GuidGen
    {
        private static Func<Guid> newGuid;

        /// <summary>
        /// Returns a read-only instance of Guid structure whose value is all zeroes
        /// </summary>
        public static Guid Empty
        {
            get { return Guid.Empty; }
        }

        /// <summary>
        /// Locks the Guid generation to a specified value. Should be used only in unit tests
        /// </summary>
        /// <param name="guid">The Guid value to lock the generation to</param>
        public static void LockTo(Guid guid)
        {
            newGuid = () => guid;
        }

        /// <summary>
        /// Generates a new Guid
        /// </summary>
        /// <returns>A new, unique Guid</returns>
        public static Guid NewGuid()
        {
            return newGuid();
        }

        /// <summary>
        /// Unlocks the Guid generation, making it unique again. Should be used only in unit tests
        /// </summary>
        public static void Unlock()
        {
            newGuid = Guid.NewGuid;
        }
    }
}
