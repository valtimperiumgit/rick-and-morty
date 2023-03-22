FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /source

COPY . .

RUN dotnet restore

COPY . ./

RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app

COPY --from=build  /app ./

EXPOSE 80

ENTRYPOINT ["dotnet", "RickAndMorty.Api.dll"]