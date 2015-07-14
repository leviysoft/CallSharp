using System;
using Should;
using Xunit;

namespace CallSharp.Tests
{
    public class CallTests
    {
        [Fact]
        public void CallSampleTest()
        {
            var sample = new SampleClass();

            var id = sample.Call(s => s.GetName(42)).Catch((NotImplementedException _) => "test")();

            id.ShouldEqual("test");
        }
    }
}
