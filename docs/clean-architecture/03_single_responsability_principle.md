# Single Responsability Principle (SRP)

The **Single Responsibility Principle (SRP)** is the first of the five SOLID principles of object-oriented design. It states:

> A module should have one, and only one, reason to change.
> — Robert C. Martin (Uncle Bob)

In simpler terms:  
Each class, module, or function should **do one thing** and **do it well**. It should have **only one responsibility**, and that responsibility should be **encapsulated entirely** by the unit.


## Why Is SRP Important?

When code has multiple responsibilities:

* It becomes harder to understand.
* A change in one responsibility may unintentionally affect another.
* It increases the risk of **coupling** between unrelated parts of the system.

### Example

In this example, the `Vehicle` class does too much:

* Maintains its own state (data)
* Tax rules (business rules)
* Technical inspection (possibly hardware or external system logic)


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

In the next example, we refactor the `Vehicle` class with SRP in mind: 

* Vehicle now only manages its domain state and simple transitions (IsRegistered, Mileage).
* Business rules (CalculateTax) and infrastructure logic (VerifyInspection) are handled by dedicated services.
* Easier to test, extend, and maintain.
* Each component has one reason to change.

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
    double CalculateTax(IVehicle vehicle);
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
<summary>Exercise: Complete the refactoring for the VerifyPeriodicTechnicalInspection method</summary>
```csharp

public interface IInspectionService 
{
    bool Verify(IVehicle vehicle);
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

## Takeaway

SRP isn't about splitting for the sake of splitting — it's about isolating reasons to change. Each concern deserves its own home.