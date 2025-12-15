# --- ETAPA 1: CONSTRUCCIÓN (BUILD) ---
# Usamos la imagen con el SDK completo para compilar
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiamos el archivo de proyecto y restauramos dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiamos el resto del código y compilamos
COPY . ./
RUN dotnet publish -c Release -o out

# --- ETAPA 2: EJECUCIÓN (RUNTIME) ---
# Usamos una imagen más ligera solo para correr la app (ASP.NET Core Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copiamos los binarios compilados de la etapa anterior
COPY --from=build /app/out .

# Exponemos el puerto que Render espera (generalmente 80 o detectado dinámicamente)
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV DOTNET_HOSTBUILDER__RELOADCONFIGONCHANGE=false
# Comando de inicio
ENTRYPOINT ["dotnet", "InsightFlow.Documents.Api.dll"]