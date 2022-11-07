// See https://aka.ms/new-console-template for more information


Console.WriteLine("Hello, World!");


internal static class CodeWriter
{
    public static void Space() => Console.Write("0");
    public static void WideSpace() => Console.Write("000");
    public static void Bar() => Console.Write("1");
    public static void WideBar() => Console.Write("111");
}

internal class Strip
{
    public Color Color { get; set; }
    
    public byte Size { get; set; }
}

internal class CharBar : List<Strip>
{
    public char Char { get; set; }
}

internal enum Color
{
    White, Black,
}

