# Use the official .NET SDK image to build the API
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official .NET SDK image to build the API
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .

# Build the API
RUN dotnet restore "AquaInspector.csproj"
RUN dotnet publish "AquaInspector.csproj" -c Release -o /app/publish

# Run the application
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AquaInspector.dll"]
