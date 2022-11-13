using Aspose.Coder39.Properties;
using Aspose.Coder39.Types;

namespace TestProject1;

public class CompareTests
{
    [Fact]
    public void StripComparing1Test()
    {
        var strip1 = new Strip(1);
        var strip2 = new Strip(1);

        var equal = strip1.Equals(strip2);
        Assert.True(equal);
    }
    
    [Fact]
    public void StripComparing2Test()
    {
        var strip1 = new Strip(1);
        var strip2 = new Strip(2);

        var equal = strip1.Equals(strip2);
        Assert.False(equal);
    }
    
    [Fact]
    public void StripComparing3Test()
    {
        var strip1 = new Strip(2);
        strip1.Fill(Color.Black);
        
        var strip2 = new Strip(2);

        var equal = strip1.Equals(strip2);
        Assert.False(equal);
    }

    [Fact]
    public void BarComparing1Test()
    {
        BarPart CreateBar()
        {
            var strips = new List<Strip>();
            for (var i = 0; i < Constants.CharCodeSize; i++) strips.Add(new Strip(1));
            var bar = new BarPart(strips);
            return bar;
        }

        var bar1 = CreateBar();
        var bar2 = CreateBar();

        var equals = bar1.Equals(bar2);
        Assert.True(equals);
    }

    [Fact]
    public void BarCodeComparing1Test()
    {
        
    }
}