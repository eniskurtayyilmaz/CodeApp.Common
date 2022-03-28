using System;

namespace CodeApp.Common.Helpers
{
    public class ClockHelpers
    {
        private static bool _isFrozen;
        private static DateTime? _dateTimeSet;
        
        public static void Freeze()
        {
            _isFrozen = true;
        }

        public static void Freeze(DateTime dateTime)
        {
            Freeze();
            _dateTimeSet = dateTime;
        }

        public static void UnFreeze()
        {
            _isFrozen = false;
            _dateTimeSet = null;
        }

        public static void SetDateTime(DateTime dateTime)
        {
            _dateTimeSet = dateTime;
        }

        public static DateTime Now()
        {
            if (_isFrozen)
            {
                return _dateTimeSet ?? DateTime.Now;
            }
            return DateTime.Now;
        }
    }
}