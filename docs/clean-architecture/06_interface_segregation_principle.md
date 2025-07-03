# Interface Segregation Principle (ISP)

> "Clients should not be forced to depend on interfaces they do not use." — Robert C. Martin (Uncle Bob)

## Overview

The *Interface Segregation Principle (ISP)* states that interfaces should be **specific and focused**, ensuring that clients only need to know about the methods that are relevant to them. ISP is a core SOLID principle that promotes **modular**, **cohesive**, and **maintainable** code.

### What It Means

ISP means that instead of having one large, general-purpose interface, you should create several smaller, role-specific interfaces. This prevents clients from being burdened with methods they do not need, reducing unnecessary dependencies and making the system easier to evolve.

### Why It Matters

Following ISP leads to **cleaner abstractions**, **improved flexibility**, and **better testability**. It reduces the impact of changes, minimizes the risk of breaking unrelated functionality, and enables more granular, focused implementations.

---

## Code Example: Violation vs. Resolution

### **Violation Example:**  
```csharp
public interface IVehicle 
{
    public string Make { get; set; }
    public string Model { get; set; }
    public bool IsRegistered { get; set; }
    public decimal Mileage { get; set; }
    public decimal FuelLevel { get; set; }
    public decimal BatteryLevel { get; set; }

    void FillUp(decimal amount);
    void ChargeUp(decimal amount);
}

public class ClassicVehicle : IVehicle 
{
    public string Make { get; set; }
    public string Model { get; set; }
    public bool IsRegistered { get; set; }
    public decimal Mileage { get; set; }
    public decimal FuelLevel { get; set; }
    public decimal BatteryLevel { get; set; }

    void FillUp(decimal amount) => FuelLevel += amount;
    void ChargeUp(decimal amount) => throw new InvalidOperationException();
}

public class ElectricVehicle : IVehicle 
{
    public string Make { get; set; }
    public string Model { get; set; }
    public bool IsRegistered { get; set; }
    public decimal Mileage { get; set; }
    public decimal FuelLevel { get; set; }
    public decimal BatteryLevel { get; set; }

    void FillUp(decimal amount) => throw new InvalidOperationException();
    void ChargeUp(decimal amount) => BatteryLevel += amount;
}

public class HybridVehicle : IVehicle 
{
    public string Make { get; set; }
    public string Model { get; set; }
    public bool IsRegistered { get; set; }
    public decimal Mileage { get; set; }

    public decimal FuelLevel { get; set; }
    void FillUp(decimal amount) => FuelLevel += amount;

    public decimal BatteryLevel { get; set; }
    void ChargeUp(decimal amount) => BatteryLevel += amount;
}
```
*Problem: All vehicle types must implement both `FillUp` and `ChargeUp`, even if they do not support one or the other. For example, `ElectricVehicle` must provide a meaningless or exception-throwing implementation for `FillUp`. This violates ISP by forcing clients to depend on irrelevant methods.*

### **Corrected Implementation:**  

```csharp
public interface IVehicle 
{
    public string Make { get; set; }
    public string Model { get; set; }
    public bool IsRegistered { get; set; }
    public decimal Mileage { get; set; }
}

public interface IClassicVehicle : IVehicle
{
    public decimal FuelLevel { get; set; }
    void ChargeUp(decimal amount);
}

public interface IElectricVehicle : IVehicle
{
    public decimal BatteryLevel { get; set; }
    void FillUp(decimal amount);
}

public class ClassicVehicle : IClassicVehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public bool IsRegistered { get; set; }
    public decimal Mileage { get; set; }

    public decimal FuelLevel { get; set; }
    void FillUp(decimal amount) => FuelLevel += amount;
}

public class ElectricVehicle : IElectricVehicle 
{
    public string Make { get; set; }
    public string Model { get; set; }
    public bool IsRegistered { get; set; }
    public decimal Mileage { get; set; }

    public decimal BatteryLevel { get; set; }
    void ChargeUp(decimal amount) => BatteryLevel += amount;
}

public class HybridVehicle : IClassicVehicle, IElectricVehicle 
{
    public string Make { get; set; }
    public string Model { get; set; }
    public bool IsRegistered { get; set; }
    public decimal Mileage { get; set; }

    public decimal FuelLevel { get; set; }
    void FillUp(decimal amount) => FuelLevel += amount;

    public decimal BatteryLevel { get; set; }
    void ChargeUp(decimal amount) => BatteryLevel += amount;
}
```
*Now, each vehicle type implements only the interfaces relevant to its capabilities. `ClassicVehicle` implements `IFuelVehicle`, `ElectricVehicle` implements `IElectricVehicle`, and `HybridVehicle` can implement both if needed. Clients are never forced to depend on unused methods.*

### **Key Improvements:**

- **Focused interfaces**: Each interface contains only relevant operations.
- **No unnecessary dependencies**: Clients and implementations are not burdened with irrelevant methods.
- **Easier maintenance and testing**: Changes to one interface do not affect unrelated types.
- **Greater flexibility**: New vehicle types can implement only the interfaces they need.
- **Clearer intent**: Interface names and members clearly express their purpose.

These improvements lead to a more modular, maintainable, and adaptable codebase.

### **Common Pitfalls**

- **Fat interfaces**: Large interfaces that group unrelated methods, forcing clients to implement or depend on unused functionality.
- **Unnecessary coupling**: Changes to an interface ripple to all implementers, even those that do not use the changed members.
- **Exception-throwing stubs**: Implementations that throw exceptions for unsupported methods, indicating a design flaw.
- **Ignoring client needs**: Designing interfaces from the implementer's perspective rather than the client's.

## Key Takeaways

- Interfaces should be **small, focused, and role-specific**.
- Avoid forcing clients to depend on methods they do not use.
- ISP improves **modularity**, **testability**, and **clarity**.
- Split large interfaces into **cohesive, meaningful contracts**.
- ISP enables **flexible** and **robust** system evolution.