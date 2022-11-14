using Aspose.Coder39.Assistants;
using Aspose.Coder39.Services;

namespace TestProject1;

public class ParseTests
{
    [Fact]
    public void BarParseFailedTooWideSpaceTest()
    {
        Assert.Throws<InvalidTextBarException>(() => "111010100000000010111".ParsePart(new DefaultParseRule()));
    }
    
    [Fact]
    public void BarParse1Test()
    {
        var bar = "111010100010111".ParsePart(new DefaultParseRule());
        
        Assert.NotNull(bar);
    }
    
    [Fact]
    public void BarParseInvalid2Test()
    {
        Assert.Throws<InvalidTextBarException>(() => "111010110010111".ParsePart(new DefaultParseRule()));
    }
    
    [Fact]
    public void ParseBarCode1Test()
    {
        var bar = "1110101000101110111010100010111".ParseBarCode(new DefaultParseRule());
        
        Assert.NotNull(bar);
    }
}