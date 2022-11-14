using Aspose.Coder39.Properties;
using Aspose.Coder39.Services;
using Aspose.Coder39.Types;

namespace Aspose.Coder39.Assistants;

public static class BarParser
{
    public static BarCode ParseBarCode(this string textView, IParseRule? rule = null)
    {
        if ((textView.Length + Constants.PartSeparator.Length) % (Constants.AbsCharSize + Constants.PartSeparator.Length) != 0)
            throw new InvalidTextBarException();

        rule ??= new DefaultParseRule();

        var barParts = new List<BarPart>();

        var charCount = textView.Length / Constants.AbsCharSize;
        for (var i = 0; i < charCount; i++)
        {
            var part = textView.Substring(
                i * Constants.AbsCharSize + i * Constants.PartSeparator.Length,
                Constants.AbsCharSize);
            
            var barPart = part.ParsePart(rule);

            barParts.Add(barPart);
        }

        return new BarCode(barParts);
    }

    public static BarPart ParsePart(this string textView, IParseRule rule)
    {
        var strips = new List<Strip>();

        var barWidth = 0;
        var spaceWidth = 0;
        var length = textView.Length;

        for (var i = 0; i < length; i++)
        {
            var c = textView[i];
            var lastItem = i == length - 1;

            if (rule.IsNarrowBar(c))
                Accumulate(strips, ref spaceWidth, ref barWidth, lastItem);
            else if (rule.IsNarrowSpace(c))
                Accumulate(strips, ref barWidth, ref spaceWidth, lastItem);
            else
                throw new InvalidTextBarException();

            if (barWidth > Constants.WideSize) throw new InvalidTextBarException();
            if (spaceWidth > Constants.WideSize) throw new InvalidTextBarException();
        }

        return new BarPart(strips);
    }

    private static void Accumulate(ICollection<Strip> strips, ref int width1, ref int width2, bool needFlush)
    {
        width2++;

        if (needFlush)
        {
            if (width1 > 0)
            {
                strips.Add(new Strip(width1));
                width1 = 0;
            }

            if (width2 > 0)
            {
                strips.Add(new Strip(width2));
                width2 = 0;
            }

            return;
        }

        if (width1 <= 0) return;

        if (width1 is > Constants.NarrowSize and < Constants.WideSize)
            throw new InvalidTextBarException();

        strips.Add(new Strip(width1));
        width1 = 0;
    }
}