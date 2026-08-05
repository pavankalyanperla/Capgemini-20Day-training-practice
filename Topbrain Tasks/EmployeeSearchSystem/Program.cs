using System;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>()
        {

            new Employee(1001,"Rahul Sharma","IT","Software Engineer",2,45000,"Chennai"),

            new Employee(1002,"Priya Singh","HR","HR Executive",3,40000,"Bangalore"),

            new Employee(1003,"Amit Kumar","Finance","Accountant",5,55000,"Hyderabad"),

            new Employee(1004,"Neha Patel","IT","Senior Developer",6,85000,"Pune"),

            new Employee(1005,"Arjun Reddy","Sales","Sales Executive",2,38000,"Chennai"),

            new Employee(1006,"Sneha Iyer","Marketing","Marketing Executive",4,52000,"Coimbatore"),

            new Employee(1007,"Karan Mehta","IT","Team Lead",8,95000,"Mumbai"),

            new Employee(1008,"Divya Nair","Support","Support Engineer",1,32000,"Kochi"),

            new Employee(1009,"Rohit Verma","IT","Software Engineer",3,50000,"Delhi"),

            new Employee(1010,"Anjali Gupta","Finance","Financial Analyst",4,65000,"Noida"),

            new Employee(1011,"Suresh Kumar","Admin","Administrator",7,58000,"Madurai"),

            new Employee(1012,"Pooja Sharma","HR","Recruiter",2,42000,"Bangalore"),

            new Employee(1013,"Vikram Das","IT","System Engineer",5,62000,"Chennai"),

            new Employee(1014,"Meena Joshi","Support","Technical Support",3,41000,"Trichy"),

            new Employee(1015,"Naveen Raj","Sales","Sales Manager",9,98000,"Salem"),

            new Employee(1016,"Kavya R","Marketing","SEO Analyst",2,45000,"Chennai"),

            new Employee(1017,"Ajay Kumar","IT","DevOps Engineer",4,72000,"Hyderabad"),

            new Employee(1018,"Lakshmi Devi","Finance","Senior Accountant",6,76000,"Coimbatore"),

            new Employee(1019,"Manoj Singh","IT","QA Engineer",3,53000,"Pune"),

            new Employee(1020,"Deepika Rao","HR","HR Manager",8,90000,"Bangalore")

        };

        EmployeeFunctions.SearchByIDLinearSearch(employees, 1018);
    }
}