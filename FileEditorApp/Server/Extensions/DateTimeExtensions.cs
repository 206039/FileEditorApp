using System;

namespace FileEditorApp.Server.Extensions
{
    public static class DateTimeExtensions
    {
        public static long ToTimestamp(this DateTime dateTime)
        {
            var unixTimestamp = (dateTime.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return (long)unixTimestamp;
        }
    }
}
