using Aspose.Coder39.Services;
using Aspose.Coder39.Types;

namespace TestProject1;

public class FactoryTests
{
    [Fact]
    public void Creation1Test()
    {
        var charBarA = CharBarFactory.A;
        
        Assert.Equal('A', charBarA.Char);
        Assert.Equal(Color.Black, charBarA.Bar[0].Color);
        Assert.Equal(Color.Black, charBarA.Bar[8].Color);
    }
    
    [Fact]
    public void TextView1Test()
    {
        var charBarA = CharBarFactory.A;
        var textView = charBarA.Bar.TextView();
        
        Assert.Equal("111010100010111", textView);
    }
    
    [Fact]
    public void BarCodeEncode1Test()
    {
        var creator = new BarCodeCreator();
        var result = creator.Method("AA");
        
        Assert.Equal("111010100010111111010100010111", result);
    }
}