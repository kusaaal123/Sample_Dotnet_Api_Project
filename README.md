# Sample .NET API Project

A sample ASP.NET Core Web API project demonstrating basic REST API operations.

## Features

- **ASP.NET Core 8.0** - Latest .NET framework
- **Swagger/OpenAPI** - API documentation and testing
- **Two Sample Controllers**:
  - `WeatherForecastController` - Simple GET endpoints
  - `ProductController` - Full CRUD operations (GET, POST, PUT, DELETE)
- **Logging** - Built-in logging support

## Project Structure

```
Sample_Dotnet_Api_Project/
├── Controllers/
│   ├── WeatherForecastController.cs
│   └── ProductController.cs
├── Program.cs
├── appsettings.json
├── Sample_Dotnet_Api_Project.csproj
└── README.md
```

## Getting Started

### Prerequisites
- .NET 8.0 SDK or later
- Visual Studio, Visual Studio Code, or any text editor

### Installation

1. Clone the repository:
```bash
git clone https://github.com/kusaaal123/Sample_Dotnet_Api_Project.git
cd Sample_Dotnet_Api_Project
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Run the application:
```bash
dotnet run
```

The API will start at `https://localhost:5001` (or `http://localhost:5000` for HTTP)

## API Endpoints

### Weather Forecast
- `GET /api/weatherforecast` - Get 5-day forecast
- `GET /api/weatherforecast/{id}` - Get forecast for specific day

### Products
- `GET /api/product` - Get all products
- `GET /api/product/{id}` - Get product by ID
- `POST /api/product` - Create new product
- `PUT /api/product/{id}` - Update product
- `DELETE /api/product/{id}` - Delete product

## Swagger UI

Once running, visit: `https://localhost:5001/swagger`

This provides an interactive API documentation and testing interface.

## Development

### Building
```bash
dotnet build
```

### Testing
```bash
dotnet test
```

### Publishing
```bash
dotnet publish -c Release
```

## License

MIT License

## Author

Created by kusaaal123