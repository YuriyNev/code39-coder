using System.Collections.ObjectModel;
using Aspose.Coder39.Properties;

namespace Aspose.Coder39.Types;

public class CharBar : ReadOnlyCollection<Strip>
{
    public char Char { get; }

    public CharBar(char c, IList<Strip> bar) : base(bar)
    {
        if (c <= 0) throw new ArgumentOutOfRangeException(nameof(c));
        if (bar.Count != 9) throw new ArgumentOutOfRangeException(nameof(bar));
        
        Char = c;
        
        Fill(bar);
    }

    private static void Fill(IList<Strip> bar)
    {
        for (int i = 0; i < bar.Count; i++)
        {
            var color = i % 2 == 0 
                ? Constants.Foreground 
                : Constants.BackColor;
            
            bar[i].Fill(color);
        }
    }
}