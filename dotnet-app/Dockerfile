# Use uma imagem base otimizada para .NET
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Criação do estágio final a partir da imagem base
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Criação de um usuário sem privilégios administrativos
RUN adduser --disabled-password --gecos '' appuser
USER appuser

# Variável de ambiente para a configuração do ASP.NET Core
ENV ASPNETCORE_URLS=http://+:80

# Início da aplicação
ENTRYPOINT ["dotnet", "MAIOCEAN.dll"]
