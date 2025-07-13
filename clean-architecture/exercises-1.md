# SOLID Principles Exercises for Clean Architecture Workshop

This set of exercises will help you apply each SOLID principle to a WeatherForecast API project. Each exercise focuses on refactoring or extending the codebase to improve maintainability, extensibility, and adherence to Clean Architecture best practices.

---

## Exercise 1: Single Responsibility Principle (SRP)

**Goal:**  
Ensure each class or module has a single reason to change.

**Current Issues:**
- `WeatherService` handles both forecast generation and temperature management.
- `Temperature` contains value and scale.
- `WeatherForecast` mixes date, temperature, and summary.

**Tasks:**
1. **Extract Temperature Conversion Logic**
   - Create a service (e.g., `ITemperatureConversionService`) for converting `Temperature` between scales.
   - Keep `Temperature` as a simple value object.

2. **Extract Weather Summary Provider**
   - Move summary selection to an `IWeatherSummaryProvider` service.
   - Refactor `WeatherService` to use this provider.

3. **Refactor WeatherService**
   - Make `WeatherService` orchestrate only, delegating summary and conversion to injected services.

---

## Exercise 2: Open/Closed Principle (OCP)

**Goal:**  
Design for extension without modifying existing code.

**Current Issues:**
- `TemperatureScale` only supports Celsius and Fahrenheit.
- Adding new scales (e.g., Kelvin) requires code changes.
- Conversion logic is not extensible.

**Tasks:**
1. **Make TemperatureScale Extensible**
   - Use a registry or factory pattern for scales.
   - Ensure JSON serialization and model binding support new scales dynamically.

2. **Extend Temperature Conversion Service**
   - Use a strategy or lookup pattern for extensible conversions.
   - Demonstrate adding Kelvin with minimal changes.

---

## Exercise 3: Liskov Substitution Principle (LSP)

**Goal:**  
Allow derived types to substitute for base types without breaking correctness.

**Current Issues:**
- `WeatherForecast` is concrete and fixed.
- No abstraction for different forecast types.

**Tasks:**
1. **Define Forecast Abstraction**
   - Create an `IWeatherForecast` interface or abstract base class.
   - Implement `WeatherForecast` as one type.

2. **Create Alternative Forecast Types**
   - Add e.g., `DetailedWeatherForecast` with humidity, wind speed.
   - Ensure services and consumers use the abstraction.

3. **Verify Substitutability**
   - Replace `WeatherForecast` with `DetailedWeatherForecast` in service/controller without breaking functionality.

---

## Exercise 4: Interface Segregation Principle (ISP)

**Goal:**  
Clients should not depend on interfaces they do not use.

**Current Issues:**
- `WeatherService` exposes both forecast and statistics methods.
- Different consumers have different needs.

**Tasks:**
1. **Define Segregated Interfaces**
   - Create `IWeatherForecastProvider` and `IWeatherStatisticsProvider`.

2. **Implement Interfaces in Services**
   - Refactor `WeatherService` to implement these interfaces.

3. **Refactor Consumers**
   - Make `WeatherForecastController` depend only on `IWeatherForecastProvider`.
   - Batch/statistics consumers depend only on `IWeatherStatisticsProvider`.

4. **Demonstrate Decoupling**
   - Show consumers are not coupled to unnecessary methods/data.

---

## Exercise 5: Dependency Inversion Principle (DIP)

**Goal:**  
Depend on abstractions, not concretions.

**Current Issues:**
- Controllers depend directly on static `WeatherService`.
- No dependency injection or interfaces.

**Tasks:**
1. **Define Service Abstractions**
   - Create interfaces (e.g., `IWeatherService` or those from ISP).

2. **Refactor WeatherService**
   - Make it instance-based and implement interfaces.

3. **Configure Dependency Injection**
   - Register services and supporting services in DI container.

4. **Inject Dependencies in Controllers**
   - Use constructor injection for service interfaces.

5. **Validate Flexibility**
   - Show how swapping implementations (e.g., for testing) is easy.

---

## Summary Table

| SOLID Principle | Focus Area              | Key Deliverables                                         |
|-----------------|------------------------|----------------------------------------------------------|
| SRP             | Separation of concerns | Extract summary provider and temperature conversion logic |
| OCP             | Extensibility          | Make temperature scales and conversions extensible        |
| LSP             | Substitutability       | Define forecast abstractions and support multiple types   |
| ISP             | Interface segregation  | Split service interfaces by consumer needs               |
| DIP             | Dependency injection   | Depend on interfaces, inject services, remove static deps |

---

These exercises will deepen your understanding of SOLID principles in a real-world Clean Architecture context, improving code quality, maintainability, and scalability.