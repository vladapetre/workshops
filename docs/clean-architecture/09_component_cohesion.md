# Component Cohesion Principles

> "Classes that change together should be packaged together." — Robert C. Martin

## Overview

**Component Cohesion** is about how you group classes and modules into components or packages.  
Well-cohesive components are easier to maintain, reuse, and release.

### What It Means

Cohesion principles help you:

- Group related classes by their reasons to change or be reused
- Release and version components as a unit
- Avoid unnecessary coupling between unrelated code

### Why It Matters

Applying cohesion principles leads to:

- **Stable releases:** Components that are reused together are released together.
- **Focused modules:** Each component has a clear, unified purpose.
- **Reduced risk:** Changes in one area don't break unrelated code.

---

### Code Example: Violation vs. Resolution

**Violation Example:**  
A component contains unrelated classes that change for different reasons.

```plaintext
Component X: [OrderService, UserService, EmailSender]
// Problem: Changes in one class force unnecessary releases of others.
```

**Corrected Implementation:**  
Group classes by their reasons to change.

```plaintext
OrderComponent: [OrderService]
UserComponent: [UserService]
EmailComponent: [EmailSender]
// Each component is focused and released independently.
```

**Key Improvements:**

- Components are easier to maintain and release
- Reduces unnecessary dependencies and version mismatches
- Supports focused, modular development

---

## Common Pitfalls

- Grouping classes by technical similarity instead of reasons to change
- Creating "kitchen sink" components with unrelated responsibilities
- Not refactoring components as the system evolves

---

## Key Takeaways

- Group classes that change together into the same component.
- Release and version components as a unit.
- Keep components focused and relevant to their purpose.

---

## Related Concepts / Further Reading

- [Component Coupling Principles](10_component_coupling.md)
- [The Clean Architecture (Uncle Bob's Blog)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
