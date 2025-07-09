# Single Responsibility Principle (SRP)

> "A module should have one, and only one, reason to change." — Robert C. Martin (Uncle Bob)

## Overview

The *Single Responsibility Principle (SRP)* states that a class or module should have **only one reason to change**, focusing on a **single responsibility**. It is a core part of the SOLID principles aimed at creating **modular** and **maintainable** code.

### What It Means

SRP means each component should address **one specific concern**. Mixing responsibilities leads to **complexity** and **fragile code**. Separating concerns reduces **unintended side effects** and simplifies **maintenance**.

### Why It Matters

Following SRP enhances **readability**, **testability**, and **maintainability** by isolating changes and minimizing risk. It helps build **robust**, **adaptable** systems that are easier to **evolve** and **understand**.

---

## Code Example: Violation vs. Resolution

### **Violation Example:**  

```csharp
public interface IVehicle 
{
    public string Make { get; set; }
    public string Model { get; set; }
    public bool IsRegistered { get; set; }
    public decimal Mileage { get; set; }
}

public interface IVehicleService 
{
    decimal CalculateTax(IVehicle vehicle);
    void CreateRegistration(IVehicle vehicle);
}
```

*Problem: The SRP violation lies in `IVehicleService` combining **business logic (tax calculation)** and **administrative operations (registration creation)** into one interface. To adhere to SRP, these responsibilities should be split into separate interfaces or services, each with a single, focused purpose.*

### **Corrected Implementation:**  

```csharp
public interface IVehicle 
{
    public string Make { get; set; }
    public string Model { get; set; }
    public bool IsRegistered { get; set; }
    public decimal Mileage { get; set; }
}

public interface IVehicleTaxService 
{
    decimal CalculateTax(IVehicle vehicle);
}

public interface IVehicleRegistrationService 
{
    void CreateRegistration(IVehicle vehicle);
}
```

*By splitting the original `IVehicleService` into `IVehicleTaxService` and `IVehicleRegistrationService`, the design now respects SRP, ensuring each interface encapsulates a **single responsibility** and a **single reason to change**, which leads to cleaner, more modular, and maintainable code.*

### **Key Improvements:**

- **Clear responsibility separation** between tax calculation and registration.  
- **Easier maintenance** with isolated changes and reduced side effects.  
- **Simplified testing** through focused, independent interfaces.  
- **Greater flexibility** to extend or modify services independently.  
- **Improved readability** with interfaces that clearly express intent.  
- **Lower coupling**, promoting modular and maintainable architecture.

These enhancements lead to cleaner, more robust, and adaptable software.

### **Common Pitfalls**

- **Misinterpreting “one responsibility”** as one function, causing excessive fragmentation.  
- **Applying SRP at the wrong abstraction level**, leading to trivial or disconnected classes.  
- **Mixing unrelated concerns**, creating multiple reasons to change in one class.  
- **Poor naming and organization**, resulting in vague utility or helper classes.  
- **Serving multiple actors in one class**, causing conflicting change reasons.  
- **Ignoring code smells** like large classes, long methods, and mixed concerns.


## Key Takeaways

- A class should have **only one reason to change**.  
- SRP promotes **separation of concerns** by isolating responsibilities.  
- It improves **maintainability** and **testability** by reducing coupling.  
- Avoid mixing unrelated tasks in the same class or module.  
- Over-fragmentation can lead to **unnecessary complexity**; keep responsibilities meaningful.  
- SRP applies at all levels: classes, methods, and components.  
- Identify **reasons to change** based on stakeholders or concerns.  
- Clear responsibilities lead to **cleaner, modular, and adaptable code**.