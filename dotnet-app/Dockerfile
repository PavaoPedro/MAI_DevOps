# Use uma imagem base otimizada para .NET
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS build
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Criação de um usuário sem privilégios administrativos
RUN adduser --disabled-password appuser
USER appuser

# Variável de ambiente para a configuração do ASP.NET Core
ENV ASPNETCORE_URLS=http://+:80

# Início da aplicação
ENTRYPOINT ["dotnet", "MAIOCEAN.dll"]
