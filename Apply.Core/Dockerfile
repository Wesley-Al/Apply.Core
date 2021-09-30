FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY ["Apply/Apply.csproj", "Apply/"]
RUN dotnet restore "Apply\Apply.csproj"
COPY ./Apply ./Apply

COPY ["Apply.Library/Apply.Library.csproj", "Apply.Library/"]
RUN dotnet restore "Apply.Library\Apply.Library.csproj"
COPY ./Apply.Library ./Apply.Library

COPY ["Apply.Services/Apply.Services.csproj", "Apply.Services/"]
RUN dotnet restore "Apply.Services\Apply.Services.csproj"
COPY ./Apply.Services ./Apply.Services

WORKDIR "/src/Apply"
RUN dotnet build "Apply.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Apply.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN useradd -m intru
USER intru

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet Apply.dll

