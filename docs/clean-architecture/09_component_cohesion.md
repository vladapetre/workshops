# Component Cohesion Principles

> "The classes in a component should be grouped together because they belong together. They should share a common purpose." — Robert C. Martin (Uncle Bob)

## Overview

Component Cohesion Principles guide how classes and modules are grouped into components (also called packages or modules) in Clean Architecture. Cohesion measures how strongly the classes within a component are related to one another. High cohesion ensures that a component has a clear, focused purpose and that its classes change for related reasons.

### What It Means

Cohesive components encapsulate a single, well-defined area of functionality. All classes within a component should be related by their purpose, such as implementing a feature, policy, or business rule. When cohesion is high, changes to a requirement are likely to affect only one component.

Three primary cohesion principles are:

- **REP: The Reuse/Release Equivalence Principle**  
  The unit of reuse is the unit of release. Only group classes into a component if you intend to reuse and release them together.

- **CCP: The Common Closure Principle**  
  Classes that change for the same reasons should be grouped together. A component should not have multiple, unrelated reasons to change.

- **CRP: The Common Reuse Principle**  
  Classes that are reused together should be packaged together. Avoid forcing clients to depend on classes they do not use.

### Why It Matters

Applying cohesion principles leads to components that are:

- **Easier to maintain**: Related changes are localized.
- **Simpler to reuse**: Components have clear, focused APIs.
- **Less prone to ripple effects**: Unrelated changes in one component do not impact others.
- **More robust to change**: Components are shielded from unrelated modifications.

---

## Example: Violation vs. Resolution

### **Violation Example:**

```csharp
namespace Component.Utility
{
    public class DateHelper { /*...*/ }
    public interface IVehicle { /*...*/ }
    public interface IVehicleTaxService {  /*...*/ }
    public class SimpleVehicleTaxService {  /*...*/ }
    public interface IVehicleRegistrationService {  /*...*/ }
    public class SimpleVehicleRegistrationService {  /*...*/ }
    public class FileExporter {  /*...*/ }
}
```

*Problem: The `Component.Utility` namespace violates cohesion principles by grouping unrelated classes (date helpers and file exporters) together. These classes do not share a common purpose and are unlikely to change or be reused together. This can force clients to depend on code they do not need and complicate maintenance and release management.*

### **Corrected Implementation:**  

```csharp
namespace Component.Utility
{
    public class DateHelper { /*...*/ }
    public class FileExporter {  /*...*/ }
}

namespace Component.Vehicle
{
    public interface IVehicle {  /*...*/ }
}

namespace Component.Vehicle.Tax
{
    public interface IVehicleTaxService {  /*...*/ }
    public class SimpleVehicleTaxService {  /*...*/ }
}

namespace Component.Vehicle.Registration
{
    public interface IVehicleRegistrationService {  /*...*/ }
    public class SimpleVehicleRegistrationService {  /*...*/ }
}

```

*Resolution: Classes are grouped into components based on their shared purpose. The registration and tax functionalities are separated into distinct namespaces, each encapsulating related classes. This aligns with REP, CCP, and CRP, ensuring that changes, reuse, and releases are managed coherently.*


### **Key Improvements**

- **Focused components:** Each namespace encapsulates a single area of responsibility.
- **Localized change:** Modifications are isolated to relevant components.
- **Reduced unnecessary dependencies:** Clients only depend on what they use.
- **Simplified release and reuse:** Components can be versioned and deployed independently.

### **Common Pitfalls**

- **Utility or "god" components:** Grouping unrelated classes for convenience.
- **Overly broad components:** Mixing multiple features or responsibilities.
- **Ignoring reuse boundaries:** Bundling classes that are never reused together.
- **Premature fragmentation:** Creating too many trivial components.

---

## Key Takeaways

- Group classes into components based on **shared purpose and change reasons**.
- Apply REP, CCP, and CRP to maximize cohesion and minimize unnecessary dependencies.
- Cohesive components are **easier to maintain, reuse, and evolve**.
- High cohesion at the component level is essential for robust, scalable architecture.