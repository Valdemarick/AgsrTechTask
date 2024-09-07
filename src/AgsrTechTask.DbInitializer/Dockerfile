FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AgsrTechTask.DbInitializer/AgsrTechTask.DbInitializer.csproj", "AgsrTechTask.DbInitializer/"]
COPY ["AgsrTechTask.Dal/AgsrTechTask.Dal.csproj", "AgsrTechTask.Dal/"]
COPY ["AgsrTechTask.Domain/AgsrTechTask.Domain.csproj", "AgsrTechTask.Domain/"]
RUN dotnet restore "AgsrTechTask.DbInitializer/AgsrTechTask.DbInitializer.csproj"
COPY . .
WORKDIR "/src/AgsrTechTask.DbInitializer"
RUN dotnet build "AgsrTechTask.DbInitializer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AgsrTechTask.DbInitializer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AgsrTechTask.DbInitializer.dll"]
