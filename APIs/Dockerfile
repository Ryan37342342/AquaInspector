# Use the official .NET SDK image to build the API
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Use the official .NET SDK image to build the API
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .


#create local dev certificate
RUN dotnet dev-certs https
RUN dotnet dev-certs https --trust

# Build the API
RUN dotnet restore "AquaInspector.csproj"
RUN dotnet publish "AquaInspector.csproj" -c Release -o /app/publish

# Run the application
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AquaInspector.dll"]
