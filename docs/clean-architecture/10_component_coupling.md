# Component Coupling in Clean Architecture

## What Is Component Coupling?

After defining components in your architecture, the next challenge is to **manage how they depend on each other**. Component Coupling principles ensure that:

- Dependencies between components are **stable**, **flexible**, and **testable**
- Changes in one component do **not ripple through** the entire codebase
- Higher-level components stay **decoupled from implementation details**

---

## The Three Principles of Component Coupling

Robert C. Martin introduced three key principles for **managing dependencies between components**:

---

### 1. **Acyclic Dependencies Principle (ADP)**
> *“The dependency graph of components must have no cycles.”*

- Cycles between components make builds fragile and deployment unpredictable.
- Ensure components depend **in one direction only**.
- Use **dependency inversion** or **interfaces** to break circularity.
- Apply tools or build systems that **enforce acyclic graphs**.

✅ Example: UI → Application → Domain ← Infrastructure  
⛔ Avoid: UI → Application → Domain → Infrastructure → UI

---

### 2. **Stable Dependencies Principle (SDP)**
> *“Depend in the direction of stability.”*

- A **stable component** is one that many others depend on but rarely changes.
- An **unstable component** changes frequently and should not be depended upon by stable ones.
- Domain models and interfaces tend to be **stable**.
- UIs and adapters are **unstable** and should depend on core logic.
- Use **interfaces** to invert dependencies when necessary.

---

### 3. **Stable Abstractions Principle (SAP)**
> *“A component should be as abstract as it is stable.”*

- If a component is very stable (i.e., many depend on it), it should expose **abstract interfaces** rather than concrete implementations.
- This ensures flexibility and allows changes without affecting dependent components.
- **Abstractions are easier to extend** without modifying the stable core.

**Rule of thumb:**  
> **Stable = Abstract**  
> **Unstable = Concrete**

---

## Best Practices for Component Coupling

- Keep the dependency graph acyclic—no circular dependencies.
- Depend on stable, abstract components, not on unstable, concrete ones.
- Use interfaces to invert dependencies and decouple components.
- Regularly review your component structure as the system evolves.

---

## Summary

| Principle | Focus | Goal |
|-----------|-------|------|
| **ADP**   | Graph structure | Avoid cycles |
| **SDP**   | Dependency direction | Depend on stable components |
| **SAP**   | Design maturity | Stable = abstract, not rigid |

---

## Takeaway

Component Coupling principles guide the **relationships between modules**—keeping systems loosely coupled, testable, and scalable.  
Combine them with cohesion principles (REP, CCP, CRP) for a strong Clean Architecture foundation.

