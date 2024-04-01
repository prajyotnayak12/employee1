
using System;
using System.Collections.Generic;

class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }
    public DateTime JoinDate { get; set; }

    public Employee(int id, string name, string position, double salary, DateTime joinDate)
    {
        EmployeeId = id;
        Name = name;
        Position = position;
        Salary = salary;
        JoinDate = joinDate;
    }

    public override string ToString()
    {
        return $"{EmployeeId,-10} {Name,-20} {Position,-20} {Salary,-15} {JoinDate.ToShortDateString(),-15}";
    }
}

class Program
{
    static void Main(string[] args)
    {

        List<Employee> employees = new List<Employee>
        {
            new Employee(1, "Manash", "Jd", 40000, new DateTime(2024, 4, 15)),
            new Employee(2, "Rajat", "SD", 45000, new DateTime(2024, 4, 20)),
            new Employee(3, "Ashutosh", "JD", 50000, new DateTime(2024, 4, 10)),
            new Employee(4, "Rakesh", "SALE", 48000, new DateTime(2024, 4, 5)),
            new Employee(5, "Saloni", "JD", 55000, new DateTime(2024, 4, 12))
        };


        Console.WriteLine("All employees:");
        PrintEmployeeList(employees);


        Employee secondHighestPaidEmployee = GetSecondHighestPaidEmployee(employees);
        Console.WriteLine("\n  The 2nd highest salary Employee :");
        Console.WriteLine(secondHighestPaidEmployee);


        DateTime startDate = new DateTime(2024, 1, 1);
        DateTime endDate = new DateTime(2024, 5, 31);


        List<Employee> employeesInRange = GetEmployeesInRange(employees, startDate, endDate);
        Console.WriteLine($"\nEmployees joined between {startDate.ToShortDateString()} and {endDate.ToShortDateString()}:");
        PrintEmployeeList(employeesInRange);


        AddEmployee(employees);


        Console.WriteLine("\n New employeelist of all employees after adding :");
        PrintEmployeeList(employees);
    }

    static void AddEmployee(List<Employee> employees)
    {
        Console.WriteLine("Add Name:");
        string name = Console.ReadLine();
        Console.WriteLine("Position:");
        string position = Console.ReadLine();
        Console.WriteLine("Salary:");
        double salary = double.Parse(Console.ReadLine());
        Console.WriteLine("JoinDate (YYYY-MM-DD):");
        DateTime joinDate = DateTime.Parse(Console.ReadLine());

        int newEmployeeId = employees.Count + 1;
        Employee newEmployee = new Employee(newEmployeeId, name, position, salary, joinDate);
        employees.Add(newEmployee);
    }

    static Employee GetSecondHighestPaidEmployee(List<Employee> employees)
    {
        if (employees.Count < 2)
        {
            throw new InvalidOperationException("There are not enough employees to find the second-highest paid employee.");
        }

        Employee highestPaid = employees[0];
        Employee secondHighestPaid = employees[1];

        foreach (var employee in employees)
        {
            if (employee.Salary > highestPaid.Salary)
            {
                secondHighestPaid = highestPaid;
                highestPaid = employee;
            }
            else if (employee.Salary > secondHighestPaid.Salary && employee != highestPaid)
            {
                secondHighestPaid = employee;
            }
        }

        return secondHighestPaid;
    }

    static List<Employee> GetEmployeesInRange(List<Employee> employees, DateTime startDate, DateTime endDate)
    {
        List<Employee> employeesInRange = new List<Employee>();

        foreach (var employee in employees)
        {
            if (employee.JoinDate >= startDate && employee.JoinDate <= endDate)
            {
                employeesInRange.Add(employee);
            }
        }

        return employeesInRange;
    }

    static void PrintEmployeeList(List<Employee> employees)
    {
        Console.WriteLine($"{"ID",-10} {"Name",-10} {"Position",-20} {"Salary",-15} {"Join Date",-15}");
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
        Employee employeeWithLowestSalary = GetEmployeeWithLowestSalary(employees);
        Console.WriteLine("\nEmployee with lowest salary:");
        Console.WriteLine(employeeWithLowestSalary);


        UpdateEmployeePositionAndSalary(employeeWithLowestSalary, "SA", 65000);


        Console.WriteLine("\nEmployee with updation:");
        Console.WriteLine(employeeWithLowestSalary);
    }

    static Employee GetEmployeeWithLowestSalary(List<Employee> employees)
    {
        if (employees == null || employees.Count == 0)
        {
            Console.WriteLine("List of employees is empty.");
        }

        Employee lowestPaidEmployee = employees[0];
       foreach (va r employee in employees)
        {
            if (employee.Salary < lowestPaidEmployee.Salary)
            {
                lowestPaidEmployee = employee;
            }
        }
        return lowestPaidEmployee;
    }

    static void UpdateEmployeePositionAndSalary(Employee employee, string newPosition, double newSalary)
    {
        employee.Position = newPosition;
        employee.Salary = newSalary;
    }
}

