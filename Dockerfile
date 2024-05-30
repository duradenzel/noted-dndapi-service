
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["noted-dndapi-service/noted-dndapi-service.csproj", "noted-dndapi-service"]
COPY ["noted-api.Tests/noted-api.Tests.csproj", "noted-api.Tests"]
RUN dotnet restore "noted-dndapi-service/noted-dndapi-service.csproj"
COPY . .
WORKDIR "/src/noted-dndapi.service"
RUN dotnet build "noted-dndapi.service.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build as publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "noted-dndapi.service.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 5010


ENTRYPOINT ["dotnet", "noted-dndapi-service.dll"]
