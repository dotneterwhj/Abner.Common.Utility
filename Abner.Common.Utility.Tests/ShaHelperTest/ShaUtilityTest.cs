using Xunit;

namespace Abner.Common.Utility.Tests.ShaHelperTest
{

    public class ShaUtilityTest
    {
        [Fact]
        public void ComputeSHA1()
        {
            Assert.Equal("4b35be0f7818df6954737ab957f691eb72a389d2", ShaUtility.ComputeSHA1("string1"));
        }

        [Fact]
        public void ComputeSHA256()
        {
            Assert.Equal("93fedde43203e0a76172135221b8636313635d7afff96a490ae9066330505d47", ShaUtility.ComputeSHA256("string1"));
        }
    }
}
