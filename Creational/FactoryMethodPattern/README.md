# Factory Method Pattern

The Factory Method pattern is a widely used design pattern in object-oriented programming, fitting under the category of creational patterns that deal with object creation mechanisms. This pattern allows a class's instantiation to be deferred to subclasses, thus encapsulating the instantiation logic.


## Factory Method Pattern Logging System

This project demonstrates the implementation of the Factory Method design pattern in a logging system. It includes different loggers such as memory and Redis logger, each simulating specific logging behaviors.

### Why Use the Factory Method Pattern?

- **Decoupling Code:** Decouples the code that creates objects from the code that uses them, making the system less sensitive to changes in the creation logic.

- **Adding Flexibility:** Introduces flexibility by allowing new types of objects to be created without altering existing factory or client code. 

- **Encapsulation of Object Creation:** Makes the system robust and less dependent on the specifics of classes by focusing on interfaces, reducing system dependencies.

- **Consistency in Object Creation:** Ensures consistent implementation of object creation rules through a central factory.

- **Supporting Open/Closed Principle:** Adheres to the Open/Closed Principle, which promotes extensions without modifying existing code.

## Example Explained

The provided example demonstrates using the Factory Method pattern in a simple logging scenario where the application can log to different storage mechanisms like memory or Redis, potentially extended to other types like files, databases, etc.

### Project Structure & Sample Code

- **ILogger**: Interface that defines standard logging behavior.
```csharp
public interface ILogger
{
    void Log(string message);
}```

- **MemoryLogger**: Logs messages to the console simulating memory storage.
```csharp
public class MemoryLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Memory Log: {message}");
    }
}
```
- **RedisLogger**: Logs messages to the console simulating Redis storage.
```csharp
public class RedisLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Redis Log: {message}");
    }
}
```
- **LoggerFactory**: Factory class that creates instances of loggers based on specified types.
```csharp
public enum LoggerType
{
    Memory,
    Redis
}

public class LoggerFactory
{
    public ILogger CreateLogger(LoggerType type)
    {
        switch (type)
        {
            case LoggerType.Memory:
                return new MemoryLogger();
            case LoggerType.Redis:
                return new RedisLogger();
            default:
                throw new ArgumentException("Invalid logger type.");
        }
    }
}
```
- **Program**: Main application entry that uses LoggerFactory to create and utilize loggers.
```csharp
class Program
{
    static void Main(string[] args)
    {
        var factory = new LoggerFactory();

        var memoryLogger = factory.CreateLogger(LoggerType.Memory);
        memoryLogger.Log("This is a simulated memory logger.");

        var redisLogger = factory.CreateLogger(LoggerType.Redis);
        redisLogger.Log("This is a simulated Redis logger.");
    }
}
```

