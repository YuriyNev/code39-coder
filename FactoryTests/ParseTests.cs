using Aspose.Coder39.Services;

namespace TestProject1;

public class ParseTests
{
    [Fact]
    public void BarParseFailedTooWideSpaceTest()
    {
        Assert.Throws<InvalidTextBarException>(() => "111010100000000010111".Parse());
    }
    
    [Fact]
    public void BarParse1Test()
    {
        var bar = "111010100010111".Parse();
        
        Assert.NotNull(bar);
    }
}