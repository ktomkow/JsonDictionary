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
    }
}
