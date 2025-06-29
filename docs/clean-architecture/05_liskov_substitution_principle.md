# Liskov Substitution Principle (LSP)

## What is the Liskov Substitution Principle?

The **Liskov Substitution Principle (LSP)** is the third of the five SOLID principles of object-oriented design. It states:

> **Objects of a superclass should be replaceable with objects of its subclasses without affecting the correctness of the program.**  
> – Barbara Liskov

LSP means that you should be able to use any subtype of an interface or base class **without altering the expected behavior** of the program. Subtypes must honor the contract and intent of their base types, ensuring consistent and predictable behavior.

### Why LSP Matters

When LSP is violated:

- Subtypes break expectations, causing bugs or unexpected behavior.
- Code that works with the base type may fail or behave incorrectly with certain subtypes.
- The abstraction becomes unreliable and hard to maintain.

By following LSP, you ensure your abstractions are robust and your code is easier to extend and reason about.

---

## Example: LSP Violation

In this example, a subclass `UnregisteredVehicle` throws an exception when trying to register, violating the contract of `Vehicle`. If a method expects any `IVehicle` and calls `CreateRegistration()`, this will throw unexpectedly—a clear violation of LSP.

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

This breaks the expectation that all `IVehicle` objects can be registered.

### Refactoring for LSP

To comply with LSP, only types that support registration should expose registration behavior. Move registration to a separate interface, so unsupported operations are not part of the contract.

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
            return true;
        }
        return false;
    }
}
```
</details>

**Key improvements:**

- Only vehicles that support registration implement the registration interface.
- The contract for `IVehicle` is clear and safe for all subtypes.
- Code that works with `IVehicle` does not risk unexpected exceptions.

---

## Best Practices for Applying LSP

- **Design clear contracts:** Only include methods and properties in base interfaces or classes that make sense for all subtypes.
- **Avoid unsupported operations:** Don’t force subtypes to implement methods they can’t support—move those to separate interfaces.
- **Honor invariants:** Subtypes should not weaken preconditions or strengthen postconditions of base type methods.
- **Test substitutability:** Regularly verify that your subtypes can replace base types in real scenarios without breaking behavior.
- **Document expectations:** Clearly state the intended use and constraints of your abstractions.

---

## Takeaway

Subtypes must honor the intent of their base types.  
If a method or property doesn’t make sense for all variants, don’t put it in the base interface.  
This keeps your abstractions reliable and your codebase robust.
