namespace ProlecGE.ControlPisoMX
{
    using System;

    public static class DateTimeExtensions
    {
        public static DateTime ToMexicoDateTime(this DateTime utcDateTime)
        {
            TimeZoneInfo tzi = TimeZoneConverter.TZConvert.GetTimeZoneInfo("Central Standard Time (Mexico)");
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, tzi);
        }

        public static DateTime ToUtcAsMexicoDateTime(this DateTime dateTime)
        {
            TimeZoneInfo tzi = TimeZoneConverter.TZConvert.GetTimeZoneInfo("Central Standard Time (Mexico)");
            return TimeZoneInfo.ConvertTimeToUtc(dateTime, tzi);
        }
    }
}