# appointmeNet
API untuk penjadwalan / Appointment Scheduling API

A minimal .NET Web API for managing appointments with PostgreSQL database support.

## Features

- **CRUD Operations**: Create, Read, Update, and Delete appointments
- **PostgreSQL Database**: Uses Entity Framework Core with PostgreSQL
- **RESTful API**: Clean REST endpoints for appointment management
- **OpenAPI/Swagger**: Built-in API documentation

## Prerequisites

- .NET 9.0 SDK or later
- PostgreSQL database server

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/wardilubis/appointmeNet.git
cd appointmeNet
```

### 2. Configure Database Connection

Update the connection string in `AppointmentApi/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=appointmentdb;Username=postgres;Password=postgres"
  }
}
```

### 3. Run the Application

```bash
cd AppointmentApi
dotnet run
```

The API will be available at:
- HTTPS: `https://localhost:7000`
- HTTP: `http://localhost:5000`

### 4. Access API Documentation

Open your browser and navigate to:
- OpenAPI endpoint: `https://localhost:7000/openapi/v1.json`

## API Endpoints

### Appointments

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/appointments` | Get all appointments |
| GET | `/api/appointments/{id}` | Get appointment by ID |
| POST | `/api/appointments` | Create new appointment |
| PUT | `/api/appointments/{id}` | Update appointment |
| DELETE | `/api/appointments/{id}` | Delete appointment |

### Example Request Body (POST/PUT)

```json
{
  "title": "Doctor Appointment",
  "description": "Annual checkup",
  "startTime": "2024-10-15T10:00:00Z",
  "endTime": "2024-10-15T11:00:00Z",
  "location": "Medical Center",
  "attendeeEmail": "patient@example.com",
  "status": "Scheduled"
}
```

## Data Model

**Appointment**
- `Id` (int): Unique identifier
- `Title` (string): Appointment title
- `Description` (string): Appointment description
- `StartTime` (DateTime): Start time
- `EndTime` (DateTime): End time
- `Location` (string): Location
- `AttendeeEmail` (string): Attendee email
- `Status` (string): Status (e.g., "Scheduled", "Completed", "Cancelled")
- `CreatedAt` (DateTime): Creation timestamp
- `UpdatedAt` (DateTime?): Last update timestamp

## Project Structure

```
AppointmentApi/
├── Models/
│   └── Appointment.cs          # Data model
├── Data/
│   └── AppointmentDbContext.cs # Database context
├── Program.cs                   # Application entry point & API endpoints
├── appsettings.json            # Configuration
└── AppointmentApi.csproj       # Project file
```

## Technologies Used

- **.NET 9.0**: Latest .NET framework
- **ASP.NET Core Minimal API**: Lightweight API framework
- **Entity Framework Core**: ORM for database operations
- **Npgsql**: PostgreSQL provider for Entity Framework Core
- **OpenAPI**: API documentation

## Development

### Build the project
```bash
dotnet build
```

### Run in development mode
```bash
dotnet run --environment Development
```

### Database Notes

The application uses `EnsureCreated()` to automatically create the database and tables on first run. For production scenarios, consider using migrations:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## License

This project is open source and available under the MIT License.
