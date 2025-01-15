# Prototype Design Pattern in C#

## Overview
The Prototype design pattern is a creational pattern used to create duplicate objects while maintaining high performance. This pattern is particularly useful in scenarios where object creation is costly and time-consuming. By cloning an existing object instead of creating a new one from scratch, you can achieve greater efficiency and flexibility.

## Why Use the Prototype Pattern?
- **Efficiency**: Cloning is often more efficient than creating new objects, especially when the creation involves expensive operations like database or network access.
- **Flexibility**: Allows clients to obtain new objects without knowing the specifics of how these objects are created, which can add flexibility to the code.
- **Scalability**: Reduces the need for creating subclasses. A prototype can be cloned and modified as needed, simplifying the system architecture.

## Sample Code in C#

```csharp
using System;

public interface IPrototype
{
    IPrototype Clone();
}

public class Employee : IPrototype
{
    public string FirstName {  get; set; }
    public string LastName { get; set; }    

    public Employee(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    // Implementing the Clone method
    public IPrototype Clone()
    {
        // Shallow Copy: This may need modification to Deep Copy depending on requirements
        return this.MemberwiseClone() as IPrototype;
    }
}

class Program
{
    static void Main()
    {
        Employee original = new Employee("Md", "Faisal");
        Employee clone = original.Clone() as Employee;

        Console.WriteLine("Original FirstName: " + original.FirstName + ", LastName: " + original.LastName);
        Console.WriteLine("Clone FirstName: " + clone.FirstName + ", LastName: " + clone.LastName);

        // Changing clone's properties to demonstrate that it is a separate instance
        clone.FirstName = "Md";
        clone.LastName = "Rasel";

        Console.WriteLine("Modified Clone FirstName: " + clone.FirstName + ", Property2: " + clone.LastName);
    }
}

```

## Components

### IPrototype Interface
- **Purpose**: Defines a contract for cloning itself. This interface ensures that any class implementing it provides a mechanism for creating a clone of its instances.
- **Key Method**: `Clone()`
  - **Return Type**: `IPrototype`
  - **Description**: Should return a copy of the object that implements this method.

### Employee Class
- **Purpose**: Implements the `IPrototype` interface to allow cloning of its instances.
- **Cloning Mechanism**: Uses the `MemberwiseClone()` method to perform a shallow copy of its fields.
- **Considerations**:
  - **Shallow Copy**: The default cloning method provided by `MemberwiseClone()` copies field values directly. For fields that are value types, this creates a copy of the value. For fields that are reference types, this copies the reference, not the actual object, which means both the original and the clone refer to the same object.
  - **Deep Copy**: If the `Employee` contains complex objects or collections, a deep copy might be necessary. This can be achieved by manually copying these objects to ensure that the clone has its own separate copies.


  ## Extended Example with Deep Copy
  Let's add a complex object to the Employee class to illustrate the need for deep copying. Suppose each employee has a list of skills that we want to clone independently.
 ```csharp
using System;
using System.Collections.Generic;

public interface IPrototype
{
    IPrototype Clone();
}

public class Employee : IPrototype
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<string> Skills { get; set; } // Adding a list of skills as a complex field

    public Employee(string firstName, string lastName, List<string> skills)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Skills = new List<string>(skills); // Initialize with a copy of the skills list
    }

    // Implementing the Clone method for deep copying
    public IPrototype Clone()
    {
        // Deep Copy: Manually copying the list of skills
        Employee clonedEmployee = (Employee)this.MemberwiseClone(); // Shallow copy of the object
        clonedEmployee.Skills = new List<string>(this.Skills); // Deep copy of the list
        return clonedEmployee;
    }
}

class Program
{
    static void Main()
    {
        List<string> skills = new List<string> { "Programming", "Design" };
        Employee original = new Employee("Md", "Faisal", skills);
        Employee clone = original.Clone() as Employee;

        Console.WriteLine("Original FirstName: " + original.FirstName + ", LastName: " + original.LastName);
        Console.WriteLine("Original Skills: " + string.Join(", ", original.Skills));

        // Changing clone's properties and skills to demonstrate that it is a separate instance
        clone.FirstName = "Md";
        clone.LastName = "Rasel";
        clone.Skills.Add("Management");

        Console.WriteLine("Clone FirstName: " + clone.FirstName + ", LastName: " + clone.LastName);
        Console.WriteLine("Clone Skills: " + string.Join(", ", clone.Skills));

        // Verify that the original employee's skills have not changed
        Console.WriteLine("Modified Original Skills: " + string.Join(", ", original.Skills));
    }
}


  ```