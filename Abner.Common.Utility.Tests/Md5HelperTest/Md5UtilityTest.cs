using Xunit;
using System.IO;

namespace Abner.Common.Utility.Tests;

public class Md5UtilityTest
{
    [Fact]
    public void ComputeMd5()
    {
        Assert.Equal("34b577be20fbc15477aadb9a08101ff9", Md5Utility.ComputeMd5("string1"));
        Assert.Equal("20fbc15477aadb9a", Md5Utility.ComputeMd5("string1", Bits.Sixteen));
        Assert.Equal("77aadb9a", Md5Utility.ComputeMd5("string1", Bits.Eight));

        Assert.Throws<FileNotFoundException>(() =>
        {
            Md5Utility.ComputeMd5(new FileInfo(@"file not exist"));
        });

        Assert.NotNull(Md5Utility.ComputeMd5(new FileInfo(@"C:\snmp.etl")));
        Assert.NotNull(Md5Utility.ComputeMd5(new FileInfo(@"C:\snmp.etl"), Bits.Sixteen));
        Assert.NotNull(Md5Utility.ComputeMd5(new FileInfo(@"C:\snmp.etl"), Bits.Eight));

    }
}