using System.Text.RegularExpressions;

// IgnoreCase demo
bool ignoreCaseOff = Regex.IsMatch("HELLO", "hello");
bool ignoreCaseOn = Regex.IsMatch("HELLO", "hello", RegexOptions.IgnoreCase);
Console.WriteLine($"IgnoreCase off: {ignoreCaseOff}, IgnoreCase on: {ignoreCaseOn}");

// Multiline demo - count ^ matches with and without RegexOptions.Multiline
string multiLineText = "First line\nSecond line\nThird line";
int withoutMultiline = Regex.Matches(multiLineText, "^").Count;
int withMultiline = Regex.Matches(multiLineText, "^", RegexOptions.Multiline).Count;
Console.WriteLine($"Line-start matches WITHOUT Multiline: {withoutMultiline}");
Console.WriteLine($"Line-start matches WITH Multiline: {withMultiline}");

// exercise PatternLibrary with valid/invalid samples
Console.WriteLine($"IsValidEmail(\"a@b.com\"): {PatternLibrary.IsValidEmail("a@b.com")}, " +
                   $"IsValidEmail(\"not-an-email\"): {PatternLibrary.IsValidEmail("not-an-email")}");
Console.WriteLine($"IsValidPhone(\"555-123-4567\"): {PatternLibrary.IsValidPhone("555-123-4567")}, " +
                   $"IsValidPhone(\"5551234567\"): {PatternLibrary.IsValidPhone("5551234567")}");
Console.WriteLine($"IsValidHexColor(\"#1A2B3C\"): {PatternLibrary.IsValidHexColor("#1A2B3C")}, " +
                   $"IsValidHexColor(\"1A2B3C\"): {PatternLibrary.IsValidHexColor("1A2B3C")}");

// Bonus: MatchTimeout around a deliberately slow, ambiguous pattern.
try
{
    var slowRegex = new Regex(@"(a+)+$", RegexOptions.None, TimeSpan.FromMilliseconds(200));
    string slowInput = new string('a', 40) + "!";
    Console.WriteLine($"\nSlow pattern match result: {slowRegex.IsMatch(slowInput)}");
}
catch (RegexMatchTimeoutException ex)
{
    Console.WriteLine($"\nRegexMatchTimeoutException caught: pattern took longer than {ex.MatchTimeout.TotalMilliseconds}ms");
}

public static class PatternLibrary
{
    // static readonly Regex Email, UsPhone, HexColor (RegexOptions.Compiled)
    public static readonly Regex Email = new(@"^[\w.+-]+@[\w-]+\.[A-Za-z]{2,}$", RegexOptions.Compiled);
    public static readonly Regex UsPhone = new(@"^\d{3}-\d{3}-\d{4}$", RegexOptions.Compiled);
    public static readonly Regex HexColor = new(@"^#[0-9A-Fa-f]{6}$", RegexOptions.Compiled);

    // IsValidEmail, IsValidPhone, IsValidHexColor wrapper methods
    public static bool IsValidEmail(string value) => Email.IsMatch(value);
    public static bool IsValidPhone(string value) => UsPhone.IsMatch(value);
    public static bool IsValidHexColor(string value) => HexColor.IsMatch(value);
}
