# CarBooking Repository Pattern

This is a sample .NET solution implementing the Repository Pattern for a Car Booking system. It demonstrates a clean separation of concerns across repository, service, API, and testing layers.

## Project Structure
TestCase.CarBooking.WebApi.sln
│
├── TestCase.CarBooking.Repository # Contains repository interfaces and implementations
├── TestCase.CarBooking.WebApi # ASP.NET Core Web API for car booking endpoints
├── TestCase.CarBooking.UnitTest # Unit tests for services/repositories
├── .gitattributes
├── .gitignore



## Technologies Used

- .NET (C#)
- ASP.NET Core Web API
- xUnit (for unit testing)
- Repository Pattern

## Features

- Booking cars using a clean architecture
- Unit testing for core logic
- Abstraction through interfaces
- Maintainable and testable codebase

## Getting Started

1. **Clone the repository**
   ```bash
   git clone <your-repo-url>
   cd TestCase.CarBooking.WebApi
   dotnet build
   dotnet run --project TestCase.CarBooking.WebApi
   dotnet test TestCase.CarBooking.UnitTest
