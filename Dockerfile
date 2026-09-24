FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project files and restore dependencies first for caching
COPY FoodChow.API/FoodChow.API.csproj FoodChow.API/
COPY FoodChow.Application/FoodChow.Application.csproj FoodChow.Application/
COPY FoodChow.Domain/FoodChow.Domain.csproj FoodChow.Domain/
COPY FoodChow.Infrastructure/FoodChow.Infrastructure.csproj FoodChow.Infrastructure/
RUN dotnet restore FoodChow.API/FoodChow.API.csproj

# Copy the rest of the source code and build
COPY . .
RUN dotnet publish FoodChow.API/FoodChow.API.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "FoodChow.API.dll"]
