using Aspose.Coder39.Properties;
using Aspose.Coder39.Types;

namespace Aspose.Coder39.Services;

public static class CharBarFactory
{
    public static CharBar A()
    {
        //   ▮|| |▮
        
        var strips = new[]
        {
            new Strip(Constants.WideSize),
            new Strip(Constants.NormSize),
            new Strip(Constants.NormSize),
            new Strip(Constants.NormSize),
            new Strip(Constants.NormSize),
            new Strip(Constants.WideSize),
            new Strip(Constants.NormSize),
            new Strip(Constants.NormSize),
            new Strip(Constants.WideSize),
        };
        
        return new CharBar('A', strips);
    }
}
