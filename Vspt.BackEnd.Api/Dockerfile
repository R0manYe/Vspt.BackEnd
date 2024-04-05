#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Vspt.BackEnd.Api/Vspt.BackEnd.Api.csproj", "Vspt.BackEnd.Api/"]
COPY ["Vspt.Backend.Application/Vspt.BackEnd.Application.csproj", "Vspt.Backend.Application/"]
COPY ["Vspt.BackEnd.Domain/Vspt.BackEnd.Domain.csproj", "Vspt.BackEnd.Domain/"]
COPY ["Vspt.BackEnd.Flagman.Domain/Vspt.BackEnd.Flagman.Domain.csproj", "Vspt.BackEnd.Flagman.Domain/"]
COPY ["Vspt.Common.Api.Contract/Vspt.Common.Api.Contract.csproj", "Vspt.Common.Api.Contract/"]
COPY ["Vspt.Box.Data/Vspt.Box.Data.csproj", "Vspt.Box.Data/"]
COPY ["Vspt.BackEnd.Flagman.ApiClient/Vspt.BackEnd.Flagman.ApiClient.csproj", "Vspt.BackEnd.Flagman.ApiClient/"]
COPY ["Vspt.BackEnd.Infrastructure/Vspt.BackEnd.Infrastructure.csproj", "Vspt.BackEnd.Infrastructure/"]
COPY ["Vspt.Box.Data.EfCore/Vspt.Box.Data.EfCore.csproj", "Vspt.Box.Data.EfCore/"]
COPY ["Vspt.Shared.EfCore/Vspt.Box.EfCore.csproj", "Vspt.Shared.EfCore/"]
COPY ["Vspt.Box.AbstractTransactions/Vspt.Box.AbstractTransactions.csproj", "Vspt.Box.AbstractTransactions/"]
COPY ["Vspt.Box.EfCore.Npgsql/Vspt.Box.EfCore.Npgsql.csproj", "Vspt.Box.EfCore.Npgsql/"]
COPY ["Vspt.Service.Common/Vspt.Service.Common.csproj", "Vspt.Service.Common/"]
COPY ["Vspt.Shared.MediatR/Vspt.Box.MediatR.csproj", "Vspt.Shared.MediatR/"]
RUN dotnet restore "./Vspt.BackEnd.Api/./Vspt.BackEnd.Api.csproj"
COPY . .
WORKDIR "/src/Vspt.BackEnd.Api"
RUN dotnet build "./Vspt.BackEnd.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Vspt.BackEnd.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vspt.BackEnd.Api.dll"]