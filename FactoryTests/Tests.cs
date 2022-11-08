using Aspose.Coder39.Services;
using Aspose.Coder39.Types;

namespace TestProject1;

public class FactoryTests
{
    [Fact]
    public void Creation1Test()
    {
        var charBarA = CharBarFactory.A();
        
        Assert.Equal('A', charBarA.Char);
        Assert.Equal(Color.Black, charBarA[0].Color);
        Assert.Equal(Color.Black, charBarA[8].Color);
    }
}