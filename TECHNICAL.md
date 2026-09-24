# FoodChow .NET 10 API — Technical Documentation

## Table of Contents
1. [Architecture Overview](#architecture-overview)
2. [Folder Structure](#folder-structure)
3. [Layer Responsibilities](#layer-responsibilities)
4. [DALC — How It Works](#dalc--how-it-works)
5. [Request Flow](#request-flow)
6. [Adding a New API](#adding-a-new-api)
7. [Configuration](#configuration)
8. [Authentication](#authentication)
9. [NuGet Packages](#nuget-packages)

---

## Architecture Overview

Clean 4-layer architecture. Dependencies flow inward — outer layers depend on inner, never reverse.

```
┌─────────────────────────────────┐
│         FoodChow.API            │  HTTP Controllers, Program.cs
│  depends on Application + Infra │
└────────────┬────────────────────┘
             │
┌────────────▼────────────────────┐
│      FoodChow.Application       │  Services, Interfaces, DTOs
│       depends on Domain         │
└────────────┬────────────────────┘
             │
┌────────────▼────────────────────┐
│       FoodChow.Domain           │  Entities (pure C#, no dependencies)
└─────────────────────────────────┘
             ▲
┌────────────┴────────────────────┐
│     FoodChow.Infrastructure     │  DALC, Repositories, Auth
│  depends on Application         │
└─────────────────────────────────┘
```

> **Rule:** `Infrastructure` implements interfaces defined in `Application`. `Application` never references `Infrastructure` directly.

---

## Folder Structure

```
foodchow-dot-net-10-api/
│
├── FoodChow.API/                        # Entry point / Presentation layer
│   ├── Controllers/
│   │   ├── AuthController.cs            # POST /api/auth/login
│   │   ├── ProductController.cs         # GET  /api/product
│   │   └── ShopController.cs            # GET  /api/shop/{shop_id}
│   ├── Program.cs                       # DI registration, middleware pipeline
│   ├── GlobalUsings.cs
│   ├── appsettings.json                 # JWT config, MySQL connection string
│   └── FoodChow.API.csproj
│
├── FoodChow.Application/                # Business logic layer
│   ├── DTOs/
│   │   ├── ApiResponse.cs               # Generic API response wrapper
│   │   └── ShopDetailsDto.cs            # SP_GetShopDetails result shape
│   ├── Interfaces/
│   │   ├── IProductRepository.cs
│   │   └── IShopRepository.cs           # Contract for data access
│   ├── Services/
│   │   ├── ProductService.cs
│   │   └── ShopService.cs               # Business logic + validation
│   └── FoodChow.Application.csproj
│
├── FoodChow.Domain/                     # Core domain entities
│   ├── Entities/
│   │   └── Product.cs
│   └── FoodChow.Domain.csproj
│
├── FoodChow.Infrastructure/             # Data access + external services
│   ├── DALC/
│   │   └── MySqlDalc.cs                 # Reusable MySQL stored procedure executor
│   ├── Repositories/
│   │   ├── ProductRepository.cs
│   │   └── ShopRepository.cs            # Calls SP via MySqlDalc
│   ├── Auth/
│   │   └── JwtService.cs                # JWT token generation
│   └── FoodChow.Infrastructure.csproj
│
├── Dockerfile
├── FoodChow.slnx
└── TECHNICAL.md                         # This file
```

---

## Layer Responsibilities

| Layer | Responsibility | Can Reference |
|---|---|---|
| **API** | HTTP routing, request/response, auth middleware | Application, Infrastructure |
| **Application** | Business rules, validation, orchestration, DTOs, interfaces | Domain |
| **Domain** | Entity definitions, no logic, no dependencies | Nothing |
| **Infrastructure** | DB access (DALC + Repositories), JWT, external APIs | Application |

---

## DALC — How It Works

`MySqlDalc` (`FoodChow.Infrastructure/DALC/MySqlDalc.cs`) is a shared helper that executes MySQL stored procedures using **Dapper** on top of **MySqlConnector**.

### Setup

```csharp
// Registered once in Program.cs as Scoped
builder.Services.AddScoped<MySqlDalc>();
```

Connection string is read from `appsettings.json`:

```json
"ConnectionStrings": {
  "MySql": "Server=localhost;Port=3306;Database=stripe;Uid=root;Pwd=simple;"
}
```

### Column Mapping (snake_case → PascalCase)

Dapper is configured once in the `MySqlDalc` constructor:

```csharp
DefaultTypeMap.MatchNamesWithUnderscores = true;
```

This means SP columns map to DTO properties automatically — no manual mapping code needed:

| SP Column | DTO Property |
|---|---|
| `shop_id` | `ShopId` |
| `shop_name` | `ShopName` |
| `owner_name` | `OwnerName` |
| `is_active` | `IsActive` |
| `created_at` | `CreatedAt` |

### Available Methods

#### `ExecuteSpListAsync<T>` — SP returns multiple rows

```csharp
IEnumerable<ShopDetailsDto> shops = await _dalc.ExecuteSpListAsync<ShopDetailsDto>(
    "SP_GetAllShops",
    new { city = "Mumbai" }
);
```

#### `ExecuteSpSingleAsync<T>` — SP returns one row (or null)

```csharp
ShopDetailsDto? shop = await _dalc.ExecuteSpSingleAsync<ShopDetailsDto>(
    "SP_GetShopDetails",
    new { shop_id = 5 }
);
```

#### `ExecuteSpNonQueryAsync` — INSERT / UPDATE / DELETE (returns rows affected)

```csharp
int rowsAffected = await _dalc.ExecuteSpNonQueryAsync(
    "SP_UpdateShopStatus",
    new { shop_id = 5, is_active = false }
);
```

#### `ExecuteSpScalarAsync<T>` — Single value (COUNT, ID, etc.)

```csharp
int total = await _dalc.ExecuteSpScalarAsync<int>(
    "SP_GetShopCount",
    new { city = "Mumbai" }
);
```

### How Parameters Work

Pass parameters as an anonymous object. Property names become SP parameter names:

```csharp
new { shop_id = 5, city = "Mumbai" }
// → CALL SP_Name(@shop_id, @city)
```

---

## Request Flow

Full flow for `GET /api/shop/5`:

```
HTTP GET /api/shop/5
        │
        ▼
ShopController.GetShopDetails(shop_id: 5)
        │  calls
        ▼
ShopService.GetShopDetailsAsync(5)
        │  validates input, calls
        ▼
IShopRepository.GetShopDetailsAsync(5)
        │  implemented by
        ▼
ShopRepository.GetShopDetailsAsync(5)
        │  calls
        ▼
MySqlDalc.ExecuteSpSingleAsync<ShopDetailsDto>(
    "SP_GetShopDetails", new { shop_id = 5 }
)
        │  opens connection, executes
        ▼
MySQL: CALL SP_GetShopDetails(5)
        │  result set
        ▼
Dapper maps columns → ShopDetailsDto
        │
        ▼
ShopService wraps in ApiResponse<ShopDetailsDto>
        │
        ▼
Controller returns 200 OK or 404 Not Found
```

---

## Adding a New API

Example: add `GET /api/menu/{menu_id}` calling `SP_GetMenuDetails`.

### Step 1 — Create DTO (`Application/DTOs/`)

```csharp
// MenuDetailsDto.cs
namespace FoodChow.Application.DTOs
{
    public class MenuDetailsDto
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
```

### Step 2 — Create Interface (`Application/Interfaces/`)

```csharp
// IMenuRepository.cs
public interface IMenuRepository
{
    Task<MenuDetailsDto?> GetMenuDetailsAsync(int menuId);
}
```

### Step 3 — Create Repository (`Infrastructure/Repositories/`)

```csharp
// MenuRepository.cs
public class MenuRepository : IMenuRepository
{
    private readonly MySqlDalc _dalc;

    public MenuRepository(MySqlDalc dalc) => _dalc = dalc;

    public Task<MenuDetailsDto?> GetMenuDetailsAsync(int menuId) =>
        _dalc.ExecuteSpSingleAsync<MenuDetailsDto>(
            "SP_GetMenuDetails",
            new { menu_id = menuId }
        );
}
```

### Step 4 — Create Service (`Application/Services/`)

```csharp
// MenuService.cs
public class MenuService
{
    private readonly IMenuRepository _repo;

    public MenuService(IMenuRepository repo) => _repo = repo;

    public async Task<ApiResponse<MenuDetailsDto>> GetMenuDetailsAsync(int menuId)
    {
        if (menuId <= 0)
            return ApiResponse<MenuDetailsDto>.Fail("Invalid menu_id.");

        var menu = await _repo.GetMenuDetailsAsync(menuId);
        if (menu is null)
            return ApiResponse<MenuDetailsDto>.Fail($"Menu {menuId} not found.");

        return ApiResponse<MenuDetailsDto>.Ok(menu);
    }
}
```

### Step 5 — Create Controller (`API/Controllers/`)

```csharp
// MenuController.cs
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MenuController : ControllerBase
{
    private readonly MenuService _menuService;

    public MenuController(MenuService menuService) => _menuService = menuService;

    [HttpGet("{menu_id:int}")]
    public async Task<IActionResult> GetMenuDetails([FromRoute] int menu_id)
    {
        var result = await _menuService.GetMenuDetailsAsync(menu_id);
        return result.Success ? Ok(result) : NotFound(result);
    }
}
```

### Step 6 — Register in `Program.cs`

```csharp
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<MenuService>();
```

> `MySqlDalc` is already registered — no need to add it again.

---

## Configuration

`FoodChow.API/appsettings.json`

```json
{
  "Jwt": {
    "Key": "YOUR_SECRET_KEY",
    "Issuer": "FoodChow",
    "Audience": "FoodChowUsers"
  },
  "ConnectionStrings": {
    "MySql": "Server=localhost;Port=3306;Database=stripe;Uid=root;Pwd=simple;AllowZeroDateTime=True;ConvertZeroDateTime=True;"
  }
}
```

> **Security:** Never commit real secrets. Move `Jwt:Key` and DB password to environment variables or a secrets manager before deploying.

---

## Authentication

All controllers use `[Authorize]` — requests require a valid JWT Bearer token.

**Get a token:**
```
POST /api/auth/login
```

**Use the token:**
```
GET /api/shop/5
Authorization: Bearer <token>
```

Token payload contains `ClaimTypes.Name`. Expiry: 2 hours.

---

## NuGet Packages

| Package | Project | Purpose |
|---|---|---|
| `Microsoft.AspNetCore.Authentication.JwtBearer` 10.0.0 | API | JWT middleware |
| `Swashbuckle.AspNetCore` 10.1.7 | API | Swagger UI |
| `MySqlConnector` 2.4.0 | Infrastructure | MySQL driver (async-native) |
| `Dapper` 2.1.35 | Infrastructure | Micro-ORM, SP parameter binding + result mapping |
| `Microsoft.Extensions.Configuration.Abstractions` 10.0.0 | Infrastructure | `IConfiguration` access |
| `System.IdentityModel.Tokens.Jwt` 7.5.1 | Infrastructure | JWT token generation |
| `Microsoft.IdentityModel.Tokens` 7.5.1 | Infrastructure | Token signing keys |
