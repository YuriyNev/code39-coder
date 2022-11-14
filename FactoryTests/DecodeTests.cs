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

        var barCodeABC = "100010111011101111010100010111101110100010111111011101000101100010111011101".ParseBarCode();

        var decodedText = coder.Decode(barCodeABC);
        
        Assert.Equal("*ABC*", decodedText);
    }
    
    [Fact]
    public void Decode2Test()
    {
        var coder = new Code39();

        var charA = "111010100010111".ParsePart(new DefaultParseRule());
        var charB = "101110100010111".ParsePart(new DefaultParseRule());
        var charUnknown = "010101000101010".ParsePart(new DefaultParseRule());
        var barCodeABX = new BarCode(charA, charB, charUnknown);

        Assert.Throws<DecodeBarException>(() => coder.Decode(barCodeABX));
    }
    
    [Fact]
    public void Decode3Test()
    {
        var coder = new Code39();

        var helloCode = "100010111011101111010100011101111010111000101101110101000111101110101000111111010111010111100011101011101111011101000101111010111010111101011100010111111010111000101111011100010101101110001011101100010111011101"
            .ParseBarCode();

        var decoded = coder.Decode(helloCode);
        Assert.Equal("HELLO CODE39", decoded);
    }
}