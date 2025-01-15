# Singleton Pattern in C#

## What is a Singleton?
A Singleton is a design pattern that restricts the instantiation of a class to one single instance. This is particularly useful when exactly one object is needed to coordinate actions across the system.

## Why Use a Singleton?
- **Controlled Access**: Provides controlled access to a single instance.
- **Resource Management**: Ideal for managing connections to a database or file system, as these resources are shared and accessed throughout an application.
- **Consistency**: Ensures that all parts of an application are working on the same instance, thus maintaining the same state.

## Examples of Singleton Pattern
Here are three implementations of the Singleton pattern in C#—ranging from a basic non-thread-safe version to a more complex thread-safe version using modern .NET features. Each version includes a brief explanation.

### 1. Basic Singleton (Non-Thread-Safe)
This simple implementation is not suitable for multi-threaded environments but demonstrates the basic concept of a Singleton pattern.

```csharp
public class SingletonBasic
{
    private static SingletonBasic _instance;

    private SingletonBasic() { }

    public static SingletonBasic Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SingletonBasic();
            }
            return _instance;
        }
    }
}
```

### 2. Thread-Safe Singleton with Locking
This version uses locks to ensure that only one instance of the Singleton is created even when accessed by multiple threads.

```csharp
public class SingletonThreadSafe
{
    private static SingletonThreadSafe _instance;
    private static readonly object _lock = new object();

    private SingletonThreadSafe() { }

    public static SingletonThreadSafe Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonThreadSafe();
                    }
                }
            }
            return _instance;
        }
    }
}
```

### 3. Fully Lazy Singleton (Thread-Safe Without Explicit Locks)
Utilizes Lazy<T> to provide thread safety and lazy instantiation with minimal overhead.

```csharp
public class SingletonLazy
{
    private static readonly Lazy<SingletonLazy> _instance = new Lazy<SingletonLazy>(() => new SingletonLazy());

    public static SingletonLazy Instance
    {
        get
        {
            return _instance.Value;
        }
    }

    private SingletonLazy() { }
}
```