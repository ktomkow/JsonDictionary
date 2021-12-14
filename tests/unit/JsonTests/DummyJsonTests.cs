using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace JsonDictionary.Tests.JsonTests
{
    public class DummyJsonTests
    {
        private readonly ITestOutputHelper output;

        public DummyJsonTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Dupa()
        {
            string key = "dupa";
            string jsonAsText = "{\"dupa\":\"abc\"}";
            Json json = new Json(jsonAsText);

            Json value = json[key];

            string[] expected = new[] { "dupa" };
            json.Keys.Should().Contain(expected);

            
            value.Value.Should().Be("abc");
        }

        [Fact]
        public void Null()
        {
            string key = "cycki";
            string jsonAsText = "{\"cycki\":null}";
            Json json = new Json(jsonAsText);

            Json value = json[key];

            string[] expected = new[] { "cycki" };
            json.Keys.Should().Contain(expected);


            value.Value.Should().BeEmpty();
        }

        [Fact]
        public void Null2()
        {
            string key = "cycki";
            string jsonAsText = "{\"cycki\":\"null\"}";
            Json json = new Json(jsonAsText);

            Json value = json[key];

            string[] expected = new[] { "cycki" };
            json.Keys.Should().Contain(expected);


            value.Value.Should().Be("null");
        }


        [Fact]
        public void Dupa2()
        {
            string key = "dupa";
            string jsonAsText = "{\"dupa\": {\"drugadupa\":\"abcd\"}}";
            Json json = new Json(jsonAsText);

            Json value = json[key];

            string[] expected = new[] { "dupa" };
            json.Keys.Should().Contain(expected);
            json.Keys.Count().Should().Be(1);

            value.Value.Should().Be("{\"drugadupa\":\"abcd\"}");
        }
    }
}
