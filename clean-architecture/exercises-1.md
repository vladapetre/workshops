# SOLID Principles Exercises for Clean Architecture Workshop

This set of exercises will help you apply each SOLID principle to a WeatherForecast API project. Each exercise focuses on refactoring or extending the codebase to improve maintainability, extensibility, and adherence to Clean Architecture best practices.

---

## Exercise 2: Open/Closed Principle (OCP)

**Goal:**  
Design the system to be open for extension but closed for modification by introducing a dedicated temperature conversion service.

**Current Issues:**  
- Temperature conversion logic is scattered or hardcoded, limiting extensibility.  
- Adding new temperature scales or conversions requires modifying existing code.

**Tasks:**  
1. **Introduce `ITemperatureConversionService` Interface**  
   - Define a service responsible for converting `Temperature` values between scales.

2. **Create `ITemperatureConverter` Interface and Implementations**  
   - Extract individual conversion logic into separate classes implementing `ITemperatureConverter`, each handling one scale-to-scale conversion.  
   - Each converter specifies its source (`From`) and target (`To`) scales.

3. **Implement `TemperatureConversionService`**  
   - Inject all registered `ITemperatureConverter` implementations.  
   - At runtime, select and delegate conversion to the appropriate converter based on source and target scales.  
   - Return the input temperature unchanged if no suitable converter is found.

4. **Extend the System Without Modifying Existing Code**  
   - Add new temperature scales by defining new `TemperatureScale` instances.  
   - Add new conversions by creating and registering new `ITemperatureConverter` implementations.  
   - No changes needed to existing converters or the conversion service.

5. **Demonstrate OCP Compliance**  
   - Show that new conversions can be added solely by adding new classes and registrations, without altering existing code.

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