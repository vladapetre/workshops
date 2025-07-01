# Dependency Inversion Principle (DIP)

> "High-level modules should not depend on low-level modules. Both should depend on abstractions."  
> "Abstractions should not depend on details. Details should depend on abstractions."

## Overview

The **Dependency Inversion Principle (DIP)** is the fifth of the five SOLID principles.  
It means your core logic (high-level modules) should depend on **interfaces or abstractions**, not on concrete implementations (low-level modules).

### What It Means

DIP encourages you to design your system so that business logic is decoupled from infrastructure and details.  
High-level modules depend on abstractions, and details are injected as dependencies.

### Why It Matters

Applying DIP leads to:

- **Decoupled design:** High-level modules depend on abstractions, not concrete implementations.
- **Easier testing:** Dependencies are injected, making the code easier to test and extend.
- **Flexible architecture:** Infrastructure and business logic are separated.

---

### Code Example: Violation vs. Resolution

**Violation Example:**  
Application logic directly instantiates concrete classes.

```csharp
public class VehicleInspectionProcessor
{
    public bool ProcessInspection(IVehicle vehicle)
    {
        var service = new SimpleInspectionService(); // tightly coupled to a concrete class
        return service.Verify(vehicle);
    }
}
```
*Problem: The processor is tightly bound to a specific implementation.*

**Corrected Implementation:**  
Depend on an abstraction and inject the dependency.

```csharp
public interface IInspectionService
{
    bool Verify(IVehicle vehicle);
}

public class SimpleInspectionService : IInspectionService
{
    public bool Verify(IVehicle vehicle)
    {
        return vehicle.Mileage < 100000;
    }
}

public class VehicleInspectionProcessor
{
    private readonly IInspectionService _inspectionService;

    public VehicleInspectionProcessor(IInspectionService inspectionService)
    {
        _inspectionService = inspectionService;
    }

    public bool ProcessInspection(IVehicle vehicle)
    {
        return _inspectionService.Verify(vehicle);
    }
}
```
*Now, the processor is decoupled from the implementation and easy to test.*

**Key Improvements:**

- High-level modules depend on abstractions, not concrete types.
- Dependencies are injected, supporting testability and flexibility.
- Infrastructure and business logic are separated.

---

## Common Pitfalls

- Depending directly on concrete implementations in business logic
- Instantiating dependencies inside core modules
- Not using dependency injection or inversion

---

## Key Takeaways

- Depend on **interfaces** or **abstract classes**, not concrete types.
- Use dependency injection to provide implementations at runtime.
- Keep abstractions in core layers; implement details in outer layers.

---

## Related Concepts / Further Reading

- [SOLID Principles](https://en.wikipedia.org/wiki/SOLID)
- [Dependency Inversion Principle (Wikipedia)](https://en.wikipedia.org/wiki/Dependency_inversion_principle)
- [The Clean Architecture (Uncle Bob's Blog)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)