using System;
using System.Collections.Generic;
using System.Text;

namespace Abner.Common.Utility
{
    public class AbnerTimeStamp
    {
        public DateTime DateTime { get; private set; }

        /// <summary>
        /// 以秒为单位记录的时间戳
        /// </summary>
        public long TimestampSeconds { get; private set; }

        /// <summary>
        /// 以毫秒为单位记录的时间戳
        /// </summary>
        public long TimestampMillSeconds { get; private set; }

        public AbnerTimeStamp(DateTime dateTime)
        {
            this.DateTime = dateTime;
            this.TimestampSeconds = (dateTime.ToUniversalTime().Ticks - 621_355_968_000_000_000) / 10_000_000;
            this.TimestampMillSeconds = (dateTime.ToUniversalTime().Ticks - 621_355_968_000_000_000) / 10_000;
        }
    }

    public class DatetimeUtility
    {
        /// <summary>
        /// 时间类型转换成时间戳类型
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static AbnerTimeStamp ToUnixTimestamp(DateTime dateTime)
        {
            return new AbnerTimeStamp(dateTime);
        }

        /// <summary>
        /// 获取当前时间的时间戳类型
        /// </summary>
        /// <returns></returns>
        public static AbnerTimeStamp CurrentUnixTimestamp()
        {
            return ToUnixTimestamp(DateTime.UtcNow);
        }

        /// <summary>
        /// 时间戳转换成时间类型
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static DateTime ToDateTime(string timestamp)
        {
            if (!long.TryParse(timestamp, out long longTimestamp))
            {
                throw new ArgumentException(timestamp);
            }

            return ToDateTime(longTimestamp);
        }

        /// <summary>
        /// 时间戳转换成时间类型
        /// </summary>
        /// <param name="timestamp">13位或10位时间戳</param>
        /// <returns></returns>
        public static DateTime ToDateTime(long timestamp)
        {
            var ticks = DateTime.Now.ToUniversalTime().Ticks - (timestamp * (timestamp.ToString().Length == 13 ? 10_000 : 10_000_000) + 621_355_968_000_000_000);
            TimeSpan ts = new TimeSpan(ticks);
            return DateTime.Now.Add(-ts);
        }
    }
}
