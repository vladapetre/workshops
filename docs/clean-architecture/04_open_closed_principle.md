# Open-Closed Principle (OCP)

> "Software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification." — Bertrand Meyer

## Overview

The *Open-Closed Principle (OCP)* asserts that software components should be **open for extension** but **closed for modification**. This means you can add new functionality by extending existing code, without altering the code that is already working and tested. OCP is a cornerstone of the SOLID principles, promoting **stability** and **flexibility** in evolving systems.

### What It Means

OCP encourages designing modules so their behavior can be extended—typically through inheritance, interfaces, or composition—without changing their source code. This reduces the risk of introducing bugs into stable code and supports the safe addition of new features.

### Why It Matters

Adhering to OCP allows teams to **introduce new requirements** and **adapt to change** without destabilizing existing functionality. It protects core logic, supports parallel development, and enables safer, incremental evolution of the codebase.

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

public interface IVehicleTaxService 
{
    decimal CalculateTax(IVehicle vehicle);
}

public class SimpleVehicleTaxService : IVehicleTaxService
{
    public decimal CalculateTax(IVehicle vehicle)
    {
        if(vehicle.Make == "Tesla")
        {
            return 20;
        }

        return vehicle.Mileage > 10000 ? 100 : 50;
    }
}
```
*Problem: If you need to add new tax rules (e.g., based on vehicle type, registration status, or other policies), you would have to modify `SimpleVehicleTaxService`, violating OCP.*

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

public class SimpleVehicleTaxService : IVehicleTaxService
{
    public decimal CalculateTax(IVehicle vehicle)
    {
        return vehicle.Mileage > 10000 ? 100 : 50;
    }
}

public class ElectricVehicleTaxService : IVehicleTaxService
{
    public decimal CalculateTax(IVehicle vehicle)
    {
        return 20;
    }
}

public class VehicleTaxCalculator 
{
    public decimal CalculateTax(IVehicleTaxService taxService, IVehicle vehicle)
    {
        return taxService.CalculateTax(vehicle);
    }    
}
```

*Now, to add a new tax rule, simply implement a new `IVehicleTaxService` without modifying existing code. The system is open for extension, closed for modification.*

### **Key Improvements**

- **Extensible design:** Add new tax strategies by creating new classes, not changing existing ones.
- **Reduced risk:** Stable code remains untouched, minimizing regression.
- **Flexible architecture:** Easily adapt to new requirements or policies.
- **Clear separation:** Each tax rule is encapsulated in its own class.

### **Common Pitfalls**

- **Modifying existing classes** for every new requirement, risking bugs.
- **Rigid designs** that do not leverage abstraction or interfaces.
- **Premature abstraction**, adding unnecessary complexity before it’s needed.

---

## Key Takeaways

- Code should be **open for extension, closed for modification**.
- Use **interfaces and composition** to enable new behavior without changing existing code.
- OCP supports **safe evolution**, **maintainability**, and **robustness** in software design.