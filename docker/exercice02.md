# Exercice : 2048 Docker 

Réaliser, via Docker, le déploiement d'une instance du jeu 2048 qui doit être accessible dans le navigateur à l'adresse http://localhost/

## Correction 

Chercher une image du jeu 2048 via les commandes Docker : 

```bash
docker search 2048
```

Récupérer l'image : 

```bash
docker pull quchaonet/2048
```

Inspecter l'image pour voir quel sont ses ports exposés : 

```bash
docker inspect quchaonet/2048
```

Lancer l'image avec le port forwarding : 

```bash
docker run -d -p 80:8080 quchaonet/2048
```