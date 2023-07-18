# Base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Set working directory
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./TestReact/TestReact.csproj ./
RUN dotnet restore

# Copy everything else and build the application
COPY ./TestReact ./

RUN dotnet publish TestReact.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "TestReact.dll"]