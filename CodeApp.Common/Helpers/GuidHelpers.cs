using System;

namespace CodeApp.Common.Helpers
{
    public class GuidHelpers
    {
        private static bool _isFrozen;
        private static Guid? _guidSet;
        
        public static void Freeze(Guid guid)
        {
            _isFrozen = true;
            _guidSet = guid;
        }

        public static void UnFreeze()
        {
            _isFrozen = false;
            _guidSet = null;
        }

        public static Guid New()
        {
            if (_isFrozen)
            {
                return _guidSet ?? Guid.NewGuid();
            }
            return Guid.NewGuid();
        }
    }
}