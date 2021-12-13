using System;
using System.Collections.Generic;
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
            string key = "key key";
            Json json = new Json(key);

        }
    }
}
