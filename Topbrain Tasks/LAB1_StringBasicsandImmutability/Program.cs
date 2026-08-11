using System;

class Lab1
{
    static void Main()
    {
        string original = "  Hello, Training Team!  ";

        // TODO 1: Trim the string into a new variable
        string trimmed = original.Trim();

        // TODO 2: Compare original and trimmed
        Console.WriteLine(
            "ReferenceEquals(original, trimmed): " +
            object.ReferenceEquals(original, trimmed)
        );

        // TODO 3: Contains / StartsWith / IndexOf / Replace

        Console.WriteLine(
            "Contains \"Training\": " +
            trimmed.Contains("Training")
        );

        Console.WriteLine(
            "StartsWith trimmed \"Hello\": " +
            trimmed.StartsWith("Hello")
        );

        Console.WriteLine(
            "Index of first comma: " +
            trimmed.IndexOf(',')
        );

        string replaced = trimmed.Replace(
            "Training Team",
            "Engineering Team"
        );

        Console.WriteLine(
            "\"Training Team\" replaced -> " +
            replaced
        );

        // TODO 4: Split into words
        string[] words = trimmed.Split(
            new char[] { ' ', ',' },
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (string word in words)
        {
            Console.WriteLine(word);
        }

        // TODO 5: IsNullOrWhiteSpace checks

        string nullString = null;

        Console.WriteLine(
            "IsNullOrWhiteSpace(null): " +
            string.IsNullOrWhiteSpace(nullString)
        );

        Console.WriteLine(
            "IsNullOrWhiteSpace(\"\"): " +
            string.IsNullOrWhiteSpace("")
        );

        Console.WriteLine(
            "IsNullOrWhiteSpace(\"   \"): " +
            string.IsNullOrWhiteSpace("   ")
        );

        Console.WriteLine(
            "IsNullOrWhiteSpace(\"ok\"): " +
            string.IsNullOrWhiteSpace("ok")
        );

        // Bonus Challenge
        string first = "HELLO";
        string second = "hello";

        int comparison = string.Compare(
            first,
            second,
            StringComparison.OrdinalIgnoreCase
        );

        Console.WriteLine(
            "Case-insensitive comparison result: " +
            comparison
        );

        // OrdinalIgnoreCase ignores differences in uppercase/lowercase,
        // so "HELLO" and "hello" are considered equal and the result is 0.
    }
}