namespace Aspose.Coder39.Services;

public interface IParseRule
{
    bool IsNarrowBar(char c);
    bool IsNarrowSpace(char c);
}

public class DefaultParseRule : IParseRule
{
    public bool IsNarrowBar(char c)
    {
        return c == '1';
    }

    public bool IsNarrowSpace(char c)
    {
        return c == '0';
    }
}