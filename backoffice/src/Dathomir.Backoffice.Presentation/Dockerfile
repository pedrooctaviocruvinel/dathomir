FROM mcr.microsoft.com/dotnet/aspnet:11.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:11.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Dathomir.Backoffice.Presentation/Dathomir.Backoffice.Presentation.csproj","src/Dathomir.Backoffice.Presentation/"]
COPY ["src/Dathomir.Backoffice.Application/Dathomir.Backoffice.Application.csproj","src/Dathomir.Backoffice.Application/"]
COPY ["src/Dathomir.Backoffice.CrossCutting/Dathomir.Backoffice.CrossCutting.csproj","src/Dathomir.Backoffice.CrossCutting/"]
COPY ["src/Dathomir.Backoffice.Domain/Dathomir.Backoffice.Domain.csproj","src/Dathomir.Backoffice.Domain/"]
COPY ["src/Dathomir.Backoffice.Infrastructure.DependencyInjection/Dathomir.Backoffice.Infrastructure.DependencyInjection.csproj","src/Dathomir.Backoffice.Infrastructure.DependencyInjection/"]
COPY ["src/Dathomir.Backoffice.Infrastructure.Data/Dathomir.Backoffice.Infrastructure.Data.csproj","src/Dathomir.Backoffice.Infrastructure.Data/"]
COPY ["src/Dathomir.Backoffice.Infrastructure.Provider/Dathomir.Backoffice.Infrastructure.Provider.csproj","src/Dathomir.Backoffice.Infrastructure.Provider/"]
RUN dotnet restore "./src/Dathomir.Backoffice.Presentation/Dathomir.Backoffice.Presentation.csproj"
COPY . .
WORKDIR "/src/src/Dathomir.Backoffice.Presentation"
RUN dotnet build "./Dathomir.Backoffice.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Dathomir.Backoffice.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dathomir.Backoffice.Presentation.dll"]
