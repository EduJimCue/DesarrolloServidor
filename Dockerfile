FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /DesarrolloWeb


# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
ENV variable=valorAdjudicado
WORKDIR /DesarrolloWeb
EXPOSE 6376
COPY --from=build-env /DesarrolloWeb/out .
VOLUME [ "/volume" ]
ENTRYPOINT ["dotnet", "Prueba.dll"]