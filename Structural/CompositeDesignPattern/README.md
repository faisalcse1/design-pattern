# Organizational Hierarchy Management Using Composite Design Pattern in C#

This C# application illustrates the implementation of the Composite Design Pattern to manage a hierarchical structure within a company, simulating the relationships between employees and managers. By treating all components (both employees and managers) uniformly, the pattern facilitates operations across the entire organization's structure.

## Project Overview

The Composite Design Pattern is a structural design pattern that organizes objects into tree structures to represent part-whole hierarchies. This pattern allows clients to interact with individual objects and compositions of objects uniformly. In this application, it is specifically applied to simulate an organizational structure, where managers can have subordinates, who could be other managers or simple employees.

### Structure

- **Component Interface (`IEmployee`)**: An interface for all components including both primitive objects (employees) and their containers (managers).
- **Leaf (`Employee`)**: Represents individual employees without subordinates.
- **Composite (`Manager`)**: A component having children that can be either other `Manager` or `Employee` objects.

### Implementation

```csharp
using System;
using System.Collections.Generic;

public interface IEmployee
{
    void DisplayDetails();
}

public class Employee : IEmployee
{
    private string name;
    private string jobTitle;

    public Employee(string name, string jobTitle)
    {
        this.name = name;
        this.jobTitle = jobTitle;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"{jobTitle}: {name}");
    }
}

public class Manager : IEmployee
{
    private List<IEmployee> subordinates = new List<IEmployee>();
    private string name;
    private string jobTitle;

    public Manager(string name, string jobTitle)
    {
        this.name = name;
        this.jobTitle = jobTitle;
    }

    public void AddSubordinate(IEmployee employee)
    {
        subordinates.Add(employee);
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"{jobTitle}: {name}");
        foreach (var subordinate in subordinates)
        {
            subordinate.DisplayDetails();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Manager ceo = new Manager("John Doe", "CEO");
        Manager devManager = new Manager("Jane Smith", "Development Manager");
        Employee developer = new Employee("Alice Johnson", "Developer");
        Employee designer = new Employee("Bob Brown", "Designer");

        devManager.AddSubordinate(developer);
        devManager.AddSubordinate(designer);
        ceo.AddSubordinate(devManager);

        ceo.DisplayDetails();
    }
}
