FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY WebApplication.Testing.Features.sln ./
COPY WebApplication.Testing.Features/*.csproj ./WebApplication.Testing.Features/

RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish WebApplication.Testing.Features.sln -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

ENV ASPNETCORE_URLS=http://*:7199
ENV ASPNETCORE_ENVIRONMENT=Development


WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 7199
ENTRYPOINT ["dotnet", "WebApplication.Testing.Features.dll"]