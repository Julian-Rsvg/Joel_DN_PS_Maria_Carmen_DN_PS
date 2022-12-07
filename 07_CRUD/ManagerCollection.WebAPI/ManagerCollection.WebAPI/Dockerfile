#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ManagerCollection.WebAPI/ManagerCollection.WebAPI.csproj", "ManagerCollection.WebAPI/"]
COPY ["ManagerCollection.Core/ManagerCollection.Core.csproj", "ManagerCollection.Core/"]
COPY ["ManagerCollection.EntityFramwork/ManagerCollection.EntityFramwork.csproj", "ManagerCollection.EntityFramwork/"]
COPY ["ManagerCollection.ApplicationServices/ManagerCollection.ApplicationServices.csproj", "ManagerCollection.ApplicationServices/"]
RUN dotnet restore "ManagerCollection.WebAPI/ManagerCollection.WebAPI.csproj"
COPY . .
WORKDIR "/src/ManagerCollection.WebAPI"
RUN dotnet build "ManagerCollection.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ManagerCollection.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ManagerCollection.WebAPI.dll"]