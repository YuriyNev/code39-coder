namespace Aspose.Coder39.Types;

public class Strip
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