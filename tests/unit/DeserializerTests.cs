using FluentAssertions;
using System;
using Xunit;

namespace JsonDictionary.Tests
{
    public class DeserializerTests
    {
        [Fact]
        public void Take_IfPropertyNotExist_ShouldReturnEmptyString()
        {
            string json = "{ \"dupa\": \"5\"}";
            string property = "foo";

            string result = json.Take(property);

            result.Should().BeEmpty();
        }

        [Fact]
        public void Take_IfJsonEmpty_ShouldReturnEmptyString()
        {
            string json = "";
            string property = "foo";

            string result = json.Take(property);

            result.Should().BeEmpty();
        }

        [Fact]
        public void Take_IfPropertyEmpty_ShouldThrow()
        {
            string json = "{ \"dupa\": \"5\"}";
            string property = "";

            Func<string> act = () => { return json.Take(property); };

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
