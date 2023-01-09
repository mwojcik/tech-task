FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Company.TruckDriversApi/Company.TruckDriversApi.csproj", "Company.TruckDriversApi/"]
COPY ["Company.TruckDrivers.Infrastructure/Company.TruckDrivers.Infrastructure.csproj", "Company.TruckDrivers.Infrastructure/"]
COPY ["Company.TruckDrivers.Application/Company.TruckDrivers.Application.csproj", "Company.TruckDrivers.Application/"]
COPY ["Company.TruckDrivers.Domain/Company.TruckDrivers.Domain.csproj", "Company.TruckDrivers.Domain/"]
COPY ["Company.TruckDrivers.Shared/Company.TruckDrivers.Shared.csproj", "Company.TruckDrivers.Shared/"]
RUN dotnet restore "Company.TruckDriversApi/Company.TruckDriversApi.csproj"
COPY . .
WORKDIR "/src/Company.TruckDriversApi"
RUN dotnet build "Company.TruckDriversApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Company.TruckDriversApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Company.TruckDriversApi.dll"]
