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
        public void GeyKeys_IfOneSimpleEntityButNumber_ShouldReturnItsName()
        {
            string json = "{\"id\" : 13}";

            var result = json.Find();

            string[] expected = new[] { "id" };
            result.Should().Contain(expected);

            string[] notExpected = new[] { "13" };
            result.Should().NotContain(notExpected);
        }

        [Fact]
        public void GeyKeys_IfTwoSimpleEntitiesButNumbers_ShouldReturnBoth()
        {
            string json = "{\"id\" : 13, \"number\": 52}";

            var result = json.Find();

            string[] expected = new [] { "id", "number"};
            result.Should().Contain(expected);

            string[] notExpected = new[] { "13", "52" };
            result.Should().NotContain(notExpected);
        }

        [Fact]
        public void GeyKeys_IfTwoSimpleEntities_ShouldReturnBoth()
        {
            string json = "{\"foo\":\"bar\", \"dupa\" : \"debug\"}";

            var result = json.Find();

            string[] expected = new[] { "foo", "dupa" };
            result.Should().Contain(expected);

            string[] notExpected = new[] { "bar", "debug" };
            result.Should().NotContain(notExpected);
        }

        [Fact]
        public void GeyKeys_IfOneSimpleEntityAndOneObject_ShouldReturnBoth()
        {
            string json = "{\"foo\":\"bar\", \"dupa\" : { \"id\": \"abcdefgh\"}  }";

            var result = json.Find();

            string[] expected = new[] { "foo", "dupa" };
            result.Should().Contain(expected);

            string[] notExpected = new[] { "bar", "abcdefgh" };
            result.Should().NotContain(notExpected);
        }
    }
}
