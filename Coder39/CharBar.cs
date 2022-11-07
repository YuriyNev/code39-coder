using System.Collections.ObjectModel;

internal class CharBar : ReadOnlyCollection<Strip>
{
    public char Char { get; }

    private const Color Foreground = Color.Black;
    private const Color BackColor = Color.White;
    
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
            var color = i % 2 == 0 ? Foreground : BackColor;
            bar[i].Fill(color);
        }
    }
}

internal class CharBarFactory
{
    private const int WideSize = 3;
    private const int NormSize = 1;
    
    public CharBar A()
    {
        //   ▮|| |▮
        
        var strip = new[]
        {
            new Strip(WideSize),
            new Strip(NormSize),
            new Strip(NormSize),
            new Strip(NormSize),
            new Strip(NormSize),
            new Strip(WideSize),
            new Strip(NormSize),
            new Strip(NormSize),
            new Strip(WideSize),
        };
        
        return new CharBar('A', strip);
    }
}

internal class Strip
{
    public byte Size { get; }
    
    public Color? Color { get; private set; }

    public Strip(byte size)
    {
        if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));
        if (size > 3) throw new ArgumentOutOfRangeException(nameof(size));
        
        Size = size;
    }

    public void Fill(Color color) => Color = color;
}

internal enum Color
{
    White, Black,
}