# AppointmentApi

A minimal .NET Web API for managing appointments with PostgreSQL database.

## Project Structure

```
AppointmentApi/
├── Models/
│   └── Appointment.cs          # Appointment entity model
├── Data/
│   └── AppointmentDbContext.cs # EF Core database context
├── Properties/
│   └── launchSettings.json     # Launch configuration
├── Program.cs                   # Application entry point and API endpoints
├── AppointmentApi.csproj       # Project configuration
├── appsettings.json            # Application settings (includes connection string)
├── appsettings.Development.json # Development-specific settings
├── AppointmentApi.http         # Sample HTTP requests for testing
├── MIGRATIONS.md               # Guide for database migrations
└── README.md                   # This file
```

## Key Features

- **Minimal API**: Uses ASP.NET Core minimal API approach for simplicity
- **Entity Framework Core**: ORM for database operations
- **PostgreSQL Support**: Uses Npgsql provider
- **Auto Database Creation**: Database and tables are created automatically on first run
- **OpenAPI**: Built-in API documentation

## API Endpoints

All endpoints are under the `/api/appointments` base path:

- `GET /api/appointments` - Get all appointments
- `GET /api/appointments/{id}` - Get appointment by ID
- `POST /api/appointments` - Create new appointment
- `PUT /api/appointments/{id}` - Update appointment
- `DELETE /api/appointments/{id}` - Delete appointment

## Quick Start

1. Make sure PostgreSQL is running (or use docker-compose from root directory)
2. Update connection string in `appsettings.json` if needed
3. Run the application:

```bash
dotnet run
```

## Testing

Use the `AppointmentApi.http` file with VS Code REST Client extension or any other HTTP client to test the API endpoints.

## Production Deployment

For production deployment:

1. Remove the auto-creation code from `Program.cs`
2. Use EF Core migrations (see `MIGRATIONS.md`)
3. Update connection string with production credentials
4. Consider using environment variables for sensitive data
5. Enable CORS if needed for frontend applications
6. Add authentication and authorization

## Dependencies

- Microsoft.AspNetCore.OpenApi (9.0.9)
- Npgsql.EntityFrameworkCore.PostgreSQL (9.0.4)
- Microsoft.EntityFrameworkCore.Design (9.0.9)

## Learn More

- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core)
- [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core)
- [Npgsql Documentation](https://www.npgsql.org/efcore)
