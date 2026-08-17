using System.Text.RegularExpressions;

string rawLog =
    "2026-08-14 09:15:00 INFO Service started\n" +
    "2026-08-14 09:16:12 WARN Disk usage high\n" +
    "2026-08-14 09:17:45 ERROR Request failed code=404\n" +
    "2026-08-14 09:18:03 INFO Request completed\n" +
    "2026-08-14 09:19:22 ERROR Upstream error code=500\n" +
    "2026-08-14 09:20:00 INFO Shutdown complete";

List<LogEntry> entries = ParseLog(rawLog);
Console.WriteLine($"Parsed {entries.Count} entries.");

var summary = entries
    .GroupBy(e => e.Level)
    .Select(g => $"{g.Key}: {g.Count()}");
Console.WriteLine($"Summary: {string.Join(", ", summary)}");

Console.WriteLine("\n--- Redacted log ---");
Console.WriteLine(RedactErrorCodes(rawLog));

// Bonus: errors within a time range.
var errorsInRange = FindErrorsInRange(entries, "09:17:00", "09:19:30");
Console.WriteLine("\nBonus - errors between 09:17:00 and 09:19:30:");
foreach (var error in errorsInRange)
    Console.WriteLine($" - {error.Time} {error.Message}");

static List<LogEntry> ParseLog(string rawLog)
{
    string pattern = @"^(?<date>\d{4}-\d{2}-\d{2}) (?<time>\d{2}:\d{2}:\d{2}) (?<level>INFO|WARN|ERROR) (?<message>.+)$";
    var entries = new List<LogEntry>();

    foreach (Match match in Regex.Matches(rawLog, pattern, RegexOptions.Multiline))
    {
        entries.Add(new LogEntry
        {
            Date = match.Groups["date"].Value,
            Time = match.Groups["time"].Value,
            Level = match.Groups["level"].Value,
            Message = match.Groups["message"].Value
        });
    }

    return entries;
}

static string RedactErrorCodes(string rawLog)
{
    string errorLinePattern = @"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2} ERROR .*$";
    return Regex.Replace(rawLog, errorLinePattern,
        match => Regex.Replace(match.Value, @"code=\d+", "code=###"),
        RegexOptions.Multiline);
}

static IEnumerable<LogEntry> FindErrorsInRange(List<LogEntry> entries, string startTime, string endTime)
{
    return entries.Where(e =>
        e.Level == "ERROR" &&
        string.Compare(e.Time, startTime, StringComparison.Ordinal) >= 0 &&
        string.Compare(e.Time, endTime, StringComparison.Ordinal) <= 0);
}

public class LogEntry
{
    public string Date { get; init; } = string.Empty;
    public string Time { get; init; } = string.Empty;
    public string Level { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
}
