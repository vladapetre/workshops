# Open Closed Principle (OCP)

## Understanding the Open Closed Principle

The **Open Closed Principle (OCP)** is the second of the five SOLID principles of object-oriented design. It guides you to design software that is:

> **Open for extension, but closed for modification.**  
> – Bertrand Meyer

In practice, this means you should be able to introduce new behaviors or features to your codebase **without changing existing, tested code**. You achieve this by relying on **abstraction**—using interfaces, inheritance, or composition—so you can extend functionality by adding new classes, not by editing old ones.

### Why OCP Matters

Ignoring OCP leads to:

- Frequent changes to existing classes when adding new features.
- Tightly coupled business logic that is hard to maintain and test.
- Increased risk of introducing bugs into previously stable code.

By following OCP, you:

- Make your codebase easier to extend and maintain.
- Reduce the risk of breaking existing functionality.
- Encourage modular, flexible design.

---

## Example: OCP Violation

Consider this `Vehicle` class. It tries to handle tax calculation and inspection logic directly:

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

    public double CalculateTax()
    {
        if (Make == "Tesla")
            return 50; // EV discount
        else if (Mileage < 50000)
            return 150;
        else
            return 250;
    }

    public void CreateRegistration()
    {
        IsRegistered = true;
    }

    public bool VerifyPeriodicTechnicalInspection()
    {
        if (Make == "Tesla")
            return Mileage < 150000; // EV can have more mileage before requiring inspection
        return Mileage < 100000;
    }
}
```

**Problems:**

- Every new tax or inspection rule forces you to modify this class.
- Business rules are mixed together, making the code fragile and hard to test.
- The class is not closed for modification.

---

## Refactoring for OCP

To follow OCP, move tax and inspection logic into separate classes that implement interfaces. This way, you can add new rules by creating new classes, not by changing existing ones.

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

    public void CreateRegistration()
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

public class ElectricVehicleTaxCalculator : ITaxCalculator
{
    public double CalculateTax(Vehicle vehicle)
    {
        return 50; // Flat rate for EVs
    }
}
```

<details>
<summary>Exercise: Refactor the inspection logic using OCP</summary>

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

public class ElectricVehicleInspectionService: IInspectionService
{
    public bool Verify(Vehicle vehicle)
    {
        // EVs have longer inspection cycles
        return vehicle.Mileage < 150000;
    }
}
```
</details>

---

## Key Benefits

- **Separation of concerns:** Each class has a single responsibility.
- **Easy to extend:** Add new tax or inspection rules by creating new classes.
- **Stable core:** The `Vehicle` class remains unchanged as requirements evolve.
- **Testable:** Isolated business rules are easier to test.

---

## Best Practices for Applying OCP

- Use **interfaces** or **abstract classes** to define extension points.
- Favor **composition** over inheritance for flexibility.
- Avoid putting business rules directly into core domain classes.
- Write unit tests for each extension to ensure correctness.

---

## Takeaway

Design your code so you can add new features by extending, not rewriting, existing classes.  
This approach keeps your codebase flexible, robust, and ready for change.
