#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CuratorMagazineBlazorApp/WebClient.csproj", "CuratorMagazineBlazorApp/"]
COPY ["CuratorMagazineWebAPI/API.csproj", "CuratorMagazineWebAPI/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "CuratorMagazineBlazorApp/WebClient.csproj"
COPY . .
WORKDIR "/src/CuratorMagazineBlazorApp"
RUN dotnet build "WebClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebClient.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebClient.dll"]