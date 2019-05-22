FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["HappyPathApi/HappyPathApi.csproj", "HappyPathApi/"]
RUN dotnet restore "HappyPathApi/HappyPathApi.csproj"
COPY . .
WORKDIR "/src/HappyPathApi"
RUN dotnet build "HappyPathApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "HappyPathApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HappyPathApi.dll"]