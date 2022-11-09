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

public static class CharBarHelper
{
    public static Bar Parse(this string textView, IParseRule? rule = null)
    {
        if (textView.Length != Constants.CharCodeSize) throw new InvalidTextBarException();
        
        rule ??= new DefaultParseRule();

        var strips = new List<Strip>(textView.Length);
        
        int barWidth = 0;
        int spaceWidth = 0;

        foreach (var x in textView)
        {
            if (rule.IsNarrowBar(x))
                Accumulate(strips, ref spaceWidth, ref barWidth);
            else if (rule.IsNarrowSpace(x))
                Accumulate(strips, ref barWidth, ref spaceWidth);
            else
                throw new InvalidTextBarException();

            if (barWidth > Constants.WideSize) throw new InvalidTextBarException();
            if (spaceWidth > Constants.WideSize) throw new InvalidTextBarException();
        }

        return new Bar(strips);
    }

    private static void Accumulate(ICollection<Strip> strips, ref int width1, ref int width2)
    {
        width2++;

        if (width1 <= 0) return;
        
        if (width1 is > Constants.NarrowSize and < Constants.WideSize)
            throw new InvalidTextBarException();

        var strip = new Strip(width1);
        strips.Add(strip);

        width1 = 0;
    }
}

public class DefaultParseRule : IParseRule
{
    public bool IsNarrowBar(char c) => c == '0';
    public bool IsNarrowSpace(char c) => c == '1';
}

public interface IParseRule
{
    bool IsNarrowBar(char c);
    bool IsNarrowSpace(char c);
}

public class InvalidTextBarException : Exception
{
}