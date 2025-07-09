# Design Principles 

Clean Architecture is founded on a set of key design principles that ensure the system is maintainable, testable, and adaptable by enforcing clear separation of concerns and dependency management. These principles include:

- **Domain-Centric Approach**  
  The business domain and its rules are placed at the center of the architecture, isolating core logic from external concerns like UI, databases, or frameworks.

- **Separation of Concerns**  
  Different parts of the system (business logic, UI, database, infrastructure) are isolated into distinct layers to reduce complexity and improve maintainability.

- **Layered Architecture with Dependency Rule**  
  The system is organized into concentric layers (Entities, Use Cases, Interface Adapters, Frameworks & Drivers) where dependencies always point inward toward the domain core. Outer layers depend on inner layers, but not vice versa. This is also known as the Dependency Inversion Principle.

- **Dependency Inversion Principle (DIP)**  
  High-level modules (business logic) should not depend on low-level modules (infrastructure); both depend on abstractions (interfaces). Abstractions do not depend on details; details depend on abstractions.

- **Use of Abstractions and Interfaces**  
  Interfaces define boundaries between layers, enabling flexibility, testability, and easier substitution of components without affecting core logic.

- **Single Responsibility Principle (SRP)**  
  Each component or module should have one reason to change, focusing on a single responsibility to improve clarity and maintainability.

- **Interface Segregation Principle (ISP)**  
  Interfaces should be fine-grained and client-specific, avoiding forcing clients to depend on methods they do not use.

- **Open-Closed Principle (OCP)**  
  Software entities should be open for extension but closed for modification, allowing behavior to be extended without changing existing code.

- **Low Coupling Between Layers**  
  Layers and components are loosely coupled, minimizing ripple effects when changes occur and enabling independent evolution of parts of the system.

- **Use Case-Oriented Design**  
  The architecture centers around use cases that represent application-specific business rules and user intentions, organizing code to reflect real-world scenarios.

- **Postponing Technical Decisions**  
  Decisions about frameworks, databases, and UI implementations are deferred to outer layers, keeping the core domain free from technology-specific dependencies.

---

### Summary of Core Layers in Clean Architecture

| Layer                | Responsibility                                                                                       |
|----------------------|---------------------------------------------------------------------------------------------------|
| **Entities**         | Core business rules and domain models, independent of external systems                             |
| **Use Cases**        | Application-specific business logic, orchestrating interactions between entities and interfaces   |
| **Interface Adapters** | Translating data between core application and external systems (UI, DB, web services)             |
| **Frameworks & Drivers** | Infrastructure components like databases, UI frameworks, external tools                          |

This layered structure, combined with the principles above, ensures that the core business logic remains isolated and protected, enabling maintainable, testable, and adaptable software systems.

---

### References

- Domain-Centric approach and Dependency Rule: ,   
- Dependency Inversion, Interface Segregation, Single Responsibility, Open-Closed Principles:   
- Use Case Orientation and Low Coupling:   
- Layered structure and separation of concerns: , 
