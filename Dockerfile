#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AIWonderRecipe/Server/AIWonderRecipe.Server.csproj", "AIWonderRecipe/Server/"]
COPY ["AIWonderRecipe/Client/AIWonderRecipe.Client.csproj", "AIWonderRecipe/Client/"]
COPY ["AIWonderRecipe/Shared/AIWonderRecipe.Shared.csproj", "AIWonderRecipe/Shared/"]
RUN dotnet restore "AIWonderRecipe/Server/AIWonderRecipe.Server.csproj"
COPY . .
WORKDIR "/src/AIWonderRecipe/Server"
RUN dotnet build "AIWonderRecipe.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AIWonderRecipe.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AIWonderRecipe.Server.dll"]