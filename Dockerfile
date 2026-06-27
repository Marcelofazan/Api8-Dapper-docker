# Estágio de compilação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY ApiMySql.csproj ./
RUN dotnet restore ApiMySql.csproj

# Copia todo o restante dos arquivos do projeto
COPY . ./

WORKDIR /app

RUN dotnet restore 
# Restaura e publica procurando o arquivo .csproj automaticamente
RUN dotnet publish ApiMySql.csproj -c Release -o /app/publish

# Estágio de execução (Usando Runtime para ficar mais leve)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ApiMySql.dll"]
