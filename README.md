# FoodChow .NET 10 Web API — Enterprise Restaurant & Ordering Backend

[![.NET 10](https://img.shields.io/badge/.NET-10.0-purple.svg)](https://dotnet.microsoft.com/)
[![Architecture](https://img.shields.io/badge/Architecture-Clean%204--Layer-blue.svg)](#architecture-overview)
[![Database](https://img.shields.io/badge/Database-MySQL%208.0%20%7C%20Dapper-orange.svg)](#database--stored-procedures)
[![Auth](https://img.shields.io/badge/Security-JWT%20Bearer%20%2B%20BCrypt-green.svg)](#authentication--security)
[![Docker](https://img.shields.io/badge/Container-Docker%20Ready-2496ED.svg)](#docker--deployment)

Production-grade RESTful API backend developed for the **FoodChow** Restaurant Operating System during my backend development internship. The API powers restaurant ordering, kitchen display systems, catalog management, multi-gateway payments, and courier dispatch integrations.

---

## 🏛️ Architecture Overview

The solution follows strict **Clean Architecture** principles divided into 4 decoupled projects:

```
┌────────────────────────────────────────────────────────┐
│                      FoodChow.API                      │
│   (Presentation Layer: Controllers, Swagger, Program)   │
└───────────────────────────┬────────────────────────────┘
                            │ depends on
             ┌──────────────┴──────────────┐
             ▼                             ▼
┌─────────────────────────┐   ┌──────────────────────────┐
│  FoodChow.Application   │   │ FoodChow.Infrastructure  │
│ (Services, DTOs, IRepo) │◄──┤ (Dapper DALC, Repos, JWT)│
└────────────┬────────────┘   └──────────────────────────┘
             │ depends on
             ▼
┌─────────────────────────┐
│     FoodChow.Domain     │
│ (Core Entities & Enums) │
└─────────────────────────┘
```

* **`FoodChow.API`**: HTTP routing, JWT Bearer middleware, Swagger documentation, exception handling.
* **`FoodChow.Application`**: Business rules, service logic, DTOs, and repository interfaces.
* **`FoodChow.Domain`**: Core enterprise business entities and domain models (pure C#, 0 dependencies).
* **`FoodChow.Infrastructure`**: Reusable Dapper `MySqlDalc` calling MySQL stored procedures, JWT token generator, and BCrypt hasher.

---

## 🔒 Authentication & Security

* **Password Hashing**: BCrypt algorithm with Work Factor 11.
* **Access Tokens**: Short-lived stateless JWT tokens (HMAC-SHA256) with claim-based authorization.
* **Refresh Tokens**: Opaque refresh tokens stored in database with automatic rotation upon reissue.
* **SQL Injection Immunity**: 100% of data queries execute through parameterized MySQL Stored Procedures via Dapper.

### Seeded Admin Credentials:
* **Email**: `admin@foodchow.com`
* **Password**: `Admin@123`
* **Role**: `Admin`

---

## 🚀 Key Modules Developed

| Module | Endpoints | Description |
|---|---|---|
| **Auth** | `/api/Auth/*` | Register, Login, Refresh-Token, Logout, and `/api/Auth/me` |
| **Catalog & Products** | `/api/Product`, `/api/Menu`, `/api/Category` | Food catalog, categorization, pricing, and modifier options |
| **Orders** | `/api/Order`, `/api/OrderCreate`, `/api/OrderTrack` | Multi-item checkout, tax calculation, and live tracking |
| **Delivery Integrations** | `/api/Lalamove`, `/api/PorterConfiguration`, `/api/DoorDashDelivery` | Third-party courier dispatch and rate estimation |
| **Payments** | `/api/Stripe`, `/api/StripeConnect`, `/api/Wallet` | Credit card processing and restaurant payout transfers |
| **POS & Operations** | `/api/Table`, `/api/Reservation`, `/api/KdsTerminalsSetting` | Dine-in table reservations and Kitchen Display System |

---

## 🛠️ Getting Started Locally

### Prerequisites
* [.NET 10 SDK](https://dotnet.microsoft.com/)
* MySQL 8.0+ or [XAMPP](https://www.apachefriends.org/) (running on port 3306)

### 1. Database Setup
Execute the SQL script located at:
```
Database/foodchow_auth_schema.sql
```
against your MySQL server to initialize the schema, stored procedures, and the seeded admin account.

### 2. Configure Connection String
Update `FoodChow.API/appsettings.json`:
```json
"ConnectionStrings": {
  "MySql": "Server=localhost;Port=3306;Database=foodchow_db;Uid=root;Pwd=;"
}
```

### 3. Run the API
```bash
dotnet restore
dotnet run --project FoodChow.API/FoodChow.API.csproj
```
Navigate to Swagger UI in your browser:
```
http://localhost:55661/swagger/index.html
```

---

## 🐳 Docker & Cloud Deployment

A production-ready multi-stage [Dockerfile](Dockerfile) is included:
```bash
docker build -t foodchow-api .
docker run -p 8080:8080 -e ConnectionStrings__MySql="..." foodchow-api
```
Cloud Run compatibility is built-in via ASP.NET Core `ForwardedHeadersOptions` in `Program.cs`.

---

## 👨‍💻 Developer & Internship
* **Developer**: Shrey Patel
* **Project**: FoodChow Backend API (.NET 10 Clean Architecture)
* **GitHub**: [@shreypatel0504](https://github.com/shreypatel0504)
