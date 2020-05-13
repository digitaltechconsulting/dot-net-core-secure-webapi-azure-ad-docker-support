#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SecureWebApi.csproj", ""]
RUN dotnet restore "./SecureWebApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SecureWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SecureWebApi.csproj" -c Release -o /app/publish

#FROM base AS final
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS final
WORKDIR /app
COPY --from=publish /app/publish .
#CMD dotnet dev-certs https --trust
ENTRYPOINT ["dotnet", "SecureWebApi.dll"]