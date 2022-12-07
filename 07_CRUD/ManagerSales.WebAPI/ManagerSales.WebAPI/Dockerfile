#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ManagerSales.WebAPI/ManagerSale.WebAPI.csproj", "ManagerSales.WebAPI/"]
COPY ["ManagerSale.EntityFramework/ManagerSale.EntityFramework.csproj", "ManagerSale.EntityFramework/"]
COPY ["ManagerSale.Core/ManagerSale.Core.csproj", "ManagerSale.Core/"]
COPY ["ManagerSale.ApplicationServices/ManagerSale.ApplicationServices.csproj", "ManagerSale.ApplicationServices/"]
RUN dotnet restore "ManagerSales.WebAPI/ManagerSale.WebAPI.csproj"
COPY . .
WORKDIR "/src/ManagerSales.WebAPI"
RUN dotnet build "ManagerSale.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ManagerSale.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ManagerSale.WebAPI.dll"]