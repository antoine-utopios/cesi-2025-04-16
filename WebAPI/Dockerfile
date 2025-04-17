FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY WebAPI.csproj ./

RUN dotnet restore

COPY . ./

RUN dotnet publish -c Release -o output

FROM mcr.microsoft.com/dotnet/aspnet:8.0  

WORKDIR /app

COPY --from=build /src/output ./

CMD ["dotnet", "WebAPI.dll"]