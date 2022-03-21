using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Abner.Common.Utility.Tests.DateTimeHelperTest
{
    public class DatetimeUtilityTest
    {
        [Fact]
        public void ToUnixTimeStamp()
        {
            var timestamp1 = DatetimeUtility.ToUnixTimestamp(DateTime.Now);
            var timestamp2 = DatetimeUtility.CurrentUnixTimestamp();

            Assert.Equal(timestamp1.TimestampSeconds, timestamp2.TimestampSeconds);
            //Assert.Equal(timestamp1.TimestampMillSeconds, timestamp2.TimestampMillSeconds);

            var t1 = DatetimeUtility.ToDateTime(timestamp1.TimestampSeconds);
            var t2 = DatetimeUtility.ToDateTime(timestamp1.TimestampMillSeconds);

            Assert.Equal(t1.ToString("yyyy-MM-dd hh:mm:ss"), t2.ToString("yyyy-MM-dd hh:mm:ss"));
        }
    }
}
