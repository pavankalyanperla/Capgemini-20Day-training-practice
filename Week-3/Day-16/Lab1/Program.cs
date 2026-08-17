static int ParseAge(string input)
{
    Console.WriteLine("Step 1");

    // Bonus: a more specific empty-input check that throws a plain ArgumentException
    // (not the ArgumentOutOfRangeException subtype) so it's caught by a different block.
    if (string.IsNullOrEmpty(input))
        throw new ArgumentException("Input cannot be empty", nameof(input));

    int age = int.Parse(input);   // may throw FormatException
    if (age < 0 || age > 150)
        throw new ArgumentOutOfRangeException(nameof(input), "Age must be between 0 and 150");
    Console.WriteLine("Step 2 (only if valid)");
    return age;
}

Console.WriteLine("-- ParseAge(\"abc\") --");
try
{
    ParseAge("abc");
}
catch (FormatException ex)
{
    Console.WriteLine($"Caught FormatException: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Caught general Exception: {ex.Message}");
}

Console.WriteLine("\n-- ParseAge(\"200\") --");
try
{
    // Three catch blocks in CORRECT order: most specific first.
    ParseAge("200");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Caught ArgumentOutOfRangeException (most specific, ran first): {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Caught ArgumentException: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Caught general Exception: {ex.Message}");
}

// TODO (illustration only, not compiled): the WRONG order below would refuse to build.
//
// try { ParseAge("200"); }
// catch (Exception ex) { ... }
// catch (ArgumentOutOfRangeException ex) { ... }   

Console.WriteLine("\n-- ParseAge(\"30\") --");
try
{
    int result = ParseAge("30");
    Console.WriteLine($"Result: {result}");
}
catch (Exception ex)
{
    Console.WriteLine($"Caught general Exception: {ex.Message}");
}

Console.WriteLine("\n-- Bonus: ParseAge(\"\") --");
try
{
    ParseAge("");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Caught ArgumentOutOfRangeException: {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Caught ArgumentException (not the Range subtype): {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Caught general Exception: {ex.Message}");
}
