#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GF5BAB_SOF_2023241_Webapp/GF5BAB_SOF_2023241_Webapp.csproj", "GF5BAB_SOF_2023241_Webapp/"]
RUN dotnet restore "./GF5BAB_SOF_2023241_Webapp/./GF5BAB_SOF_2023241_Webapp.csproj"
COPY . .
WORKDIR "/src/GF5BAB_SOF_2023241_Webapp"
RUN dotnet build "./GF5BAB_SOF_2023241_Webapp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GF5BAB_SOF_2023241_Webapp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GF5BAB_SOF_2023241_Webapp.dll"]