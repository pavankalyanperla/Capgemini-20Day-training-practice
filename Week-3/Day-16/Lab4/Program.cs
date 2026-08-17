try
{
    GetTimeoutSetting();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Top-level: {ex.Message}");
    Console.WriteLine($"Caused by: {ex.InnerException?.Message}");
    Console.WriteLine($"Inner exception type: {ex.InnerException?.GetType().Name}");
}

Console.WriteLine("\n-- PrintExceptionChain --");
try
{
    GetTimeoutSetting();
}
catch (InvalidOperationException ex)
{
    PrintExceptionChain(ex);
}

Console.WriteLine("\n-- Bonus: three-level exception chain --");
try
{
    LoadConfiguration();
}
catch (ConfigurationException ex)
{
    PrintExceptionChain(ex);
}

static string ReadRawConfigValue(string key)
{
    if (key == "timeout")
        throw new FormatException("Value 'abc' is not a valid integer");
    if (key == "maxRetries")
        throw new FormatException("Value 'many' is not a valid integer");
    return "dummy-value";
}

static int GetTimeoutSetting()
{
    try
    {
        string raw = ReadRawConfigValue("timeout");
        return int.Parse(raw);
    }
    catch (FormatException ex)
    {
        throw new InvalidOperationException("Application configuration is invalid", ex);
    }
}

static int GetMaxRetriesSetting()
{
    try
    {
        string raw = ReadRawConfigValue("maxRetries");
        return int.Parse(raw);
    }
    catch (FormatException ex)
    {
        throw new InvalidOperationException("Retry configuration is invalid", ex);
    }
}

static void LoadConfiguration()
{
    try
    {
        GetMaxRetriesSetting();
    }
    catch (InvalidOperationException ex)
    {
        throw new ConfigurationException("Could not load application configuration", ex);
    }
}

static void PrintExceptionChain(Exception ex)
{
    Exception? current = ex;
    int depth = 0;
    while (current != null)
    {
        string indent = new string(' ', depth * 2);
        Console.WriteLine($"{indent}{current.GetType().Name}: {current.Message}");
        current = current.InnerException;
        depth++;
    }
}

public class ConfigurationException : Exception
{
    public ConfigurationException() : base() { }
    public ConfigurationException(string message) : base(message) { }
    public ConfigurationException(string message, Exception inner) : base(message, inner) { }
}
