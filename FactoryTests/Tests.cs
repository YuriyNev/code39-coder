using Aspose.Coder39.Services;
using Aspose.Coder39.Types;

namespace TestProject1;

public class FactoryTests
{
    [Fact]
    public void Creation1Test()
    {
        var result = CharBarProvider.TryGetBar('A', out var charBarA);
        
        Assert.True(result);
        Assert.True(charBarA != null);
        Assert.Equal(Color.Black, charBarA[0].Color);
        Assert.Equal(Color.Black, charBarA[8].Color);
    }
    
    [Fact]
    public void TextView1Test()
    {
        var result = CharBarProvider.TryGetBar('A', out var charBarA);
        var textView = charBarA?.ToString();
        
        Assert.Equal("111010100010111", textView);
    }
}