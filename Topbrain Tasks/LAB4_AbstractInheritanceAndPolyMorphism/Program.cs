// Lab 4: Abstract Classes, Inheritance & Polymorphism

using System;
using System.Collections.Generic;

public abstract class Employee
{
    public string Name        { get; }
    public decimal BaseSalary { get; }

    protected Employee(string name, decimal baseSalary)
    {
        Name       = name;
        BaseSalary = baseSalary;
    }

    // Each subclass must define how pay is calculated
    public abstract decimal CalculatePay();

    // Concrete method: works correctly for every subclass via polymorphism
    public void PrintPaySlip() => Console.WriteLine($"{Name}: {CalculatePay():C}");
}

public class SalariedEmployee : Employee
{
    public SalariedEmployee(string name, decimal baseSalary)
        : base(name, baseSalary) { }

    public override decimal CalculatePay() => BaseSalary;
}

public class CommissionEmployee : Employee
{
    public decimal CommissionEarned;

    public CommissionEmployee(string name, decimal baseSalary, decimal commission)
        : base(name, baseSalary) => CommissionEarned = commission;

    public override decimal CalculatePay() => BaseSalary + CommissionEarned;
}

// Bonus: ManagerEmployee overrides CalculatePay() and calls base
public class ManagerEmployee : SalariedEmployee
{
    public decimal Bonus;

    public ManagerEmployee(string name, decimal baseSalary, decimal bonus)
        : base(name, baseSalary) => Bonus = bonus;

    public override decimal CalculatePay() => base.CalculatePay() + Bonus;
}

public class Lab4
{
    public static void Main()
    {
        // Polymorphic list — held as Employee references
        var employees = new List<Employee>
        {
            new SalariedEmployee("Alice", 4500m),
            new CommissionEmployee("Bob", 2700m, 500m),
            new CommissionEmployee("Carla", 3200m, 950m),

            // Bonus: manager with a flat bonus on top
            new ManagerEmployee("Diana", 5000m, 1500m)
        };

        // Correct CalculatePay() fires for each via polymorphism
        foreach (var emp in employees)
            emp.PrintPaySlip();

        // Compiler blocks this — uncomment to see the error:
        // var e = new Employee("Test", 0m);
    }
}