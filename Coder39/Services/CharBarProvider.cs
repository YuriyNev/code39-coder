using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Aspose.Coder39.Assistants;
using Aspose.Coder39.Types;

namespace Aspose.Coder39.Services;

public static class CharBarProvider
{
    private static readonly Dictionary<char, BarPart?> Mapping = new();

    static CharBarProvider()
    {
        var parseRule = new DefaultParseRule();

        Mapping.Add('A', "111010100010111".ParsePart(parseRule));
        Mapping.Add('B', "101110100010111".ParsePart(parseRule));
        Mapping.Add('C', "111011101000101".ParsePart(parseRule));
        Mapping.Add('D', "101011100010111".ParsePart(parseRule));
        Mapping.Add('E', "111010111000101".ParsePart(parseRule));
        Mapping.Add('F', "101110111000101".ParsePart(parseRule));
        Mapping.Add('G', "101010001110111".ParsePart(parseRule));
        Mapping.Add('H', "111010100011101".ParsePart(parseRule));
        Mapping.Add('I', "101110100011101".ParsePart(parseRule));
        Mapping.Add('J', "101011100011101".ParsePart(parseRule));
        Mapping.Add('K', "111010101000111".ParsePart(parseRule));
        Mapping.Add('L', "101110101000111".ParsePart(parseRule));
        Mapping.Add('M', "111011101010001".ParsePart(parseRule));
        Mapping.Add('N', "101011101000111".ParsePart(parseRule));
        Mapping.Add('O', "111010111010001".ParsePart(parseRule));
        Mapping.Add('P', "101110111010001".ParsePart(parseRule));
        Mapping.Add('Q', "101010111000111".ParsePart(parseRule));
        Mapping.Add('R', "111010101110001".ParsePart(parseRule));
        Mapping.Add('S', "101110101110001".ParsePart(parseRule));
        Mapping.Add('T', "101011101110001".ParsePart(parseRule));
        Mapping.Add('U', "111000101010111".ParsePart(parseRule));
        Mapping.Add('V', "100011101010111".ParsePart(parseRule));
        Mapping.Add('W', "111000111010101".ParsePart(parseRule));
        Mapping.Add('X', "100010111010111".ParsePart(parseRule));
        Mapping.Add('Y', "111000101110101".ParsePart(parseRule));
        Mapping.Add('Z', "100011101110101".ParsePart(parseRule));
        Mapping.Add('-', "100010101110111".ParsePart(parseRule));
        Mapping.Add('.', "111000101011101".ParsePart(parseRule));
        Mapping.Add(' ', "100011101011101".ParsePart(parseRule));
        Mapping.Add('*', "100010111011101".ParsePart(parseRule));
        Mapping.Add('1', "111010001010111".ParsePart(parseRule));
        Mapping.Add('2', "101110001010111".ParsePart(parseRule));
        Mapping.Add('3', "111011100010101".ParsePart(parseRule));
        Mapping.Add('4', "101000111010111".ParsePart(parseRule));
        Mapping.Add('5', "111010001110101".ParsePart(parseRule));
        Mapping.Add('6', "101110001110101".ParsePart(parseRule));
        Mapping.Add('7', "101000101110111".ParsePart(parseRule));
        Mapping.Add('8', "111010001011101".ParsePart(parseRule));
        Mapping.Add('9', "101110001011101".ParsePart(parseRule));
        Mapping.Add('0', "101000111011101".ParsePart(parseRule));
        Mapping.Add('$', "100010001000101".ParsePart(parseRule));
        Mapping.Add('/', "100010001010001".ParsePart(parseRule));
        Mapping.Add('+', "100010100010001".ParsePart(parseRule));
        Mapping.Add('%', "101000100010001".ParsePart(parseRule));

        Check();
    }

    private static void Check()
    {
        var comparer = new BarPart(Array.Empty<Strip>());
        
        var uniqueCount = Mapping
            .Select(x => x.Value)
            .Distinct(comparer)
            .Count();

        if (uniqueCount == Mapping.Count) return;
        
        var duplicates = Mapping
            .GroupBy(x => x.Value, comparer)
            .Where(x => x.Count() > 1)
            .SelectMany(x => x.Select(y => y.Key))
            .ToList();

        Debug.Assert(false, $"Duplicated bar value: {duplicates.Aggregate("", (current, c) => $"{current} '{c}',")}!");
    }

    public static bool TryGetBar(char c, [MaybeNullWhen(false)] out BarPart result)
    {
        return Mapping.TryGetValue(c, out result);
    }

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
}