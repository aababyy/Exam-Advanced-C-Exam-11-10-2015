using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;

class SrabskoUnleashed
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, long>> data = new Dictionary<string, Dictionary<string, long>>();

        string line = Console.ReadLine();
        while (line != "End")
        {
            string venue = string.Empty;
            string singer = string.Empty;
            int ticketP = 0;
            int ticketC = 0;
            int money = 0;

            string pattern = @"([a-zA-Z\s]+)(\s\@)([a-zA-Z\s]+)(\s)([0-9]+)(\s)([0-9]+)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = Regex.Matches(line, pattern);
            if (matches.Count == 0)
            {
                line = Console.ReadLine();
                continue;
            }
            else
            {
                foreach (Match match in matches)
                {
                    venue = match.Groups[3].ToString();
                    singer = match.Groups[1].ToString();
                    ticketP = int.Parse(match.Groups[5].ToString());
                    ticketC = int.Parse(match.Groups[7].ToString());
                    money = ticketP * ticketC;

                    if (!data.ContainsKey(venue))
                    {
                        data.Add(venue, new Dictionary<string, long>());
                        data[venue].Add(singer, money);
                    }
                    else if (!data[venue].ContainsKey(singer))
                    {
                        data[venue].Add(singer, money);
                    }
                    else
                    {
                        data[venue][singer] = data[venue][singer] + money;
                    }
                    line = Console.ReadLine();
                }
            }
        }
        foreach (KeyValuePair<string, Dictionary<string, long>> kvp in data)
        {
            Console.WriteLine(kvp.Key);
            Dictionary<string, long> xx = kvp.Value;
            var sortedData = from pair in xx
                             orderby pair.Value descending
                             select pair;
            foreach (KeyValuePair<string, long> kvpSD in sortedData)
            {
                Console.WriteLine("#  {0} -> {1}", kvpSD.Key, kvpSD.Value);
            }
        }
    }
}
