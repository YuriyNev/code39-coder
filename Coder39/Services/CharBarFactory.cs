using Aspose.Coder39.Properties;
using Aspose.Coder39.Types;

namespace Aspose.Coder39.Services;

public static class CharBarFactory
{
    private const int Wide = Constants.WideSize;
    private const int Norm = Constants.NormSize;

    public static CharBar A()
    {
        //   ▮|| |▮

        var strips = new[]
        {
            new Strip(Wide),
            new Strip(Norm),
            new Strip(Norm),
            new Strip(Norm),
            new Strip(Norm),
            new Strip(Wide),
            new Strip(Norm),
            new Strip(Norm),
            new Strip(Wide),
        };
        
        return new CharBar('A', strips);
    }
}
