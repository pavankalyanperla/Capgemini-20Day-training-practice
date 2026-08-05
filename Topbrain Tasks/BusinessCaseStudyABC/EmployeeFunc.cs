using System;
using System.Collections.Generic;

class Employee
{
    public int Id;
    public string Name;
    public string Designation;
    public string Department;
    public int ManagerId;

    public Employee(int id, string name, string designation,
                    string department, int managerId)
    {
        Id = id;
        Name = name;
        Designation = designation;
        Department = department;
        ManagerId = managerId;
    }

    public void Display()
    {
        Console.WriteLine($"{Id} | {Name} | {Designation} | {Department}");
    }
}



class EmployeeFunctions
{
    // Display Complete Organization Chart
    public static void DisplayOrganization(List<Employee> employees, int managerId, string indent)
    {
        foreach (Employee emp in employees)
        {
            if (emp.ManagerId == managerId)
            {
                Console.WriteLine(indent + emp.Name + " (" + emp.Designation + ")");
                DisplayOrganization(employees, emp.Id, indent + "    ");
            }
        }
    }

    // Search by Employee ID
    public static void SearchById(List<Employee> employees, int id)
    {
        foreach (Employee emp in employees)
        {
            if (emp.Id == id)
            {
                emp.Display();
                return;
            }
        }

        Console.WriteLine("Employee Not Found.");
    }

    // Search by Employee Name
    public static void SearchByName(List<Employee> employees, string name)
    {
        bool found = false;

        foreach (Employee emp in employees)
        {
            if (emp.Name.ToLower().Contains(name.ToLower()))
            {
                emp.Display();
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("Employee Not Found.");
    }

    // Display Employees under a Manager
    public static void EmployeesUnderManager(List<Employee> employees, int managerId)
    {
        bool found = false;

        foreach (Employee emp in employees)
        {
            if (emp.ManagerId == managerId)
            {
                emp.Display();
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No Employees.");
    }

    // Count Total Employees under Manager (Recursive)
    public static int CountEmployees(List<Employee> employees, int managerId)
    {
        int count = 0;

        foreach (Employee emp in employees)
        {
            if (emp.ManagerId == managerId)
            {
                count++;
                count += CountEmployees(employees, emp.Id);
            }
        }

        return count;
    }

    // Display Hierarchy Level
    public static int GetLevel(List<Employee> employees, int employeeId)
    {
        Employee current = null;

        foreach (Employee emp in employees)
        {
            if (emp.Id == employeeId)
            {
                current = emp;
                break;
            }
        }

        if (current == null)
            return -1;

        int level = 0;

        while (current.ManagerId != 0)
        {
            level++;

            foreach (Employee emp in employees)
            {
                if (emp.Id == current.ManagerId)
                {
                    current = emp;
                    break;
                }
            }
        }

        return level;
    }
}