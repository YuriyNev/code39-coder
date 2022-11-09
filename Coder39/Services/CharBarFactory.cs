using Aspose.Coder39.Properties;
using Aspose.Coder39.Types;

namespace Aspose.Coder39.Services;

public static class CharBarFactory
{
    private const int Wide = Constants.WideSize;
    private const int Norm = Constants.NarrowSize;

    static CharBarFactory()
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
        var bar = new Bar(strips);
        A = new CharBar('A', bar);
    }

    public static CharBar A { get; }
}