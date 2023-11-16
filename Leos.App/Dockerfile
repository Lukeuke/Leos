FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Leos.App/Leos.App.csproj", "Leos.App/"]
RUN dotnet restore "Leos.App/Leos.App.csproj"
COPY . .
WORKDIR "/src/Leos.App"
RUN dotnet build "Leos.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Leos.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Leos.App.dll"]
