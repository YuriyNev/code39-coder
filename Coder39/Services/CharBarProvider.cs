using System.Diagnostics.CodeAnalysis;
using Aspose.Coder39.Assistants;
using Aspose.Coder39.Types;

namespace Aspose.Coder39.Services;

public static class CharBarProvider
{
    public static bool TryGetBar(char c, [MaybeNullWhen(false)] out BarPart result) 
        => Mapping.TryGetValue(c, out result);

    public static bool TryChar(BarPart barPart, out char? c)
    {
        var keyPair = Mapping.FirstOrDefault(x => Equals(x.Value, barPart));
        
        if (keyPair.Key == default && keyPair.Value == default)
        {
            c = null;
            return false;
        }

        c = keyPair.Key;
        return true;
    }

    private static readonly Dictionary<char, BarPart?> Mapping = new();

    static CharBarProvider()
    {
        var parseRule = new DefaultParseRule();

        Mapping.Add('A', "111010100010111".ParsePart(parseRule));
        Mapping.Add('B', "101110100010111".ParsePart(parseRule));
        Mapping.Add('C', "111011101000101".ParsePart(parseRule));
    }
}