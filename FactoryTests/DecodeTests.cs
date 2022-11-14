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

        var barCodeABC = "1000101110111010111010100010111010111010001011101110111010001010100010111011101".ParseBarCode();

        var decodedText = coder.Decode(barCodeABC);
        
        Assert.Equal("ABC", decodedText);
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

        var helloCode = "1000101110111010111010100011101011101011100010101011101010001110101110101000111011101011101011101000111010111010111011101000101011101011101011101010111000101110111010111000101011101110001010101011100010111010100010111011101"
            .ParseBarCode();

        var decoded = coder.Decode(helloCode);
        Assert.Equal("HELLO CODE39", decoded);
    }
}