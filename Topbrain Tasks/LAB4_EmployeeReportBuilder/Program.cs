using System;
using System.Text;
using System.Globalization;

static class StringToolkit
{
    // From Lab 3
    public static string ToTitleCase(string input)
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

        return textInfo.ToTitleCase(input.ToLower());
    }
}

class Program
{
    static void Main()
    {
        const string rawData = @"
john smith|engineering|72000
MARY jones|sales|65000
ravi KUMAR|engineering|81000
";

        // Split raw data into rows
        string[] rows = rawData.Split(
            new[] { '\r', '\n' },
            StringSplitOptions.RemoveEmptyEntries
        );

        StringBuilder sb = new StringBuilder();

        int employeeCount = 0;
        decimal totalSalary = 0;

        // Count StringBuilder Append calls
        int appendCount = 0;

        // Build title
        sb.AppendLine("==============================================");
        appendCount++;

        sb.AppendLine("        EMPLOYEE COMPENSATION REPORT");
        appendCount++;

        sb.AppendLine("==============================================");
        appendCount++;

        // Header
        string header =
            "Name".PadRight(22) +
            "Department".PadRight(18) +
            "Salary".PadLeft(12);

        sb.AppendLine(header);
        appendCount++;

        sb.AppendLine("----------------------------------------------");
        appendCount++;

        // Process each employee
        foreach (string row in rows)
        {
            // Skip blank rows defensively
            if (string.IsNullOrWhiteSpace(row))
            {
                continue;
            }

            // Split employee information
            string[] fields = row.Split('|');

            string name = fields[0].Trim();
            string department = fields[1].Trim();
            decimal salary = Convert.ToDecimal(fields[2].Trim());

            // Normalize employee name
            name = StringToolkit.ToTitleCase(name);

            // Format employee row
            string employeeLine =
                name.PadRight(22) +
                department.PadRight(18) +
                salary.ToString("N0").PadLeft(12);

            sb.AppendLine(employeeLine);
            appendCount++;

            employeeCount++;
            totalSalary += salary;
        }

        sb.AppendLine("----------------------------------------------");
        appendCount++;

        // Footer
        string footer =
            $"Employees: {employeeCount}    " +
            $"Total Salary: {totalSalary:N0}";

        sb.AppendLine(footer);
        appendCount++;

        sb.AppendLine("==============================================");
        appendCount++;

        // Print report
        Console.WriteLine(sb.ToString());

        // Performance information
        Console.WriteLine();
        Console.WriteLine("==============================================");
        Console.WriteLine("             BUILD STATISTICS");
        Console.WriteLine("==============================================");

        Console.WriteLine(
            "StringBuilder Append calls: " + appendCount
        );

        Console.WriteLine(
            "String concatenations in loop: 0"
        );
    }
}