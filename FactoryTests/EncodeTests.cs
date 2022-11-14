using Aspose.Coder39.Assistants;
using Aspose.Coder39.Services;

namespace TestProject1;

public class EncodeTests
{
    [Fact]
    public void EncodeTextAATest1()
    {
        var textAA = "100010111011101111010100010111111010100010111100010111011101";
        var barCode = textAA.ParseBarCode();

        var encoder = new Code39();
        var encoded = encoder.Encode("AA");

        Assert.Equal(textAA, encoded.ToString());
    }
    
    [Fact]
    public void EncodeTextABCLengthTest2()
    {
        var encoder = new Code39();
        var encoded = encoder.Encode("C");
        
        Assert.Equal(45, encoded.ToString().Length);
    }
}