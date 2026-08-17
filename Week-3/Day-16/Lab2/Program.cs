Console.WriteLine("-- Process(0) --");
Process(0);

Console.WriteLine("\n-- Process(1) --");
try
{
    Process(1);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}

Console.WriteLine("\n-- Process(2) --");
Process(2);

Console.WriteLine("\n-- using / IDisposable --");
try
{
    UseFakeHandle();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}

static void Process(int mode)
{
    Console.WriteLine("Opening");
    try
    {
        if (mode == 1) throw new InvalidOperationException("Simulated failure");
        Console.WriteLine("Working");
        if (mode == 2) return;
        Console.WriteLine("Finishing normally");
    }
    finally
    {
        Console.WriteLine("Closing");
    }
}

static void UseFakeHandle()
{
    using (var handle = new FakeFileHandle())
    {
        throw new InvalidOperationException("Simulated failure while handle was open");
    }
}

class FakeFileHandle : IDisposable
{
    public FakeFileHandle() => Console.WriteLine("Handle opened");
    public void Dispose() => Console.WriteLine("Handle closed");
}

// Bonus: nested try/finally trace.
//
// try
// {
//     Console.WriteLine("Outer try");
//     try
//     {
//         Console.WriteLine("Inner try");
//         throw new Exception("boom");
//     }
//     finally
//     {
//         Console.WriteLine("Inner finally");
//     }
// }
// finally
// {
//     Console.WriteLine("Outer finally");
// }
//
// Execution order: "Outer try" -> "Inner try" -> exception thrown -> the inner
// finally runs FIRST ("Inner finally") while the exception is propagating outward,
// then the outer finally runs ("Outer finally"), and only after both finally blocks
// have completed does the exception continue propagating to any enclosing catch (or
// crash the program if unhandled). Finally blocks always run innermost-to-outermost,
// regardless of whether the exception is ultimately caught.
