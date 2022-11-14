using Aspose.Coder39.Assistants;
using Aspose.Coder39.Services;
using CommandLine;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(o =>
    {
        Run(o.Action, o.Text);
    });

void Run(ConsoleAction action, string value)
{
    var coder = new Code39();

    if (action == ConsoleAction.Decode)
    {
        try
        {
            var barCode = value.ParseBarCode();
            var decodedText = coder.Decode(barCode);
            
            Console.WriteLine(decodedText);
        }
        catch
        {
            Console.WriteLine("Error: Cannot decode!");
        }
    } 
    else if (action == ConsoleAction.Encode)
    {
        try
        {
            var barCode = coder.Encode(value);
        
            Console.WriteLine(barCode);  
        }
        catch
        {
            Console.WriteLine("Error: Cannot encode!");
        }
    }
}

public class Options
{
    [Option('a', "action", Required = true, HelpText = "Action: 'Decode' or 'Encode'")]
    public ConsoleAction Action { get; set; }
    
    [Option('v', "value", Required = true, HelpText = "Value for the action")]
    public string Text { get; set; } = null!;
}

public enum ConsoleAction
{
    Decode, Encode,
}