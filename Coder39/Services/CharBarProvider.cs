using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Aspose.Coder39.Assistants;
using Aspose.Coder39.Types;

namespace Aspose.Coder39.Services;

public static class CharBarProvider
{
    private static readonly Dictionary<char, BarPart?> Mapping = new();
    private static readonly Dictionary<char, string?> TextBarCodeMapping = new();

    static CharBarProvider()
    {
        var parseRule = new DefaultParseRule();

        AddToMappings('A', "111010100010111", parseRule);
        AddToMappings('B', "101110100010111", parseRule);
        AddToMappings('C', "111011101000101", parseRule);
        AddToMappings('D', "101011100010111", parseRule);
        AddToMappings('E', "111010111000101", parseRule);
        AddToMappings('F', "101110111000101", parseRule);
        AddToMappings('G', "101010001110111", parseRule);
        AddToMappings('H', "111010100011101", parseRule);
        AddToMappings('I', "101110100011101", parseRule);
        AddToMappings('J', "101011100011101", parseRule);
        AddToMappings('K', "111010101000111", parseRule);
        AddToMappings('L', "101110101000111", parseRule);
        AddToMappings('M', "111011101010001", parseRule);
        AddToMappings('N', "101011101000111", parseRule);
        AddToMappings('O', "111010111010001", parseRule);
        AddToMappings('P', "101110111010001", parseRule);
        AddToMappings('Q', "101010111000111", parseRule);
        AddToMappings('R', "111010101110001", parseRule);
        AddToMappings('S', "101110101110001", parseRule);
        AddToMappings('T', "101011101110001", parseRule);
        AddToMappings('U', "111000101010111", parseRule);
        AddToMappings('V', "100011101010111", parseRule);
        AddToMappings('W', "111000111010101", parseRule);
        AddToMappings('X', "100010111010111", parseRule);
        AddToMappings('Y', "111000101110101", parseRule);
        AddToMappings('Z', "100011101110101", parseRule);
        AddToMappings('-', "100010101110111", parseRule);
        AddToMappings('.', "111000101011101", parseRule);
        AddToMappings(' ', "100011101011101", parseRule);
        AddToMappings('*', "100010111011101", parseRule);
        AddToMappings('1', "111010001010111", parseRule);
        AddToMappings('2', "101110001010111", parseRule);
        AddToMappings('3', "111011100010101", parseRule);
        AddToMappings('4', "101000111010111", parseRule);
        AddToMappings('5', "111010001110101", parseRule);
        AddToMappings('6', "101110001110101", parseRule);
        AddToMappings('7', "101000101110111", parseRule);
        AddToMappings('8', "111010001011101", parseRule);
        AddToMappings('9', "101110001011101", parseRule);
        AddToMappings('0', "101000111011101", parseRule);
        AddToMappings('$', "100010001000101", parseRule);
        AddToMappings('/', "100010001010001", parseRule);
        AddToMappings('+', "100010100010001", parseRule);
        AddToMappings('%', "101000100010001", parseRule);

        CheckParsing();
        CheckDuplicates();
    }

    private static void AddToMappings(char c, string parse, IParseRule parseRule)
    {
        TextBarCodeMapping.Add(c, parse);
        Mapping.Add(c, parse.ParsePart(parseRule));
    }

    private static void CheckParsing()
    {
        int count = 0;
        foreach (var c in Mapping.Select(x => x.Key))
        {
            var textSource = TextBarCodeMapping[c];
            var barPart = Mapping[c];
            var s = barPart?.ToString();

            if (s != textSource)
            {
                Debug.Assert(barPart != null, nameof(barPart) + " != null");
                Debug.Assert(false, nameof(barPart) + " != null");
                count++;
            }
        }
    }

    private static void CheckDuplicates()
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

    public static bool TryGetChar(BarPart barPart, out char? c)
    {
        var keyPair = Mapping.FirstOrDefault(x => barPart.Equals(x.Value));

        if (keyPair.Key == default && keyPair.Value == default)
        {
            c = null;
            return false;
        }

        c = keyPair.Key;
        return true;
    }
}