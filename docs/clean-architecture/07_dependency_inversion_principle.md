# Dependency Inversion Principle (DIP)

## Understanding the Dependency Inversion Principle

The **Dependency Inversion Principle (DIP)** is the fifth of the five SOLID principles of object-oriented design. It states:

> **High-level modules should not depend on low-level modules. Both should depend on abstractions.**  
> **Abstractions should not depend on details. Details should depend on abstractions.**

**DIP** means your core logic (high-level modules) should depend on **interfaces or abstractions**, not on concrete implementations (low-level modules). This decouples your business logic from infrastructure and details, making your codebase more flexible, testable, and maintainable.

### Why DIP Matters

When DIP is violated:

- High-level code is tightly coupled to low-level details.
- Changing infrastructure or implementation details requires changes in core logic.
- Testing and extending the system becomes difficult.

By following DIP, you:

- Enable clean architecture boundaries.
- Make your code easier to adapt and test.
- Reduce the risk of breaking core logic when details change.

---

## Example: DIP Violation

Suppose your application logic directly instantiates concrete classes:

```csharp
public class VehicleInspectionProcessor
{
    public bool ProcessInspection(IVehicle vehicle)
    {
        var service = new SimpleInspectionService(); // ⚠ tightly coupled to a concrete class
        return service.Verify(vehicle);
    }
}
```

**Problems:**

- The processor is tightly bound to a specific implementation.
- Hard to swap out the inspection logic or test the processor in isolation.

---

## Refactoring for DIP

Refactor the processor to depend on an abstraction (`IInspectionService`) and inject the dependency:

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
```

<details>
<summary>Exercise: Refactor the VehicleInspectionProcessor for DIP</summary>

```csharp
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
</details>

---

## Key Benefits

- **Decoupled design:** High-level modules depend on abstractions, not concrete implementations.
- **Easier testing:** Dependencies are injected, making the code easier to test and extend.
- **Flexible architecture:** Infrastructure and business logic are separated.

---

## Best Practices for Applying DIP

- Depend on **interfaces** or **abstract classes**, not concrete types.
- Use **dependency injection** to provide implementations at runtime.
- Keep abstractions in core layers; implement details in outer layers.
- Avoid new-ing up dependencies inside your business logic.

---

## Takeaway

DIP encourages designing your system around **interfaces** and **injection**, not **instantiation**.  
This decouples your core logic from infrastructure and allows for clean architecture boundaries.