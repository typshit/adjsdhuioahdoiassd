# Use the official ASP.NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official ASP.NET Core build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj file(s) and restore dependencies
COPY ["MyApi.csproj", "./"]  # Copy the .csproj to the working directory
RUN dotnet restore "./MyApi.csproj"

# Copy the rest of the application code
COPY . .

# Build the project
RUN dotnet build "./MyApi.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "./MyApi.csproj" -c Release -o /app/publish

# Final stage: copy the publish output to the base image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyApi.dll"]
