
using Xunit.Abstractions;

#pragma warning disable 162

namespace TestProject1
{
    public class Quiz2
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public Quiz2(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        
        public async Task ThrowException()
        {
            _testOutputHelper.WriteLine("2");

            throw new Exception("error");
        }

        [Fact]
        public async Task Fact1()
        {
            var exceptionHandled = false;
            _testOutputHelper.WriteLine("1");

            var task = ThrowException();

            try
            {
                
                _testOutputHelper.WriteLine("3");
                await task;
                _testOutputHelper.WriteLine("4");
            }
            catch
            {
                exceptionHandled = true;
            }


            Assert.True(exceptionHandled);
        }
    }
}
