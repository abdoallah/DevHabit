# DevHabit

DevHabit is a simple ASP.NET Core API that demonstrates good development habits. The API exposes a single `WeatherForecast` endpoint and comes pre-configured with OpenTelemetry instrumentation.

## Building the API

Restore dependencies and build the project using the .NET SDK:

```bash
dotnet build
```

You can also build the Docker image:

```bash
docker build -t devhabitapi -f DevHabit.Api/Dockerfile .
```

## Running the API

Run the API locally with:

```bash
dotnet run --project DevHabit.Api
```

To start the full stack, including Seq and the Aspire dashboard, use Docker Compose:

```bash
docker compose up
```

The API will be available at `https://localhost:5001` by default.
