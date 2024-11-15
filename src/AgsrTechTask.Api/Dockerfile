﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AgsrTechTask.Api/AgsrTechTask.Api.csproj", "AgsrTechTask.Api/"]
COPY ["AgsrTechTask.Domain/AgsrTechTask.Domain.csproj", "AgsrTechTask.Domain/"]
COPY ["AgsrTechTask.Dal/AgsrTechTask.Dal.csproj", "AgsrTechTask.Dal/"]
RUN dotnet restore "AgsrTechTask.Api/AgsrTechTask.Api.csproj"
COPY . .
WORKDIR "/src/AgsrTechTask.Api"
RUN dotnet build "AgsrTechTask.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AgsrTechTask.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AgsrTechTask.Api.dll"]
