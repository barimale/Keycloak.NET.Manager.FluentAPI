FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src

ARG NUGET_FEED_NAME="GitHub"
ARG NUGET_FEED_SOURCE="https://nuget.pkg.github.com/barimale/index.json"
ARG NUGET_FEED_USER=barimale
ARG NUGET_FEED_PASSWORD=Julian2019

COPY ["", ""]
RUN apt-get update
RUN apt-get install nuget -y

RUN nuget sources Add -StorePasswordInClearText -Name ${NUGET_FEED_NAME} -Source ${NUGET_FEED_SOURCE} -UserName ${NUGET_FEED_USER} -Password ${NUGET_FEED_PASSWORD}
COPY . .
WORKDIR "/src/SoundManager.Shop"
RUN dotnet restore "SoundManager.Shop.csproj" -v n --configfile ~/.config/NuGet/NuGet.Config
RUN dotnet build "SoundManager.Shop.csproj" -c Release -o /app/build -v n --no-restore

FROM build AS publish
RUN dotnet publish "SoundManager.Shop.csproj" -c Release -o /app/publish --no-restore --no-build

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SoundManager.Shop.dll"]