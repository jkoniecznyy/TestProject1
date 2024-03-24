using Xunit.Abstractions;

namespace TestProject1;

public class Quiz1
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Quiz1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    public async Task Delay1000()
    {
        _testOutputHelper.WriteLine("4");
        await Task.Delay(1000);
        _testOutputHelper.WriteLine("5");
    }

    public async Task Delay2000()
    {
        _testOutputHelper.WriteLine("2");
        await Task.Delay(2000);
        _testOutputHelper.WriteLine("3");
    }


    [Fact]
    public async Task Fact1()
    {
        _testOutputHelper.WriteLine("1");

        await Delay2000();

        await Delay1000();

        _testOutputHelper.WriteLine("6");
        //1, 2, 3, 4, 5, 6

        Assert.True(true);
    }


    [Fact]
    public async Task Fact2()
    {  
        _testOutputHelper.WriteLine("1");

        Delay2000();

        Delay1000();
        

        _testOutputHelper.WriteLine("6");

        await Task.Delay(5000);
        //1, 6, 2, 4, 5, 3
        //1, 6, 
        //O: 1, 2, 4, 6
        _testOutputHelper.WriteLine("7");
        Assert.True(true);
    }
}