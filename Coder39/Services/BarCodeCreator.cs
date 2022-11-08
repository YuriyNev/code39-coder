namespace Aspose.Coder39.Services;

public class BarCodeCreator
{
    public string Method(string source)
    {
        var a1 = CharBarFactory.A();
        var a2 = CharBarFactory.A();
        
        return $"{a1.TextView()}{a2.TextView()}";
    }
}