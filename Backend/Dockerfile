FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY Backend.sln ./
COPY Backend/*.csproj ./Backend/
COPY Backend.Core/*.csproj ./Backend.Core/
COPY Backend.Infrastructure/*.csproj ./Backend.Infrastructure/
COPY Backend.Core.Tests/*.csproj ./Backend.Core.Tests/

RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish Backend.sln -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

ENV ASPNETCORE_URLS=http://*:7198
ENV ASPNETCORE_ENVIRONMENT=Development


WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 7198
ENTRYPOINT ["dotnet", "Backend.dll"]