# Use the official .NET 8.0 SDK image as a build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /src

# Copy the .csproj files and restore dependencies
COPY ["Web/Web.csproj", "Web/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Domain/Domain.csproj", "Domain/"]

# Restore dependencies
RUN dotnet restore "Web/Web.csproj"

# Copy the remaining source files
COPY . .

# Build the application
WORKDIR /src/Web
RUN dotnet build "Web.csproj" -c Release -o /app/build

# Publish the application to a folder
RUN dotnet publish "Web.csproj" -c Release -o /app/publish

# Use the official .NET 8.0 runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

