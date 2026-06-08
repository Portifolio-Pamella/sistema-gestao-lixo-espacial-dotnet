# 1. Estágio de Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia apenas o arquivo de projeto para restaurar dependências
COPY ["Aegis.Api/Aegis.Api.csproj", "Aegis.Api/"]
RUN dotnet restore "Aegis.Api/Aegis.Api.csproj"

# Copia o restante do código fonte
COPY . .

# --- DEBUG INICIADO AQUI ---
# Este comando vai listar o que foi copiado. Se você vir pastas 'bin' ou 'obj' aqui,
# significa que seu .dockerignore não está funcionando.
RUN echo "Conteúdo da pasta após o COPY:" && ls -la .
# --- DEBUG TERMINADO ---

# Compila
WORKDIR "/src/Aegis.Api"
RUN dotnet publish "Aegis.Api.csproj" -c Release -o /app/out

# 2. Estágio Final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Aegis.Api.dll"]