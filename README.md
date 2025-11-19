# HealthTest API

API de prueba .NET 10 con endpoint de health check para despliegue en Docker.

## Endpoints

- `GET /health` - Health check estándar de ASP.NET Core
- `GET /health/status` - Health check con información detallada (JSON)

## Ejecución Local

```bash
dotnet run --project HealthTest.Api
```

## Docker

### Build
```bash
docker build -t healthtest-api:latest .
```

### Run
```bash
docker run -d -p 8080:8080 --name healthtest healthtest-api:latest
```

### Test
```bash
curl http://localhost:8080/health/status
```

## Tecnologías

- .NET 10
- ASP.NET Core Minimal API
- Health Checks
