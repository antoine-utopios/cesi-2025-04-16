# Exercice 7 : Réaliser le déploiement d'une API ASP.NET

Réaliser, via Docker et l'utilisation d'un Dockerfile, le déploiement d'une API faite avec le framework ASP.NET, en version production. Pour cela, vous utiliserez une image construite via deux étapes, une étape de build et une étape de déploiement.

## Correction

Créer une API avec Visual Studio

Créer un fichier Dockerfile pour build une image de note API en version prod : 

```dockerfile
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
```

Faire un build de l'image : 

```bash
docker build -t asp-app .
```

Faire un conteneur disposant de notre image : 

```bash
docker run -d -p 80:8080 asp-app
```