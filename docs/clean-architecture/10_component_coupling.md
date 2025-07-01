# Component Coupling Principles

> "The dependency graph of components must have no cycles." — Robert C. Martin

## Overview

**Component Coupling** is about managing how components depend on each other.  
Good coupling ensures your system is **stable, flexible, and testable** as it grows.

### What It Means

Coupling principles help you:

- Keep dependencies acyclic and flowing in one direction
- Depend on stable, abstract components rather than unstable, concrete ones
- Use interfaces to invert dependencies and decouple modules

### Why It Matters

Applying coupling principles leads to:

- **Predictable builds:** No circular dependencies or fragile deployments.
- **Stable architecture:** Core components are abstract and rarely change.
- **Flexible design:** You can extend or replace modules without breaking the system.

---

### Code Example: Violation vs. Resolution

**Violation Example:**  
Circular dependency between components.

```plaintext
Component A --> Component B --> Component C --> Component A
// Problem: Cycles make builds and deployments unpredictable.
```

**Corrected Implementation:**  
Acyclic, stable dependencies.

```plaintext
Component A --> Component B --> Component C
// Dependencies flow in one direction; no cycles.
```

**Key Improvements:**

- Eliminates cycles and fragile builds
- Core components remain stable and abstract
- System is easier to extend and maintain

---

## Common Pitfalls

- Allowing cycles in the dependency graph
- Depending on unstable, concrete components from stable ones
- Failing to use interfaces to invert dependencies

---

## Key Takeaways

- Keep the dependency graph acyclic—no circular dependencies.
- Depend on stable, abstract components.
- Use interfaces to decouple and invert dependencies.

---

## Related Concepts / Further Reading

- [Component Cohesion Principles](09_component_cohesion.md)
- [The Clean Architecture (Uncle Bob's Blog)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

