using System.Diagnostics;

namespace TestProject1
{
    public class Quiz3
    {
        public async Task<string> ReturnFoo()
        {
            await Task.Delay(3000);

            return "foo";
        }
        public async Task<string> ReturnFooFoo()
        {
            await Task.Delay(4000);

            return "foofoo";
        }


        [Fact]
        public async Task Fact1()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            await ReturnFoo();
            await ReturnFooFoo();

            stopWatch.Stop();
            var milliseconds = stopWatch.ElapsedMilliseconds;

            var underFiveSeconds = milliseconds < 5000;

            Assert.True(underFiveSeconds);
            //false, 7s
        }


        [Fact]
        public async Task Fact2()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            await Task.WhenAll(ReturnFoo(), ReturnFooFoo());

            stopWatch.Stop();
            var milliseconds = stopWatch.ElapsedMilliseconds;

            var underFiveSeconds = milliseconds < 5000;

            Assert.True(underFiveSeconds);
            //true, 4s
        }
    }
}
