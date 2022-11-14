using System.Collections.ObjectModel;
using System.Text;
using Aspose.Coder39.Properties;

namespace Aspose.Coder39.Types;

public class BarCode : ReadOnlyCollection<BarPart>
{
    public BarCode(IList<BarPart> list) : base(list)
    {
    }

    public BarCode(params BarPart[] parts) : base(new List<BarPart>(parts))
    {
    }

    public override string ToString()
    {
        return Items.Aggregate(string.Empty, (current, item) => current + item);
    }
}

public class BarPart : ReadOnlyCollection<Strip>, IEqualityComparer<BarPart>
{
    public BarPart(IList<Strip> bar) : base(bar)
    {
        Fill(bar);
    }

    public override string ToString()
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
        if (obj is not BarPart ch) return false;

        return Items.SequenceEqual(ch.Items);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    private static void Fill(IList<Strip> bar)
    {
        for (var i = 0; i < bar.Count; i++)
        {
            var color = i % 2 == 0
                ? Constants.Foreground
                : Constants.Background;

            bar[i].Fill(color);
        }
    }

    public bool Equals(BarPart? x, BarPart? y)
    {
        if (x == null && y != null) return false;
        if (x != null && y == null) return false;
        if (x == null && y == null) return true; 
        
        return x!.SequenceEqual(y!);
    }

    public int GetHashCode(BarPart obj)
    {
        unchecked
        {
            int hash = 19;
            foreach (var strip in Items)
            {
                hash = hash * 31 + strip.GetHashCode();
            }
            return hash;
        }
    }
}