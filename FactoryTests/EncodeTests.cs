using Aspose.Coder39.Assistants;
using Aspose.Coder39.Services;

namespace TestProject1;

public class EncodeTests
{
    [Fact]
    public void EncodeTextAATest1()
    {
        var textAA = "111010100010111111010100010111";
        var barCode = textAA.ParseBarCode();

        var encoder = new Code39();
        var encodedText = encoder.Encode("AA");

        Assert.Equal(textAA, encodedText.TextView());
    }
}