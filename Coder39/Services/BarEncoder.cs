using Aspose.Coder39.Properties;
using Aspose.Coder39.Types;

namespace Aspose.Coder39.Services;

public class Code39 : IBarCoder
{
    public string Decode(BarCode bar)
    {
        if (bar == null) throw new ArgumentNullException(nameof(bar));

        var result = string.Empty;
        for (var i = 0; i < bar.Count; i++)
        {
            var part = bar[i];
            
            if (CharBarProvider.TryChar(part, out var c))
            {
                if (i == 0 || i == bar.Count - 1)
                {
                    if (c != Constants.SpecSymbol) throw new DecodeBarException("Cannot decode bar!");
                }
                else
                {
                    result += c;
                }
            }
            else
                throw new DecodeBarException("Cannot decode bar!");
        }

        return result;
    }

    public BarCode Encode(string text)
    {
        if (text == null) throw new ArgumentNullException(nameof(text));
        text = text.ToUpper();
        
        var codeContent = new List<BarPart>(text.Length + 2);
        
        void AddChar(char c)
        {
            if (CharBarProvider.TryGetBar(c, out var barPart))
                codeContent.Add(barPart);
            else
                throw new EncodeBarException($"Unknown char {c}!");
        }

        AddChar(Constants.SpecSymbol);
        
        foreach (var c in text) AddChar(c);
        
        AddChar(Constants.SpecSymbol);

        return new BarCode(codeContent);
    }

    public string SafeDecode(BarCode bar)
    {
        throw new NotImplementedException();
    }

    public BarCode SafeEncode(string text)
    {
        throw new NotImplementedException();
    }
}

public interface IBarCoder
{
    /// <summary>  Decode Code39  </summary>
    /// <exception cref="DecodeBarException"></exception>
    string Decode(BarCode bar);

    /// <summary>  Encode Code39  </summary>
    /// <exception cref="EncodeBarException"></exception>
    BarCode Encode(string text);

    /// <summary> Encode Code39 without exceptions </summary>
    string SafeDecode(BarCode bar);

    /// <summary> Decode Code39 without exceptions </summary>
    BarCode SafeEncode(string text);
}