# Single Responsibility Principle (SRP)

## Understanding the Single Responsibility Principle

The **Single Responsibility Principle (SRP)** is the first of the five SOLID principles of object-oriented design. It states:

> A module should have one, and only one, reason to change.  
> — Robert C. Martin (Uncle Bob)

SRP encourages you to design classes, modules, or functions so that each one **does one thing and does it well**. Every unit should have a **single, clearly defined responsibility**, fully encapsulated within that unit.

### Why SRP Matters

Violating SRP introduces several risks:

- Code becomes harder to understand and maintain.
- Changes in one responsibility can unintentionally affect others.
- Unrelated parts of the system become tightly coupled, making refactoring and testing more difficult.

By following SRP, you:

- Separate concerns, making each part of your codebase easier to test, extend, and modify.
- Reduce the risk of unintended side effects when making changes.

---

## Example: SRP Violation

Consider this `Vehicle` class, which tries to do too much:

- Maintains its own state (data)
- Contains tax calculation logic (business rules)
- Handles technical inspection (possibly infrastructure or external system logic)

```csharp
public class Vehicle 
{
    public string Make { get; private set; }
    public string Model { get; private set; }
    public bool IsRegistered { get; private set; }
    public decimal Mileage { get; private set; }

    public Vehicle(string make, string model, decimal mileage)
    {
        Make = make;
        Model = model;
        Mileage = mileage;
        IsRegistered = false;
    }

    public double CalculateTax()
    {
        // Logic related to tax brackets
        if (Mileage < 50000)
            return 150;
        else
            return 250;
    }

    public void Register()
    {
        IsRegistered = true;
    }

    public bool VerifyPeriodicTechnicalInspection()
    {
        // Simulated call to an external system or hardware
        Console.WriteLine("Running inspection tools...");
        return Mileage < 100000;
    }
}
```

**Problems:**

- The class is responsible for too many things.
- Multiple reasons to change—a clear SRP violation.

---

## Refactoring for SRP

To follow SRP, move each responsibility into its own class or interface. This makes your code easier to maintain and extend.

```csharp
public class Vehicle
{
    public string Make { get; private set; }
    public string Model { get; private set; }
    public bool IsRegistered { get; private set; }
    public decimal Mileage { get; private set; }

    public Vehicle(string make, string model, decimal mileage)
    {
        Make = make;
        Model = model;
        Mileage = mileage;
    }

    public void Register()
    {
        IsRegistered = true;
    }
}

public interface ITaxCalculator
{
    double CalculateTax(Vehicle vehicle);
}

public class StandardTaxCalculator : ITaxCalculator
{
    public double CalculateTax(Vehicle vehicle)
    {
        return vehicle.Mileage < 50000 ? 150 : 250;
    }
}
```

<details>
<summary>Exercise: Refactor the inspection logic for SRP</summary>

```csharp
public interface IInspectionService 
{
    bool Verify(Vehicle vehicle);
}

public class SimpleInspectionService : IInspectionService
{
    public bool Verify(Vehicle vehicle)
    {
        return vehicle.Mileage < 100000;
    }
}
```
</details>

---

## Key Improvements

- `Vehicle` only manages its own state and registration.
- Tax calculation is handled by `StandardTaxCalculator`.
- Technical inspection logic is handled by `SimpleInspectionService`.
- Each class has a single responsibility and a single reason to change.

---

## Best Practices for SRP

- Assign one responsibility per class or module.
- If a class or function changes for more than one reason, split it up.
- Keep business rules, infrastructure, and data management separate.

---

## Takeaway

SRP is about **isolating reasons to change**.  
When each concern has its own home, your codebase becomes easier to understand, maintain, and extend.