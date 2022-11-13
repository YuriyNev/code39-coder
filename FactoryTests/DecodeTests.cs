using Aspose.Coder39.Assistants;
using Aspose.Coder39.Services;
using Aspose.Coder39.Types;

namespace TestProject1;

public class DecodeTests
{
    [Fact]
    public void Decode1Test()
    {
        var coder = new Code39();

        var barCodeABC = "111010100010111101110100010111111011101000101".ParseBarCode();

        var decodedText = coder.Decode(barCodeABC);
        
        Assert.Equal("ABC", decodedText);
    }
    
    [Fact]
    public void Decode2Test()
    {
        var coder = new Code39();

        var charA = "111010100010111".ParsePart(new DefaultParseRule());
        var charB = "101110100010111".ParsePart(new DefaultParseRule());
        var charUnknown = "011101000100010".ParsePart(new DefaultParseRule());
        var barCodeABX = new BarCode(charA, charB, charUnknown);

        Assert.Throws<DecodeBarException>(() => coder.Decode(barCodeABX));
    }
}