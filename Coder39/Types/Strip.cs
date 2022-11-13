using Aspose.Coder39.Properties;

namespace Aspose.Coder39.Types;

public class Strip
{
    public Strip(int size)
    {
        if (size < Constants.NarrowSize) throw new ArgumentOutOfRangeException(nameof(size));
        if (size > Constants.WideSize) throw new ArgumentOutOfRangeException(nameof(size));

        Size = size;
    }

    public Strip(int size, Color? color) : this(size)
    {
        Color = color;
    }

    public int Size { get; }

    public Color? Color { get; private set; }

    public void Fill(Color color)
    {
        Color = color;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not Strip other) return false;

        return other.Size == Size && other.Color == Color;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}