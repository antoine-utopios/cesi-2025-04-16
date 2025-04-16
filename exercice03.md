# Exercice 3 : Réaliser le déploiement d'un site en usant d'un Bind Mount

Réaliser, via Docker, le déploiement d'un site internet supporté par le serveur web NGINX, ce au moyen d'un bind mount. 

Il vous sera ensuite possible de développer en direct ledit site sur votre ordinateur.

## Correction

Créer un site web en local

```bash
mkdir exercice03

touch exercice03/index.html
```

Créer un conteneur de NGINX avec les bons paramètres :

```bash
docker run -d -p 80:80 --name nginx --rm -v "C:\Users\gharr\Desktop\cesi-docker\exercice03:/usr/share/nginx/html" nginx 
```