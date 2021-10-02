FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY ["Intru/Intru.csproj", "Intru/"]
RUN dotnet restore "Intru\Intru.csproj"
COPY ./Intru ./Intru

COPY ["Intru.Library/Intru.Library.csproj", "Intru.Library/"]
RUN dotnet restore "Intru.Library\Intru.Library.csproj"
COPY ./Intru.Library ./Intru.Library

COPY ["Intru.Services/Intru.Services.csproj", "Intru.Services/"]
RUN dotnet restore "Intru.Services\Intru.Services.csproj"
COPY ./Intru.Services ./Intru.Services

WORKDIR "/src/Intru"
RUN dotnet build "Intru.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Intru.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN useradd -m intru
USER intru

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet Intru.dll

