# Use a imagem de runtime do .NET Core como base
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app
COPY . .
ENTRYPOINT ["dotnet", "MAIOCEAN.csproj"]