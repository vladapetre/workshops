# Liskov Substitution Principle (LSP)

> "Objects of a superclass should be replaceable with objects of a subclass without affecting the correctness of the program." — Barbara Liskov

## Overview

The *Liskov Substitution Principle (LSP)* ensures that subclasses can stand in for their base classes without altering the desirable properties of a program—correctness, task completion, and expected behavior. LSP is a core SOLID principle that enables safe polymorphism and reliable inheritance.

### What It Means

LSP means that derived classes must be fully substitutable for their base classes. This requires that subclasses honor the contracts, invariants, and expectations established by the base class, including method behavior, preconditions, and postconditions. Violating LSP leads to unexpected behavior, bugs, and fragile code.

### Why It Matters

Adhering to LSP allows for robust polymorphic code, enabling developers to extend systems safely by introducing new subclasses. It ensures that code using base types can work seamlessly with any derived type, supporting maintainability, scalability, and correctness.

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
    void FillUp(decimal amount);
}

public class ClassicVehicle : IVehicle 
{
    public string Make { get; set; }
    public string Model { get; set; }
    public bool IsRegistered { get; set; }
    public decimal Mileage { get; set; }

    public decimal FuelLevel { get; set; }
    void FillUp(decimal amount) => FuelLevel += amount;
}

public class ElectricVehicle : IVehicle 
{
    public string Make { get; set; }
    public string Model { get; set; }
    public bool IsRegistered { get; set; }
    public decimal Mileage { get; set; }

    public decimal FuelLevel { get; set; }
    void FillUp(decimal amount) => throw new InvalidOperationException();

    public decimal BatteryLevel { get; set; }
    void ChargeUp(decimal amount) => BatteryLevel += amount;
}
```

*Problem: Substituting `ElectricVehicle` for `IVehicle` may cause runtime exceptions if the wrong method is called. This violates LSP, as not all implementations support all operations safely.*

### **Corrected Implementation**

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
```

*Now, each vehicle type only exposes operations it supports. Substitution is safe, and LSP is satisfied.*

### **Key Improvements**

- **Safe substitution:** No runtime exceptions from unsupported operations.
- **Clear contracts:** Each interface defines only valid operations for its type.
- **Extensible design:** New vehicle types can implement relevant interfaces without risk.
- **Improved robustness:** Client code can rely on interface contracts.

### **Common Pitfalls**

- **Forcing all implementations to support all operations,** leading to exceptions or undefined behavior.
- **Ignoring interface segregation,** resulting in bloated interfaces and LSP violations.
- **Breaking contracts** by changing method behavior or allowed inputs/outputs in subclasses.

---

## Key Takeaways

- Subclasses or implementations must be **fully substitutable** for their base types.
- Avoid exposing operations that are not universally supported.
- LSP enables **robust polymorphism** and **safe code extension**.
- Use interface segregation to maintain clear, safe contracts.