# Component Principles Exercises: Cohesion and Coupling Focus

This concise exercise set groups key component principles into two focused exercises: Cohesion and Coupling. Each exercise targets essential architectural qualities to improve modularity and maintainability in your Clean Architecture project.

---

## Exercise 1: Enhance Component Cohesion

**Objective:**  
Group related classes and modules into components that change for the same reasons, maximizing internal consistency and minimizing unnecessary dependencies.

**Requirements:**

- **Analyze Change Patterns:**  
  Identify classes and services that are likely to change together (e.g., temperature-related logic, forecast generation).

- **Group by Responsibility:**  
  Organize these classes into cohesive components or assemblies (e.g., domain, application services).

- **Separate Unrelated Concerns:**  
  Extract unrelated functionality into distinct components to avoid mixing responsibilities.

- **Validate Release Boundaries:**  
  Ensure each component can be released and versioned independently, reflecting its cohesive purpose.

---

## Exercise 2: Minimize Component Coupling

**Objective:**  
Design component dependencies to be acyclic, stable, and minimal, reducing ripple effects and enabling independent evolution.

**Requirements:**

- **Map and Analyze Dependencies:**  
  Create a dependency graph of your components to identify cycles and unstable dependencies.

- **Break Cyclic Dependencies:**  
  Refactor by introducing abstractions or inverting dependencies to ensure an acyclic graph.

- **Align Dependencies Toward Stability:**  
  Ensure unstable components depend on stable ones, not vice versa.

- **Introduce Stable Abstractions:**  
  Define interfaces or abstract base classes in stable components to allow extension without modification.

- **Enable Selective Reuse:**  
  Design components so clients depend only on what they use, avoiding unnecessary coupling.

---

These two exercises will help you achieve highly cohesive and loosely coupled components, a cornerstone of maintainable and scalable Clean Architecture solutions.