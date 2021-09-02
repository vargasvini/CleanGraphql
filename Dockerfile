FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore "RendaSolidaria.API/RendaSolidaria.API.csproj"
WORKDIR "/src/."
COPY . .
RUN dotnet build "RendaSolidaria.API/RendaSolidaria.API.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "RendaSolidaria.API/RendaSolidaria.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RendaSolidaria.API.dll"]