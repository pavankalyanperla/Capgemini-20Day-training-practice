using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee(1001,"John Smith","CEO","Management",0),
            new Employee(1002,"Michael Johnson","IT Manager","IT",1001),
            new Employee(1003,"Sarah Williams","HR Manager","HR",1001),
            new Employee(1004,"David Brown","Finance Manager","Finance",1001),
            new Employee(1005,"Robert Davis","Team Lead","IT",1002),
            new Employee(1006,"Jennifer Miller","QA Lead","IT",1002),
            new Employee(1007,"William Wilson","Senior Developer","IT",1005),
            new Employee(1008,"Emma Moore","Senior Developer","IT",1005),
            new Employee(1009,"Daniel Taylor","QA Engineer","IT",1006),
            new Employee(1010,"Sophia Anderson","QA Engineer","IT",1006),
            new Employee(1011,"James Thomas","Recruiter","HR",1003),
            new Employee(1012,"Olivia Jackson","Recruiter","HR",1003),
            new Employee(1013,"Benjamin White","Accountant","Finance",1004),
            new Employee(1014,"Charlotte Harris","Accountant","Finance",1004),
            new Employee(1015,"Lucas Martin","Developer","IT",1007),
            new Employee(1016,"Ethan Walker","Developer","IT",1007),
            new Employee(1017,"Mia Hall","UI Developer","IT",1008),
            new Employee(1018,"Alexander Young","Business Analyst","IT",1005),
            new Employee(1019,"Harper King","HR Executive","HR",1011),
            new Employee(1020,"Jack Scott","Finance Executive","Finance",1013)
        };

        while (true)
        {
            Console.WriteLine("\n==========================================");
            Console.WriteLine("ABC TECHNOLOGIES");
            Console.WriteLine("Organization Hierarchy Management System");
            Console.WriteLine("==========================================");

            Console.WriteLine("1. Display Complete Organization Chart");
            Console.WriteLine("2. Find Employee by ID");
            Console.WriteLine("3. Find Employee by Name");
            Console.WriteLine("4. Display Employees under a Manager");
            Console.WriteLine("5. Count Total Employees under a Manager");
            Console.WriteLine("6. Display Hierarchy Level");
            Console.WriteLine("7. Exit");

            Console.Write("\nEnter Choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine();
                    EmployeeFunctions.DisplayOrganization(employees, 0, "");
                    break;

                case 2:
                    Console.Write("Enter Employee ID : ");
                    EmployeeFunctions.SearchById(employees,
                        Convert.ToInt32(Console.ReadLine()));
                    break;

                case 3:
                    Console.Write("Enter Employee Name : ");
                    EmployeeFunctions.SearchByName(employees,
                        Console.ReadLine());
                    break;

                case 4:
                    Console.Write("Enter Manager ID : ");
                    EmployeeFunctions.EmployeesUnderManager(employees,
                        Convert.ToInt32(Console.ReadLine()));
                    break;

                case 5:
                    Console.Write("Enter Manager ID : ");
                    int managerId = Convert.ToInt32(Console.ReadLine());

                    int count = EmployeeFunctions.CountEmployees(employees, managerId);

                    Console.WriteLine("Total Employees : " + count);
                    break;

                case 6:
                    Console.Write("Enter Employee ID : ");
                    int empId = Convert.ToInt32(Console.ReadLine());

                    int level = EmployeeFunctions.GetLevel(employees, empId);

                    Console.WriteLine("Hierarchy Level : " + level);
                    break;

                case 7:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}
