# Component Coupling Principles

> "The dependencies between components should be managed to maximize flexibility and minimize the impact of change." — Robert C. Martin (Uncle Bob)

## Overview

The *Component Coupling Principles* define how components (such as namespaces, packages, or modules) should depend on each other in Clean Architecture. Proper coupling ensures that components remain **flexible**, **replaceable**, and **robust** in the face of change.

### What It Means

Component coupling principles guide architects to structure dependencies so that:

- Components are **not tightly bound** to the internal details of other components.
- **Changes in one component** do not unnecessarily cascade to others.
- The system supports **independent development, testing, and deployment**.

Three key coupling principles are:

- **ADP: The Acyclic Dependencies Principle**  
  The dependency graph of components must have no cycles. Cyclic dependencies make maintenance and deployment difficult.

- **SDP: The Stable Dependencies Principle**  
  Depend in the direction of stability. Components that are hard to change (stable) should not depend on components that are easy to change (unstable).

- **SAP: The Stable Abstractions Principle**  
  Stable components should be abstract, not concrete. This allows flexible extension without modifying stable code.

### Why It Matters

Applying coupling principles results in:

- **Easier maintenance:** Local changes do not ripple across the system.
- **Greater flexibility:** Components can be replaced or upgraded independently.
- **Simpler testing:** Dependencies can be mocked or substituted.
- **Improved scalability:** Teams can work on different components without conflict.

---

## Code Example: Violation vs. Resolution

### **Violation Example:**  

```csharp
namespace Component.Vehicle.Tax
{
    public class SimpleVehicleTaxService
    {
        public decimal CalculateTax(IVehicle vehicle)
        {
            // ...
            var registrationService = new SimpleVehicleRegistrationService();
            registrationService.CreateRegistration(vehicle);
            // ...
        }
    }
}

namespace Component.Vehicle.Registration
{
    public class SimpleVehicleRegistrationService
    {
        public void CreateRegistration(IVehicle vehicle)
        {
            // ...
        }
    }
}
```

*Problem: `SimpleVehicleTaxService` directly depends on the concrete `SimpleVehicleRegistrationService`. This creates a tight, potentially cyclic dependency between the Tax and Registration components. Changes in one component can force changes or redeployment in the other, violating ADP and SDP.*

### **Corrected Implementation:**  

```csharp
namespace Component.Vehicle.Tax
{
    public class SimpleVehicleTaxService
    {
        private readonly IVehicleRegistrationService registrationService;

        public SimpleVehicleTaxService(IVehicleRegistrationService registrationService)
            {
                this.registrationService = registrationService;
            }

            public decimal CalculateTax(IVehicle vehicle)
            {
                // ...
                registrationService.CreateRegistration(vehicle);
                // ...
            }
        }
}

namespace Component.Vehicle.Contracts.Registration 
{
    public interface IVehicleRegistrationService
    {
        void CreateRegistration(IVehicle vehicle);
    }

}

namespace Component.Vehicle.Registration
{

    public class SimpleVehicleRegistrationService : IVehicleRegistrationService
    {
        public void CreateRegistration(IVehicle vehicle)
        {
            // ...
        }
    }
}
```

*By placing `IVehicleRegistrationService` in a dedicated contracts module (`Component.Vehicle.Contracts.Registration`), both Tax and Registration components depend only on the abstraction. This eliminates cycles, aligns dependencies with abstractions, and supports flexible substitution, adhering to ADP, SDP, and SAP.*

### **Key Improvements:**

- **Acyclic dependencies:** No cycles between components.
- **Stable abstractions:** Dependencies point to interfaces, not implementations.
- **Replaceability:** Components can be substituted or updated independently.
- **Simpler testing:** Interfaces can be mocked for unit tests.
- **Greater flexibility:** Components can evolve without breaking others.

### **Common Pitfalls**

- **Cyclic dependencies:** Components that depend on each other directly or indirectly.
- **Concrete dependencies:** Relying on specific implementations instead of abstractions.
- **Stable concrete classes:** Making stable components hard to extend or adapt.
- **Ignoring dependency direction:** Allowing unstable components to be depended on by stable ones.

---

## Key Takeaways

- Manage component dependencies to avoid cycles and promote stability.
- Depend on **abstractions**, not concretions, to maximize flexibility.
- Apply ADP, SDP, and SAP to build scalable, maintainable architectures.
- Proper coupling enables **independent evolution, testing, and deployment** of components.