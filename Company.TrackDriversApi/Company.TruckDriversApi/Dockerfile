FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Company.TrackDriversApi/Company.TrackDriversApi.csproj", "Company.TrackDriversApi/"]
RUN dotnet restore "Company.TrackDriversApi/Company.TrackDriversApi.csproj"
COPY . .
WORKDIR "/src/Company.TrackDriversApi"
RUN dotnet build "Company.TrackDriversApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Company.TrackDriversApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Company.TrackDriversApi.dll"]
