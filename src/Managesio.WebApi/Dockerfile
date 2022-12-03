FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Managesio.WebApi/Managesio.WebApi.csproj", "Managesio.WebApi/"]
COPY ["Managesio.Core/Managesio.Core.csproj", "Managesio.Core/"]
RUN dotnet restore "Managesio.WebApi/Managesio.WebApi.csproj"
COPY . .
WORKDIR "/src/Managesio.WebApi"
RUN dotnet build "Managesio.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Managesio.WebApi.csproj" -c Release -o /app/publish

FROM node:16-alpine as client-build
WORKDIR /app
COPY ./Managesio.ClientSide/package.json ./Managesio.ClientSide/yarn.lock ./
RUN yarn
COPY ./Managesio.ClientSide .
RUN yarn build

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=client-build /Managesio.WebApi/wwwroot/ ./wwwroot
ENTRYPOINT ["dotnet", "Managesio.WebApi.dll"]
