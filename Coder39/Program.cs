using CommandLine;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed<Options>(o =>
    {
        if (o.Action)
        {
            Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
            Console.WriteLine("Quick Start Example! App is in Verbose mode!");
        }
        else
        {
            Console.WriteLine($"Current Arguments: -v {o.Verbose}");
            Console.WriteLine("Quick Start Example!");
        }
    });

public class Options
{
    [Option('a', "action", Required = true, HelpText = "Action: 'decode' or 'encode'")]
    public ConsoleAction? Action { get; set; }
    
    [Option('v', "value", Required = true, HelpText = "Input text")]
    public string Text { get; set; }
}

public enum ConsoleAction
{
    Decode, Encode,
}