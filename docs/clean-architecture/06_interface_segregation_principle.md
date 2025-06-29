# Interface Segregation Principle (ISP)

## Understanding the Interface Segregation Principle

The **Interface Segregation Principle (ISP)** is the fourth of the five SOLID principles of object-oriented design. It states:

> **Clients should not be forced to depend upon interfaces that they do not use.**  
> – Robert C. Martin (Uncle Bob)

**ISP** encourages you to design **small, focused interfaces**. Classes should only implement the methods that are relevant to their role, not be forced to provide empty or meaningless implementations for methods they don’t need.

### Why ISP Matters

Violating ISP leads to:

- Classes forced to implement methods they don’t use.
- “Fat” interfaces that are hard to understand and maintain.
- Changes to an interface rippling through many unrelated classes.

By following ISP, you:

- Keep your codebase flexible and focused.
- Make interfaces easier to understand and maintain.
- Reduce the risk of breaking unrelated code when interfaces change.

---

## Example: ISP Violation

Here’s a version of `IVehicle` that forces all implementers to support tax calculation, registration, and inspection—even if they don’t need all of them:

```csharp
public interface IVehicle
{
    string Make { get; }
    string Model { get; }
    bool IsRegistered { get; }
    decimal Mileage { get; }

    double CalculateTax();
    void CreateRegistration();
    bool VerifyPeriodicTechnicalInspection();
}
```

**Problems:**

- Vehicles that are exempt from tax still need to implement `CalculateTax()`.
- Concept or off-road vehicles might not be registerable.
- Test mocks or simple data models may not care about inspections.

---

## Refactoring for ISP

Split `IVehicle` into smaller, role-based interfaces so classes only implement what they need:

```csharp
public interface IVehicle
{
    string Make { get; }
    string Model { get; }
    decimal Mileage { get; }
}

public interface IRegistrableVehicle
{
    bool IsRegistered { get; }
    void CreateRegistration();
}

public interface ITaxableVehicle
{
    double CalculateTax();
}
```

<details>
<summary>Exercise: Refactor the inspection logic for ISP</summary>

```csharp
public interface IInspectableVehicle
{
    bool VerifyPeriodicTechnicalInspection();
}

public class RoadVehicle : IVehicle, IRegistrableVehicle, ITaxableVehicle, IInspectableVehicle
{
    // All properties and methods implemented
}

public class PrototypeVehicle : IVehicle
{
    public string Make => "Prototype";
    public string Model => "X-Concept";
    public decimal Mileage => 0;

    // No tax, registration, or inspection — not needed
}
```
</details>

---

## Key Benefits

- **Focused interfaces:** Each class only implements what it actually needs.
- **No more empty methods:** Avoid meaningless or placeholder implementations.
- **Easier maintenance:** Interfaces are smaller, clearer, and less likely to change for unrelated reasons.
- **Greater flexibility:** You can extend or modify behavior without impacting unrelated classes.

---

## Best Practices for Applying ISP

- Split large interfaces into smaller, role-based contracts.
- Avoid “fat” interfaces that try to cover every possible use case.
- Group related methods together, but don’t force unrelated responsibilities into a single interface.
- Regularly review interfaces as your system evolves—refactor when they start to grow too large.

---

## Takeaway

Design interfaces that are **small, focused, and role-specific**.  
This keeps your codebase clean, flexible, and easy to maintain as your system grows.