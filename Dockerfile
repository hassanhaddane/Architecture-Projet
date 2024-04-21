FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src/GestionHotel.Apis

# Copier les fichiers .csproj des deux projets
COPY ["GestionHotel.Apis/GestionHotel.Apis.csproj", "."]
COPY ["GestionHotel.Externals.PaiementGateways/GestionHotel.Externals.PaiementGateways.csproj", "../GestionHotel.Externals.PaiementGateways/"]

# Restaurer les dépendances
RUN dotnet restore "./GestionHotel.Apis.csproj"

# Copier tous les fichiers des deux projets
COPY GestionHotel.Apis/. .
COPY GestionHotel.Externals.PaiementGateways/. ../GestionHotel.Externals.PaiementGateways/

# Construire le projet GestionHotel.Apis
RUN dotnet build "GestionHotel.Apis.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GestionHotel.Apis.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GestionHotel.Apis.dll"]
