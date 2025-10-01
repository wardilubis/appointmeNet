# Database Migrations Guide

This document explains how to use Entity Framework Core migrations for database schema management in production environments.

## Prerequisites

Make sure you have the EF Core tools installed:

```bash
dotnet tool install --global dotnet-ef
```

Or update to the latest version:

```bash
dotnet tool update --global dotnet-ef
```

## Creating Migrations

### 1. Initial Migration

Create your first migration after setting up your models:

```bash
cd AppointmentApi
dotnet ef migrations add InitialCreate
```

This will create a `Migrations` folder with migration files.

### 2. Additional Migrations

When you modify your data models, create a new migration:

```bash
dotnet ef migrations add AddNewField
```

## Applying Migrations

### Development Environment

Apply migrations to your local database:

```bash
dotnet ef database update
```

### Production Environment

For production, you have several options:

#### Option 1: Manual Migration
```bash
dotnet ef database update --connection "Host=prod-server;Database=appointmentdb;Username=user;Password=pass"
```

#### Option 2: Migration Bundle (Recommended for Production)
Create a self-contained migration bundle:

```bash
dotnet ef migrations bundle --self-contained -r linux-x64
```

Then run the bundle on the production server:

```bash
./efbundle --connection "Host=prod-server;Database=appointmentdb;Username=user;Password=pass"
```

## Viewing Migrations

List all migrations:

```bash
dotnet ef migrations list
```

## Removing Migrations

Remove the last migration (if not applied):

```bash
dotnet ef migrations remove
```

## Generating SQL Scripts

Generate SQL script for all migrations:

```bash
dotnet ef migrations script
```

Generate SQL script for specific migration range:

```bash
dotnet ef migrations script FromMigration ToMigration
```

## Current Setup

The application currently uses `EnsureCreated()` in `Program.cs` for automatic database creation. This is suitable for development but **not recommended for production**.

For production use:

1. Remove or comment out this code in `Program.cs`:
```csharp
// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<AppointmentDbContext>();
//     db.Database.EnsureCreated();
// }
```

2. Use migrations instead:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Tips

- Always create a migration before deploying model changes
- Test migrations on a staging database first
- Keep migrations in version control
- Never modify applied migrations
- Use meaningful migration names

## Troubleshooting

If you encounter issues:

1. Check connection string in `appsettings.json`
2. Ensure PostgreSQL is running
3. Verify user permissions on the database
4. Check EF Core tools version: `dotnet ef --version`

For more information, visit: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/
