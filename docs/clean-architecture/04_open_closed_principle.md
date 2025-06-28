# Open Closed Principle (OCP)

The Open Closed Principle (OCP) is the second  of the five SOLID principles of object-oriented design. It states:

> A software artifact should be open for extension but closed for modification.
> – Bertrand Meyer

In practice, this means we should be able to **add new behaviors** to existing code **without changing** it. We do this through **abstraction** (e.g., interfaces, inheritance, strategy pattern, etc.).

### Example

Here, `CalculateTax()` is hardcoded and tightly coupled to rules that keep changing. Every time a new tax rule is introduced (e.g., for electric cars or hybrids), the method must be edited.

* Business logic is buried inside `Vehicle`.
* Adding new tax rules requires modifying the class.

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
            return Mileage < 150000;; // EV can have more mileage before requiring inspection
        return Mileage < 100000;
    }
}
```


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
        return 50; // EVs get flat rate
    }
}
```

<details>
<summary>Exercise: Complete the refactoring for the VerifyPeriodicTechnicalInspection method</summary>
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
        // Assume electric vehicles have longer inspection cycles
        return vehicle.Mileage < 150000;
    }
}
```
</details>

## Takeaway

Use abstractions (interfaces) and composition to allow behavior changes without modifying existing classes. This increases flexibility and stability in your codebase.
