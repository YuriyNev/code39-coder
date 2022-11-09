using Aspose.Coder39.Properties;
using Aspose.Coder39.Types;

namespace Aspose.Coder39.Services;

public static class CharBarHelper
{
    public static Bar Parse(this string textView, IParseRule? rule = null)
    {
        rule ??= new DefaultParseRule();

        var strips = new List<Strip>();
        
        int barWidth = 0;
        int spaceWidth = 0;
        var length = textView.Length;

        for (var i = 0; i < length; i++)
        {
            var c = textView[i];
            var lastItem = i == length - 1;
            
            if (rule.IsNarrowBar(c))
                Accumulate(strips, ref spaceWidth, ref barWidth, lastItem);
            else 
            if (rule.IsNarrowSpace(c))
                Accumulate(strips, ref barWidth, ref spaceWidth, lastItem);
            else
                throw new InvalidTextBarException();

            if (barWidth > Constants.WideSize) throw new InvalidTextBarException();
            if (spaceWidth > Constants.WideSize) throw new InvalidTextBarException();
        }

        return new Bar(strips);
    }

    private static void Accumulate(ICollection<Strip> strips, ref int width1, ref int width2, bool needFlush)
    {
        width2++;

        if (needFlush)
        {
            strips.Add(new Strip(width2));
            return;
        }
        
        if (width1 <= 0) return;
        
        if (width1 is > Constants.NarrowSize and < Constants.WideSize)
            throw new InvalidTextBarException();

        strips.Add(new Strip(width1));

        width1 = 0;
    }
}