# Liskov Substituton Principle (LSP)

> Objects of a superclass should be replaceable with objects of its subclasses without affecting the correctness of the program.
> – Barbara Liskov

In practice, this means we should be able to **use any subtype** of an interface or base class **without altering the expected behavior** of the program. This is achieved by designing abstractions that ensure **consistent and predictable behavior** across all implementations.

### Example

Let’s say we create a subclass `UnregisteredVehicle` that **throws an exception** when trying to register, violating the contract of `Vehicle`.
If a method expects any Vehicle and calls CreateRegistration(), this will throw unexpectedly. That violates the Liskov Substitution Principle.

```csharp

public interface IVehicle
{
    string Make { get; }
    string Model { get; }
    decimal Mileage { get; }

    double CalculateTax();
    void CreateRegistration();
    bool VerifyPeriodicTechnicalInspection();
}


public class UnregisteredVehicle : IVehicle
{
    public string Make => "Prototype";
    public string Model => "Test Rig";
    public bool IsRegistered => false;
    public decimal Mileage => 0;

    public double CalculateTax()
    {
        return 0;
    }

    public void CreateRegistration()
    {
        throw new NotSupportedException("This vehicle cannot be registered.");
    }

    public bool VerifyPeriodicTechnicalInspection()
    {
        return false;
    }
}
```

To comply with LSP:

* Subtypes should behave according to expectations set by the base type.
* If an operation is not supported, it shouldn’t be part of the contract.

```csharp

public interface IVehicle
{
    string Make { get; }
    string Model { get; }
    decimal Mileage { get; }

    double CalculateTax();
    bool VerifyPeriodicTechnicalInspection();
}

public interface IRegistrableVehicle : IVehicle
{
    bool IsRegistered { get; }
    void Register();
}

public class UnregisteredVehicle : IVehicle
{
    public string Make => "Prototype";
    public string Model => "Test Rig";
    public bool IsRegistered => false;
    public decimal Mileage => 0;

    public double CalculateTax()
    {
        return 0;
    }

    public bool VerifyPeriodicTechnicalInspection()
    {
        return false;
    }
}

```

<details>
<summary>Exercise: Complete the refactoring for the Register method</summary>
```csharp

public interface IRegistractionService 
{
    bool Register(IVehicle vehicle);
}


public class SimpleRegistractionService : IRegistractionService
{
    public bool Register(IVehicle vehicle)
    {
        if (vehicle is IRegistrableVehicle registrable && !registrable.IsRegistered)
        {
            registrable.Register();
        }
    }
}
```
</details>

## Takeaway
Subtypes must honor the intent of their base types. If a method or property doesn’t make sense for all variants, don’t put it in the base interface.
