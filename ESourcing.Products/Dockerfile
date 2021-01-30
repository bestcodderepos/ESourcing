#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["ESourcing.Products/ESourcing.Products.csproj", "ESourcing.Products/"]
RUN dotnet restore "ESourcing.Products/ESourcing.Products.csproj"
COPY . .
WORKDIR "/src/ESourcing.Products"
RUN dotnet build "ESourcing.Products.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ESourcing.Products.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ESourcing.Products.dll"]
