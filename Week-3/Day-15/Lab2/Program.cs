using System.Text.RegularExpressions;

string text = "Order #4521 was shipped. order #99 is pending. ORDER #12345 was cancelled.";
// TODO 1: Matches + IgnoreCase - print each order number
var orderMatches = Regex.Matches(text, @"order\s*#(\d+)", RegexOptions.IgnoreCase);
var orderNumbers = orderMatches.Select(m => m.Groups[1].Value);
Console.WriteLine($"Order numbers found: {string.Join(", ", orderNumbers)}");

string cardText = "Card on file: 4111-1111-1111-1234";
// TODO 2: Replace to mask all but the last 4 digits
string maskedCard = Regex.Replace(cardText, @"\b(\d{4})[- ]?(\d{4})[- ]?(\d{4})[- ]?(\d{4})\b", "XXXX-XXXX-XXXX-$4");
Console.WriteLine($"Masked card: {maskedCard.Replace("Card on file: ", "")}");

string names = "Smith, John";
// TODO 3: Replace with capturing groups -> "John Smith"
string reformattedName = Regex.Replace(names, @"^(\w+),\s*(\w+)$", "$2 $1");
Console.WriteLine($"Reformatted name: {reformattedName}");

string tags = "red, blue;green , yellow";
// TODO 4: Split into a clean array of trimmed tags
string[] tagArray = Regex.Split(tags, @"\s*[,;]\s*");
Console.WriteLine($"Tags: [{string.Join(", ", tagArray)}]");

// Bonus: also capture and print the ORIGINAL casing of "order"/"Order"/"ORDER" alongside each number.
Console.WriteLine("\nBonus - order word casing + number:");
var orderMatchesWithCasing = Regex.Matches(text, @"(order)\s*#(\d+)", RegexOptions.IgnoreCase);
foreach (Match match in orderMatchesWithCasing)
{
    Console.WriteLine($" - \"{match.Groups[1].Value}\" -> {match.Groups[2].Value}");
}
