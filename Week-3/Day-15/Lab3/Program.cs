using System.Text.RegularExpressions;
using System.Globalization;

string logLine = "2026-08-14 09:15:32 ERROR Connection timed out";
// TODO 1: named groups for date/time/level/message, print each
string logPattern = @"^(?<date>\d{4}-\d{2}-\d{2})\s+(?<time>\d{2}:\d{2}:\d{2})\s+(?<level>\w+)\s+(?<message>.+)$";
Match logMatch = Regex.Match(logLine, logPattern);
Console.WriteLine($"date={logMatch.Groups["date"].Value}, time={logMatch.Groups["time"].Value}, " +
                   $"level={logMatch.Groups["level"].Value}, message={logMatch.Groups["message"].Value}");

string kvText = "name=Alice;age=30;city=NYC";
// TODO 2: named groups (?<key>...) and (?<value>...), print all pairs
string kvPattern = @"(?<key>\w+)=(?<value>[^;]+)";
foreach (Match kv in Regex.Matches(kvText, kvPattern))
{
    Console.WriteLine($"{kv.Groups["key"].Value}={kv.Groups["value"].Value}");
}

string numbers = "Revenue: 1234567, Costs: 89000";
// TODO 3: MatchEvaluator - format numbers with thousands separators
string formattedNumbers = Regex.Replace(numbers, @"\d+", match =>
    long.Parse(match.Value, CultureInfo.InvariantCulture).ToString("N0", CultureInfo.InvariantCulture));
Console.WriteLine(formattedNumbers);

string shouting = "THIS IS URGENT please respond";
// TODO 4: MatchEvaluator - convert ALL CAPS words to Title Case
string titleCased = Regex.Replace(shouting, @"\b[A-Z]{2,}\b", match =>
    char.ToUpperInvariant(match.Value[0]) + match.Value.Substring(1).ToLowerInvariant());
Console.WriteLine(titleCased);

// Bonus: parse a small log with several lines; for ERROR lines, zero-pad numeric error codes to 5 digits.
string miniLog =
    "2026-08-14 09:15:00 INFO Service started\n" +
    "2026-08-14 09:17:45 ERROR Request failed code=404\n" +
    "2026-08-14 09:19:22 ERROR Upstream error code=500\n";

string zeroPaddedLog = Regex.Replace(miniLog, @"^(?<date>\d{4}-\d{2}-\d{2})\s(?<time>\d{2}:\d{2}:\d{2})\sERROR\s(?<message>.*code=(?<code>\d+).*)$",
    match =>
    {
        string code = match.Groups["code"].Value.PadLeft(5, '0');
        string message = Regex.Replace(match.Groups["message"].Value, @"code=\d+", $"code={code}");
        return $"{match.Groups["date"].Value} {match.Groups["time"].Value} ERROR {message}";
    }, RegexOptions.Multiline);

Console.WriteLine("\nBonus - zero-padded error codes:");
Console.WriteLine(zeroPaddedLog);
