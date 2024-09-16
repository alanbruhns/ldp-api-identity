# Use the official .NET 8.0 SDK image as a build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /src

# Copy the .csproj files and restore dependencies
COPY ["src/Web/LDPIdentityAPI.Web.csproj", "src/Web/"]
COPY ["src/Application/Application.csproj", "src/Application/"]
COPY ["src/Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]
COPY ["src/Domain/Domain.csproj", "src/Domain/"]

RUN dotnet restore "src/Web/LDPIdentityAPI.Web.csproj"

# Copy the remaining source files
COPY . .

# Build the application
RUN dotnet build "src/Web/LDPIdentityAPI.Web.csproj" -c Release -o /app/build

# Publish the application to a folder
RUN dotnet publish "src/Web/LDPIdentityAPI.Web.csproj" -c Release -o /app/publish

# Use the official .NET 8.0 runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the published files from the build environment
COPY --from=build /app/publish .

# Set environment variables
ENV ASPNETCORE_URLS=http://+:80 
ENV ASPNETCORE_ENVIRONMENT=Production

# Expose port 80
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "LDPIdentityAPI.Web.dll"]
