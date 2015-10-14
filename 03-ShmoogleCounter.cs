using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class SC
{
    static void Main()
    {
        StringBuilder text = new StringBuilder();
        string line = Console.ReadLine();
        while (line != "//END_OF_CODE")
        {
            text.Append(line);
            line = Console.ReadLine();
        }
        string patternI = @"(?<=\bint\b\s)([a-z0-9_]+[\w]*)";
        string patternD = @"(?<=\bdouble\b\s)([a-z0-9_]+[\w]*)";
        Regex regexI = new Regex(patternI);
        Regex regexD = new Regex(patternD);

        MatchCollection matchesI = Regex.Matches(text.ToString(), patternI);
        MatchCollection matchesD = Regex.Matches(text.ToString(), patternD);
        
        if (matchesD.Count == 0)
        {
            Console.Write("Doubles: None");
        }
        else
        {
            List<string> dd = new List<string>();
            Console.Write("Doubles: ");
            foreach (var match in matchesD)
            {
                string d = match.ToString();
                dd.Add(d);
            }
            dd.Sort();
            Console.Write(String.Join(", ", dd));
        }
        Console.WriteLine();
        if (matchesI.Count == 0)
        {
            Console.WriteLine("Ints: None");
        }
        else
        {
            List<string> ii = new List<string>();
            Console.Write("Ints: ");
            foreach (var match in matchesI)
            {
                string i = match.ToString();
                ii.Add(i);
            }
            ii.Sort();
            Console.Write(String.Join(", ", ii));
        }
        Console.WriteLine();
    }
}
