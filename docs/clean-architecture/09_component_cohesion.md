# Component Cohesion Principles

## What Is Component Cohesion?

**Component Cohesion** is about how classes and modules are grouped into components or packages. Well-cohesive components are easier to maintain, reuse, and release.

Robert C. Martin (Uncle Bob) introduced three primary principles for component-level architecture:

---

### 1. **Reuse/Release Equivalence Principle (REP)**
> *“The granule of reuse is the granule of release.”*

- Components that are reused together should be released together.
- This ensures stability and avoids version mismatches.

---

### 2. **Common Closure Principle (CCP)**
> *“Classes that change together should be packaged together.”*

- Group classes that tend to change for the same reason into the same component.
- This minimizes the impact of changes and reduces the risk of breaking unrelated code.

---

### 3. **Common Reuse Principle (CRP)**
> *“Don’t force users of a component to depend on things they don’t use.”*

- Avoid unnecessary coupling by packaging only what’s commonly reused together.
- Otherwise, you violate the Interface Segregation Principle at the component level.

---

## Best Practices for Component Cohesion

- Release and version components as a unit.
- Group classes by their reasons to change, not just by technical similarity.
- Avoid “kitchen sink” components—keep them focused and relevant.
- Regularly review and refactor components as your system evolves.

---

## Takeaway

Cohesive components are easier to maintain, test, and reuse.  
Apply these principles to keep your architecture clean and your releases predictable.
