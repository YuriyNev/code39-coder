using Aspose.Coder39.Properties;
using Aspose.Coder39.Types;

namespace Aspose.Coder39.Services;

public class Code39 : IBarCoder
{
    public string Decode(BarCode bar)
    {
        if (bar == null) throw new ArgumentNullException(nameof(bar));
        
        var result = string.Empty;
        foreach (var part in bar)
        {
            if (CharBarProvider.TryChar(part, out var c))
                result += c;
            else
                throw new DecodeBarException("Cannot decode bar!");
        }

        return result;
    }

    public BarCode Encode(string text)
    {
        if (text == null) throw new ArgumentNullException(nameof(text));
        
        var codeContent = new List<BarPart>(text.Length);
        foreach (var c in text)
        {
            if (CharBarProvider.TryGetBar(c, out var barPart))
            {
                codeContent.Add(barPart);
            }
            else
            {
                throw new EncodeBarException($"Unknown char {c}!");
            }
        }

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