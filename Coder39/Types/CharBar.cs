using System.Collections.ObjectModel;
using System.Text;
using Aspose.Coder39.Properties;

namespace Aspose.Coder39.Types;

public class Bar : ReadOnlyCollection<Strip>
{
    public Bar(IList<Strip> bar) : base(bar)
    {
        if (bar.Count != Constants.CharCodeSize) throw new ArgumentOutOfRangeException(nameof(bar));
        
        Fill(bar);
    }
    
    public string TextView()
    {
        var result = new StringBuilder();
        
        foreach (var item in Items)
        {
            var baseChar = item.Color switch
            {
                Constants.Background => '0',
                Constants.Foreground => '1',
                _ => throw new ArgumentOutOfRangeException(nameof(Color))
            };
            result.Append(new string(baseChar, item.Size));
        }

        return result.ToString();
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not Bar ch) return false;

        return Items.SequenceEqual(ch.Items);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    private static void Fill(IList<Strip> bar)
    {
        for (int i = 0; i < bar.Count; i++)
        {
            var color = i % 2 == 0 
                ? Constants.Foreground 
                : Constants.Background;
            
            bar[i].Fill(color);
        }
    }
}


public class CharBar 
{
    public char Char { get; }
    public Bar Bar { get; }

    public CharBar(char c, Bar bar)
    {
        if (c <= 0) throw new ArgumentOutOfRangeException(nameof(c));
        Bar = bar ?? throw new ArgumentNullException(nameof(bar));
        
        Char = c;
    }
}