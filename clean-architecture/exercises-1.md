# SOLID Principles Exercises for Clean Architecture Workshop

This document presents a comprehensive set of exercises designed to help you apply each SOLID principle to the provided WeatherForecast API project. Each exercise focuses on refactoring or extending the existing codebase to improve maintainability, extensibility, and adherence to Clean Architecture best practices.

---

## Exercise 1: Single Responsibility Principle (SRP)

**Objective:**  
Ensure that each class or module has a single reason to change by separating concerns clearly.

**Current Situation:**
- The `WeatherService` class is responsible for generating weather forecasts and managing temperature values.
- The `Temperature` record currently hardcodes the temperature scale as Celsius.
- The `WeatherForecast` record combines multiple concerns: date, temperature, and summary.

**Tasks:**
- **Extract Temperature Conversion Logic:**  
  Refactor the `Temperature` record or related classes to separate the temperature value from the logic that converts between scales (Celsius, Fahrenheit). Create a dedicated service or helper class responsible solely for temperature conversions.
- **Separate Forecast Generation from Summary Selection:**  
  Currently, the forecast generation and summary selection are tightly coupled in `WeatherService`. Extract the summary selection logic into a separate class or service, e.g., `WeatherSummaryProvider`.
- **Clarify Responsibilities of WeatherService:**  
  After extraction, ensure `WeatherService` focuses exclusively on orchestrating the generation of weather forecasts, delegating summary and temperature scale concerns to dedicated components.

---

## Exercise 2: Open/Closed Principle (OCP)

**Objective:**  
Design your system so that it is open for extension but closed for modification.

**Current Situation:**
- The `TemperatureScale` record supports only Celsius and Fahrenheit.
- Adding new temperature scales (e.g., Kelvin) would require modifying the `TemperatureScale` record and possibly other parts of the system.
- The temperature conversion logic is not extensible.

**Tasks:**
- **Make TemperatureScale Extensible:**  
  Refactor `TemperatureScale` to support extension without modifying existing code. Consider making it an abstract base class or interface with concrete implementations for each scale.
- **Implement a Temperature Conversion Strategy:**  
  Create a strategy pattern or similar design that allows adding new temperature scales and their conversion logic without changing existing classes.
- **Update Serialization:**  
  Ensure your JSON converter and model binding support the extensible temperature scales cleanly.
- **Demonstrate Adding a New Scale:**  
  As a practical test, add support for the Kelvin scale by extending your design without modifying existing classes.

---

## Exercise 3: Liskov Substitution Principle (LSP)

**Objective:**  
Ensure that subclasses or derived types can be substituted for their base types without altering the correctness of the program.

**Current Situation:**
- The `WeatherForecast` record is concrete and fixed.
- There is no abstraction for different types of forecasts (e.g., detailed forecasts with humidity, wind speed).

**Tasks:**
- **Define an Interface or Abstract Base for Forecasts:**  
  Create an interface `IWeatherForecast` or an abstract base class that defines the contract for a weather forecast.
- **Implement Subtypes of Forecasts:**  
  Implement at least one alternative forecast type, such as `DetailedWeatherForecast`, which includes additional properties like humidity and wind speed.
- **Refactor Services and Controllers:**  
  Update `WeatherService` and controller actions to depend on the abstraction rather than concrete types, ensuring substitutability.
- **Verify Behavior:**  
  Demonstrate that replacing `WeatherForecast` with `DetailedWeatherForecast` instances does not break existing functionality.

---

## Exercise 4: Interface Segregation Principle (ISP)

**Objective:**  
Clients should not be forced to depend on interfaces they do not use.

**Current Situation:**
- `WeatherService` exposes methods for both forecast generation and average temperature calculation.
- Consumers such as the API controller and potential batch processes have different needs.

**Tasks:**
- **Define Segregated Interfaces:**  
  Create separate interfaces for forecast provision (`IWeatherForecastProvider`) and statistical calculations (`IWeatherStatisticsProvider`).
- **Implement Interfaces in Services:**  
  Refactor `WeatherService` to implement these interfaces explicitly.
- **Refactor Consumers:**  
  Modify the `WeatherForecastController` to depend only on `IWeatherForecastProvider` and any batch/statistics consumers to depend only on `IWeatherStatisticsProvider`.
- **Demonstrate Decoupling:**  
  Show that consumers are not coupled to unnecessary methods or data, improving modularity and testability.

---

## Exercise 5: Dependency Inversion Principle (DIP)

**Objective:**  
Depend on abstractions, not concretions, to reduce coupling and increase flexibility.

**Current Situation:**
- Controllers depend directly on the static `WeatherService` class.
- There is no use of dependency injection or interfaces to abstract service dependencies.

**Tasks:**
- **Define Service Abstractions:**  
  Create interfaces such as `IWeatherService` or the segregated interfaces from the ISP exercise.
- **Refactor WeatherService to Implement Interfaces:**  
  Change `WeatherService` from static to instance-based and implement the interfaces.
- **Configure Dependency Injection:**  
  Register the service implementations and supporting services (e.g., summary provider, temperature converter) in the DI container.
- **Inject Dependencies in Controllers:**  
  Refactor controllers to receive service interfaces via constructor injection instead of calling static methods.
- **Validate Flexibility:**  
  Demonstrate how swapping implementations (e.g., mock services for testing) becomes straightforward.

---

## Bonus Exercise: Robust Model Binding and Serialization

**Objective:**  
Ensure that your custom types like `TemperatureScale` integrate seamlessly with ASP.NET Core model binding and JSON serialization.

**Tasks:**
- **Implement and Register a Custom JSON Converter:**  
  Use `System.Text.Json` to serialize/deserialize `TemperatureScale` as a string representing the scale name.
- **Implement a Custom Model Binder:**  
  Create a model binder to support binding `TemperatureScale` from query parameters or route data.
- **Test Endpoints:**  
  Verify that API endpoints accept and return temperature scales correctly without validation errors.

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

This comprehensive exercise set will deepen your understanding of SOLID principles in a real-world Clean Architecture context, improving code quality, maintainability, and scalability.