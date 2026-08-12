using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

class LogEntry
{
    public DateTime Timestamp { get; set; }
    public string LogLevel { get; set; }
    public string Message { get; set; }
    public string Exception { get; set; }

    public LogEntry(
        DateTime timestamp,
        string logLevel,
        string message,
        string exception = "")
    {
        Timestamp = timestamp;
        LogLevel = logLevel;
        Message = message;
        Exception = exception;
    }
}

class LogProcessor
{
    private StringBuilder buffer;
    private int bufferCapacity;

    private string logFile;
    private List<LogEntry> errorLogs;

    public LogProcessor(int capacity, string fileName)
    {
        bufferCapacity = capacity;
        logFile = fileName;

        buffer = new StringBuilder();
        errorLogs = new List<LogEntry>();
    }

    public void ProcessLog(LogEntry log)
    {
        // StringBuilder is used to efficiently create the log message
        StringBuilder logMessage = new StringBuilder();

        logMessage.Append("[");
        logMessage.Append(log.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
        logMessage.Append("] ");

        logMessage.Append(log.LogLevel);
        logMessage.Append(": ");
        logMessage.Append(log.Message);

        // Add exception if available
        if (!string.IsNullOrWhiteSpace(log.Exception))
        {
            logMessage.Append(" | Exception: ");
            logMessage.Append(log.Exception);
        }

        logMessage.AppendLine();

        // Add formatted log to buffer
        buffer.Append(logMessage);

        // Store ERROR logs separately
        if (log.LogLevel.Equals("ERROR", StringComparison.OrdinalIgnoreCase))
        {
            errorLogs.Add(log);
        }

        Console.WriteLine("Log processed: " + log.LogLevel);

        // Flush when buffer reaches capacity
        if (buffer.Length >= bufferCapacity)
        {
            FlushBuffer();
        }
    }

    public void FlushBuffer()
    {
        if (buffer.Length == 0)
        {
            return;
        }

        File.AppendAllText(logFile, buffer.ToString());

        Console.WriteLine(
            "Buffer flushed to file. Characters written: "
            + buffer.Length);

        buffer.Clear();
    }

    public void DisplayErrorSummary()
    {
        Console.WriteLine();
        Console.WriteLine("=================================");
        Console.WriteLine("        ERROR SUMMARY");
        Console.WriteLine("=================================");

        Console.WriteLine("Total Errors: " + errorLogs.Count);

        foreach (LogEntry error in errorLogs)
        {
            Console.WriteLine(
                $"{error.Timestamp:yyyy-MM-dd HH:mm:ss} | " +
                $"{error.Message}");

            if (!string.IsNullOrWhiteSpace(error.Exception))
            {
                Console.WriteLine(
                    "Exception: " + error.Exception);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        string logFile = "application.log";

        // Buffer capacity
        int bufferCapacity = 200;

        LogProcessor processor =
            new LogProcessor(bufferCapacity, logFile);

        // Create log entries
        List<LogEntry> logs = new List<LogEntry>
        {
            new LogEntry(
                DateTime.Now,
                "INFO",
                "Application started"),

            new LogEntry(
                DateTime.Now,
                "INFO",
                "User logged in"),

            new LogEntry(
                DateTime.Now,
                "WARNING",
                "Memory usage is high"),

            new LogEntry(
                DateTime.Now,
                "ERROR",
                "Database connection failed",
                "SqlException: Connection timeout"),

            new LogEntry(
                DateTime.Now,
                "INFO",
                "Retrying database connection"),

            new LogEntry(
                DateTime.Now,
                "ERROR",
                "File could not be processed",
                "FileNotFoundException"),

            new LogEntry(
                DateTime.Now,
                "INFO",
                "Application processing completed")
        };

        // Process every log
        foreach (LogEntry log in logs)
        {
            processor.ProcessLog(log);
        }

        // Flush remaining logs
        processor.FlushBuffer();

        // Display errors
        processor.DisplayErrorSummary();

        Console.WriteLine();
        Console.WriteLine("Log file: " + logFile);

        Console.ReadLine();
    }
}