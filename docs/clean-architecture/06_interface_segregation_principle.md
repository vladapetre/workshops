# Interface Segregation Principle (ISP)

> "Clients should not be forced to depend upon interfaces that they do not use." — Robert C. Martin (Uncle Bob)

## Overview

The **Interface Segregation Principle (ISP)** is the fourth of the five SOLID principles.  
It encourages you to design **small, focused interfaces** so classes only implement the methods relevant to their role.

### What It Means

ISP means splitting large interfaces into smaller, role-based contracts.  
Classes should not be forced to provide empty or meaningless implementations for methods they don’t need.

### Why It Matters

Applying ISP leads to:

- **Focused interfaces:** Each class only implements what it actually needs.
- **Easier maintenance:** Interfaces are smaller, clearer, and less likely to change for unrelated reasons.
- **Greater flexibility:** You can extend or modify behavior without impacting unrelated classes.

---

### Code Example: Violation vs. Resolution

**Violation Example:**  
A "fat" interface forces all implementers to support unrelated methods.

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
*Problem: Vehicles that are exempt from tax or registration still need to implement these methods.*

**Corrected Implementation:**  
Split into smaller, role-based interfaces.

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
*Now, classes only implement what they actually need.*

**Key Improvements:**

- No more empty or meaningless methods.
- Interfaces are easier to understand and maintain.
- Unrelated changes do not ripple through the codebase.

---

## Common Pitfalls

- Creating "fat" interfaces that try to cover every possible use case
- Grouping unrelated responsibilities into a single interface
- Failing to refactor interfaces as the system evolves

---

## Key Takeaways

- Design interfaces that are **small, focused, and role-specific**.
- This keeps your codebase clean, flexible, and easy to maintain as your system grows.

---

## Related Concepts / Further Reading

- [Dependency Inversion Principle (DIP)](07_dependency_inversion_principle.md)
- [SOLID Principles](https://en.wikipedia.org/wiki/SOLID)
- [Interface Segregation Principle (Wikipedia)](https://en.wikipedia.org/wiki/Interface_segregation_principle)