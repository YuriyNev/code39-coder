using System.Diagnostics;

namespace Aspose.Coder39.Utilities;

public class WikiConverter
{
    public WikiConverter()
    {
        // Generate text view from https://en.wikipedia.org/wiki/Code_39
        Convert('A', "▮|| |▮");
        Convert('B', "|▮| |▮");
        Convert('C', "▮▮| ||");
        Convert('D', "||▮ |▮");
        Convert('E', "▮|▮ ||");
        Convert('F', "|▮▮ ||");
        Convert('G', "||| ▮▮");
        Convert('H', "▮|| ▮|");
        Convert('I', "|▮| ▮|");
        Convert('J', "||▮ ▮|");
        Convert('K', "▮||| ▮");
        Convert('L', "|▮|| ▮");
        Convert('M', "▮▮|| |");
        Convert('N', "||▮| ▮");
        Convert('O', "▮|▮| |");
        Convert('P', "|▮▮| |");
        Convert('Q', "|||▮ ▮");
        Convert('R', "▮||▮ |");
        Convert('S', "|▮|▮ |");
        Convert('T', "||▮▮ |");
        Convert('U', "▮ |||▮");
        Convert('V', "| ▮||▮");
        Convert('W', "▮ ▮|||");
        Convert('X', "| |▮|▮");
        Convert('Y', "▮ |▮||");
        Convert('Z', "| ▮▮||");
        Convert('-', "| ||▮▮");
        Convert('.', "▮ ||▮|");
        Convert(' ', "| ▮|▮|");
        Convert('*', "| |▮▮|");
        Convert('1', "▮| ||▮");
        Convert('2', "|▮ ||▮");
        Convert('3', "▮▮ |||");
        Convert('4', "|| ▮|▮");
        Convert('5', "▮| ▮||");
        Convert('6', "|▮ ▮||");
        Convert('7', "|| |▮▮");
        Convert('8', "▮| |▮|");
        Convert('9', "|▮ |▮|");
        Convert('0', "|| ▮▮|");
        Convert('$', "| | | ||");
        Convert('/', "| | || |");
        Convert('+', "| || | |");
        Convert('%', "|| | | |");
    }

    private void Convert(char c, string source)
    {
        const char narrowBar = '|';
        const char wideBar = '▮';
        const char wideSpace = ' ';

        const string narrowBarText = "1";
        const string wideBarText = "111";
        const string wideSpaceText = "000";
        const string narrowSpaceText = "0";
        
        string bin = string.Empty;
        
        for (var i = 0; i < source.Length; i++)
        {
            var current = source[i];
            var next = source[i + 1];
            
            bool notLast = i < source.Length - 1;
            
            var add = current switch
            {
                narrowBar => notLast 
                    ? next is narrowBar or wideBar 
                        ? narrowBarText + narrowSpaceText 
                        : narrowBarText 
                    : narrowBarText,
                wideBar => notLast 
                    ? next is narrowBar or wideBar 
                        ? wideBarText + narrowSpaceText 
                        : wideBarText : wideBarText,
                wideSpace => wideSpaceText,
                _ => string.Empty
            };

            bin += add;
        }

        Debug.Assert(bin.Length == 15);
        Console.WriteLine($"Mapping.Add('{c}', \"{bin}\".ParsePart(parseRule));");
    }
}