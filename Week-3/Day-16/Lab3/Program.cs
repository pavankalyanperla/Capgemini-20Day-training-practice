try
{
    CallSiteGood(10, 0);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Good stack trace mentions: DivideInternal -> {ex.StackTrace?.Contains("DivideInternal")}");
}

try
{
    CallSiteBad(10, 0);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Bad stack trace mentions DivideInternal: {ex.StackTrace?.Contains("DivideInternal")}   (starts at CallSiteBad instead)");
}

try
{
    Validate(-5);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Validate(-5) threw: {ex.Message}");
}

Console.WriteLine("\n-- Bonus: three-level call chain --");
try
{
    OuterCaller(10, 0);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Three-level chain mentions DivideInternal: {ex.StackTrace?.Contains("DivideInternal")}");
    Console.WriteLine($"Three-level chain mentions CallSiteGood: {ex.StackTrace?.Contains("CallSiteGood")}");
}

static int DivideInternal(int a, int b)
{
    if (b == 0) throw new DivideByZeroException("Cannot divide by zero in DivideInternal");
    return a / b;
}

static int CallSiteGood(int a, int b)
{
    try { return DivideInternal(a, b); }
    catch (DivideByZeroException)
    {
        Console.WriteLine("[Good] Logging before rethrow...");
        throw;   // preserves the original stack trace, including DivideInternal
    }
}

static int CallSiteBad(int a, int b)
{
    try { return DivideInternal(a, b); }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine("[Bad] Logging before rethrow...");
        throw ex;   // resets the stack trace to start here, at CallSiteBad
    }
}

static int Validate(int value)
{
    if (value < 0)
        throw new ArgumentOutOfRangeException(nameof(value), "Value must not be negative");
    return value;
}

static int OuterCaller(int a, int b) => CallSiteGood(a, b);
