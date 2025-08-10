# Acme Product Management API

This solution is a .NET 8 web API for managing Acme Corporation products.
It allows users to register new products into the database, get all products with product details (category, name, product code, price, SKU, stock quantity, and date added), and get a product by its id.

Minimal setup is needed because it contains an embedded, seeded SQLite database and Swagger configuration.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022
- Git

## Setup Instructions

1. Clone the repository.

2. Open the `Acme.ProductManagement.sln` file in Visual Studio 2022.

3. Launch the solution:
- Find the green play button in the Visual Studio toolbar. The right of it should say "IIS Express"
- If it doesn't say IIS Express, click the dropdown arrow next to that play button and select "IIS Express".
- Click the green play button.

## Seeded Product Categories
1.  Explosives
2. Propulsion Devices
3. Traps and Snares
4. Projectiles
5. Aerial Devices
6. Construction
7. Miscellaneous Gadgets
8. Groceries