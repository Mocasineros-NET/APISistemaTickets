FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["APISistemaTickets/APISistemaTickets.csproj", "APISistemaTickets/"]
RUN dotnet restore "APISistemaTickets/APISistemaTickets.csproj"
COPY . .
WORKDIR "/src/APISistemaTickets"
RUN dotnet build "APISistemaTickets.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APISistemaTickets.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APISistemaTickets.dll"]
