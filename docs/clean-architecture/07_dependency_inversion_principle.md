# Dependency Inversion Principle (DIP)

> "High-level modules should not depend on low-level modules. Both should depend on abstractions. Abstractions should not depend on details. Details should depend on abstractions." — Robert C. Martin (Uncle Bob)

## Overview

The *Dependency Inversion Principle (DIP)* dictates that both high-level and low-level modules should depend on abstractions, not on concrete implementations. DIP is a cornerstone of SOLID that enables **flexible**, **decoupled**, and **testable** software design.

### What It Means

DIP encourages you to program to interfaces or abstract types, not to concrete classes. High-level modules (business logic) should define contracts (interfaces), and low-level modules (implementations) should fulfill those contracts. This reduces coupling and makes it easier to substitute implementations.

### Why It Matters

Following DIP allows you to change, replace, or mock dependencies without modifying core logic. It supports **unit testing**, **maintainability**, and **extensibility**, making your system robust to change.

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
}

public interface IVehicleTaxService 
{
    decimal CalculateTax(IVehicle vehicle);
}

public interface IVehicleRegistrationService 
{
    void CreateRegistration(IVehicle vehicle);
}

public class SimpleVehicleTaxService 
{
    public decimal CalculateTax(IVehicle vehicle)
    {
        return vehicle.Mileage > 10000 ? 100 : 50;
    }
}

public class SimpleVehicleRegistrationService 
{
    private readonly IVehicleTaxService _vehicleTaxService = new SimpleVehicleTaxService();

    public void CreateRegistration(IVehicle vehicle)
    {
        if(_vehicleTaxService.CalculateTax(vehicle) < 100)
        {
            vehicle.IsRegistered = true;
        }
    }
}
```
*Problem: `SimpleVehicleRegistrationService` directly instantiates and depends on the concrete `SimpleVehicleTaxService`. This tight coupling makes it difficult to substitute, extend, or test the tax service logic. The high-level registration service should not depend on low-level implementation details.*

### **Corrected Implementation:**  

```csharp
public interface IVehicle 
{
    public string Make { get; set; }
    public string Model { get; set; }
    public bool IsRegistered { get; set; }
    public decimal Mileage { get; set; }
}

public interface IVehicleTaxService 
{
    decimal CalculateTax(IVehicle vehicle);
}

public interface IVehicleRegistrationService 
{
    void CreateRegistration(IVehicle vehicle);
}

public class SimpleVehicleTaxService 
{
    public decimal CalculateTax(IVehicle vehicle)
    {
        return vehicle.Mileage > 10000 ? 100 : 50;
    }
}

public class SimpleVehicleRegistrationService 
{
    private readonly IVehicleTaxService _vehicleTaxService;

    public SimpleVehicleRegistrationService(IVehicleTaxService vehicleTaxService) => (_vehicleTaxService) = vehicleTaxService;

    public void CreateRegistration(IVehicle vehicle)
    {
        if(_vehicleTaxService.CalculateTax(vehicle) < 100)
        {
            vehicle.IsRegistered = true;
        }
    }
}
```
*Now, `SimpleVehicleRegistrationService` depends only on the abstraction `IVehicleTaxService`. Any implementation (real, mock, or alternative strategy) can be injected, supporting DIP.*

### **Key Improvements**

- **Decouples business logic from implementation details**
- **Enables easy substitution and unit testing**
- **Supports extensibility and maintainability**
- **Promotes interface-driven, flexible design**

### **Common Pitfalls**

- **Directly instantiating dependencies** in high-level modules
- **Tightly coupling business logic to infrastructure or frameworks**
- **Failing to define abstractions for core dependencies**
- **Overusing dependency injection without meaningful abstractions**

---

## Key Takeaways

- High-level modules should depend on **abstractions**, not concretions.
- Both business logic and implementations should rely on interfaces.
- DIP enables **flexible, testable, and maintainable** architectures.
- Use dependency injection to supply implementations at runtime.
- DIP is essential for **robust, decoupled, and adaptable** software systems.