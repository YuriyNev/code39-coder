using System.Collections.ObjectModel;

internal class CharBar : ReadOnlyCollection<Strip>
{
    public char Char { get; }

    public CharBar(char c, IList<Strip> bar) : base(bar)
    {
        if (c <= 0) throw new ArgumentOutOfRangeException(nameof(c));
        if (bar.Count != 9) throw new ArgumentOutOfRangeException(nameof(bar));
        
        Char = c;
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
            new Strip(Color.Black, WideSize),
            new Strip(Color.White, NormSize),
            new Strip(Color.Black, NormSize),
            new Strip(Color.White, NormSize),
            new Strip(Color.Black, NormSize),
            new Strip(Color.White, WideSize),
            new Strip(Color.Black, NormSize),
            new Strip(Color.White, NormSize),
            new Strip(Color.Black, WideSize),
        };
        
        return new CharBar('A', strip);
    }
}

internal class Strip
{
    public Color Color { get; set; }
    
    public byte Size { get; set; }

    public Strip(Color color, byte size)
    {
        if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));
        if (size > 3) throw new ArgumentOutOfRangeException(nameof(size));
        
        Color = color;
        Size = size;
    }
}

internal enum Color
{
    White, Black,
}