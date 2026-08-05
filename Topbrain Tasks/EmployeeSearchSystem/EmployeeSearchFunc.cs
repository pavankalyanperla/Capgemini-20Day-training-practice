using System;
using System.Collections.Generic;

class Employee
{
    public int Id;
    public string Name;
    public string Department;
    public string Designation;
    public int Experience;
    public double Salary;
    public string City;

    public Employee(int id, string name, string department,
                    string designation, int experience,
                    double salary, string city)
    {
        Id = id;
        Name = name;
        Department = department;
        Designation = designation;
        Experience = experience;
        Salary = salary;
        City = city;
    }

    public void Display()
    {
        Console.WriteLine($"{Id} | {Name} | {Department} | {Designation} | {Experience} yrs | ₹{Salary} | {City}");
    }
}

class EmployeeFunctions
{
    // Display All Employees
    public static void DisplayAll(List<Employee> employees)
    {
        foreach (Employee emp in employees)
            emp.Display();
    }

    // Linear Search by Employee ID
    public static void SearchByIDLinearSearch(List<Employee> employees, int id)
    {
        bool found = false;

        foreach (Employee emp in employees)
        {
            if (emp.Id == id)
            {
                emp.Display();
                found = true;
                break;
            }
        }

        if (!found)
            Console.WriteLine("Employee Not Found.");
    }

    // Binary Search by Employee ID
    public static void SearchByIDBinarySearch(List<Employee> employees, int id)
    {
        employees.Sort((a, b) => a.Id.CompareTo(b.Id));

        int left = 0;
        int right = employees.Count - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (employees[mid].Id == id)
            {
                employees[mid].Display();
                return;
            }

            if (employees[mid].Id < id)
                left = mid + 1;
            else
                right = mid - 1;
        }

        Console.WriteLine("Employee Not Found.");
    }

    // Search by Name
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

    // Search by Department
    public static void SearchByDepartment(List<Employee> employees, string dept)
    {
        bool found = false;

        foreach (Employee emp in employees)
        {
            if (emp.Department.Equals(dept, StringComparison.OrdinalIgnoreCase))
            {
                emp.Display();
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No Employees Found.");
    }

    // Search by City
    public static void SearchByCity(List<Employee> employees, string city)
    {
        bool found = false;

        foreach (Employee emp in employees)
        {
            if (emp.City.Equals(city, StringComparison.OrdinalIgnoreCase))
            {
                emp.Display();
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No Employees Found.");
    }

    // Search by Experience
    public static void SearchByExperience(List<Employee> employees, int exp)
    {
        bool found = false;

        foreach (Employee emp in employees)
        {
            if (emp.Experience >= exp)
            {
                emp.Display();
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No Employees Found.");
    }

    // Search by Salary Range
    public static void SearchBySalary(List<Employee> employees, double min, double max)
    {
        bool found = false;

        foreach (Employee emp in employees)
        {
            if (emp.Salary >= min && emp.Salary <= max)
            {
                emp.Display();
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No Employees Found.");
    }
}