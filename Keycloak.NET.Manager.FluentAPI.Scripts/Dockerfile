FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000
EXPOSE 5001

FROM jboss/keycloak:latest AS build
WORKDIR "/src"

#COPY ["", ""]
RUN apt-get update

COPY . .
WORKDIR "/src/Keycloak.NET.Manager.FluentAPI"
RUN dotnet restore "Keycloak.NET.Manager.FluentAPI.csproj" -v n
RUN dotnet build "Keycloak.NET.Manager.FluentAPI.csproj" -c Release -o /app/build -v n --no-restore

FROM build AS publish
RUN dotnet publish "Keycloak.NET.Manager.FluentAPI.csproj" -c Release -o /app/publish --no-restore --no-build

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Keycloak.NET.Manager.FluentAPI.dll"]