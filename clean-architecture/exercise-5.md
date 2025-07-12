5. Dependency Inversion Principle (DIP)

Objective: Depend on abstractions, not concretions.

Exercise:

    Refactor the controller so it does not depend directly on the static WeatherService.

    Define an interface (e.g., IWeatherService) and inject it into the controller via constructor injection.

    Register the implementation in the DI container, and update usage accordingly.
