FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TodoApp.WebApi/TodoApp.WebApi.csproj", "TodoApp.WebApi/"]
RUN dotnet restore "TodoApp.WebApi/TodoApp.WebApi.csproj"
COPY . .
WORKDIR "/src/TodoApp.WebApi"
RUN dotnet build "TodoApp.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TodoApp.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoApp.WebApi.dll"]
