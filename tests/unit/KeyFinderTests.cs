using FluentAssertions;
using Xunit;

namespace JsonDictionary.Tests
{
    public class KeyFinderTests
    {
        [Fact]
        public void GeyKeys_IfEmptyJson_ShouldReturnEmptyCollection()
        {
            string json = "{ }";

            var result = json.GetKeys();

            result.Should().BeEmpty();
        }

        [Fact]
        public void GeyKeys_IfInputNull_ShouldReturnEmptyCollection()
        {
            string json = null;

            var result = json.GetKeys();

            result.Should().BeEmpty();
        }


        [Fact]
        public void GeyKeys_IfOneSimpleEntity_ShouldReturnItsName()
        {
            string json = "{\"foo\":\"bar\"}";

            var result = json.Find();

            result.Should().Contain("foo");
        }

        [Fact]
        public void GeyKeys_IfTwoSimpleEntities_ShouldReturnBoth()
        {
            string json = "{\"foo\":\"bar\", \"dupa\" : \"debug\"}";

            var result = json.Find();

            result.Should().Contain("foo", "dupa");

            result.Should().NotContain("bar", "dupa");
        }

        [Fact]
        public void GeyKeys_IfOneSimpleEntityAndOneObject_ShouldReturnBoth()
        {
            string json = "{\"foo\":\"bar\", \"dupa\" : { \"id\": \"abcdefgh\"}  }";

            var result = json.Find();

            result.Should().Contain("foo", "dupa");

            result.Should().NotContain("bar", "abcdefgh");
        }
    }
}
