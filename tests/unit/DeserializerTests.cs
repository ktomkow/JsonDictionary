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

        [Fact]
        public void Take_IfSimpleValuePropertyExistsAndIsOnlyOne_ShouldReturnIt()
        {
            string json = "{ \"dupa\": \"5\"}";
            string property = "dupa";

            string result = json.Take(property);

            result.Should().Be("\"5\"");
        }

        [Fact]
        public void Take_IfSimpleValuePropertyExists_ShouldReturnIt()
        {
            string json = "{ \"dupa\": \"dupaDrivenDebugging\", \"foo\":\"bar\"}";
            string property = "dupa";

            string result = json.Take(property);

            result.Should().Be("\"dupaDrivenDebugging\"");
        }
    }
}
