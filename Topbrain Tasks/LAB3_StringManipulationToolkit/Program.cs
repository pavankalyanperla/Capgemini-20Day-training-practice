using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

static class StringToolkit
{
    // 1. Reverse a string
    public static string Reverse(string input)
    {
        char[] characters = input.ToCharArray();

        Array.Reverse(characters);

        return new string(characters);
    }

    // 2. Count occurrences of a character
    public static int CountChar(string text, char searchChar)
    {
        int count = 0;

        foreach (char c in text)
        {
            if (c == searchChar)
            {
                count++;
            }
        }

        return count;
    }

    // 3. Remove duplicate characters
    public static string RemoveDuplicates(string input)
    {
        StringBuilder result = new StringBuilder();

        foreach (char c in input)
        {
            if (!result.ToString().Contains(c))
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }

    // 4. Check whether a string is a palindrome
    // Ignores case and spaces
    public static bool IsPalindrome(string input)
    {
        string cleaned = input
            .Replace(" ", "")
            .ToLower();

        string reversed = Reverse(cleaned);

        return cleaned == reversed;
    }

    // 5. Convert string to title case
    public static string ToTitleCase(string input)
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

        return textInfo.ToTitleCase(input.ToLower());
    }

    // 6. Extract only digits
    public static string ExtractNumbers(string input)
    {
        StringBuilder result = new StringBuilder();

        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }

    // Bonus: Word frequency
    public static Dictionary<string, int> WordFrequency(string text)
    {
        Dictionary<string, int> frequency =
            new Dictionary<string, int>();

        string[] words = text
            .ToLower()
            .Split(
                new char[] 
                {
                    ' ', ',', '.', '!', '?', ';', ':'
                },
                StringSplitOptions.RemoveEmptyEntries
            );

        foreach (string word in words)
        {
            if (frequency.ContainsKey(word))
            {
                frequency[word]++;
            }
            else
            {
                frequency[word] = 1;
            }
        }

        return frequency;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("======================================");
        Console.WriteLine("       STRING MANIPULATION TOOLKIT");
        Console.WriteLine("======================================");
        Console.WriteLine();

        // 1. Reverse
        Console.WriteLine(
            "Reverse(\"Hello\") -> " +
            "\"" + StringToolkit.Reverse("Hello") + "\""
        );

        // 2. CountChar
        Console.WriteLine(
            "CountChar(\"banana\", 'a') -> " +
            StringToolkit.CountChar("banana", 'a')
        );

        // 3. RemoveDuplicates
        Console.WriteLine(
            "RemoveDuplicates(\"mississippi\") -> " +
            "\"" + StringToolkit.RemoveDuplicates("mississippi") + "\""
        );

        // 4. IsPalindrome
        Console.WriteLine(
            "IsPalindrome(\"race car\") -> " +
            StringToolkit.IsPalindrome("race car")
        );

        // 5. ToTitleCase
        Console.WriteLine(
            "ToTitleCase(\"hello training team\") -> " +
            "\"" + StringToolkit.ToTitleCase(
                "hello training team"
            ) + "\""
        );

        // 6. ExtractNumbers
        Console.WriteLine(
            "ExtractNumbers(\"Order #4521, qty 3\") -> " +
            "\"" + StringToolkit.ExtractNumbers(
                "Order #4521, qty 3"
            ) + "\""
        );

        // Bonus
        Console.WriteLine();
        Console.WriteLine("Word Frequency:");

        string sentence =
            "Hello world, hello training team.";

        Dictionary<string, int> frequencies =
            StringToolkit.WordFrequency(sentence);

        foreach (var item in frequencies)
        {
            Console.WriteLine(
                item.Key + " -> " + item.Value
            );
        }
    }
}