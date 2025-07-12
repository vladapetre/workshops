4. Interface Segregation Principle (ISP)

Objective: Clients should not be forced to depend on interfaces they do not use.

Exercise:

    Suppose you want to expose weather data to both a web API and a background batch process.

    Define interfaces that are specific to each consumer's needs (e.g., IWeatherForecastProvider for the API, IWeatherStatisticsProvider for batch processing).

    Refactor services so that each implements only the methods relevant to its consumer.
