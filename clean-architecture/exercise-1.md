1. Single Responsibility Principle (SRP)

Objective: Ensure each class has one reason to change.

Exercise:

    Refactor the WeatherService class. Currently, it generates both random weather data and summary descriptions.

    Extract the summary generation logic into a separate class (e.g., WeatherSummaryProvider).

    The WeatherService should only be responsible for orchestrating the forecast generation, not for how summaries are chosen.
