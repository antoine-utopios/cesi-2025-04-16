# Commandes principales de Docker

### Lister les conteneurs en cours d'exécution sur la machine 

```bash
docker ps
```

* `-a` Pour également voir ceux en état d'arret.

### Récupérer une image sur DockerHub 

```bash
docker pull <nom-image>
```

### Pour rechercher des images disponibles sur le registre lié 

```bash
docker search <query>
```

### Pour inspecter une ressource Docker

```bash
docker inspect <id | name>
```

### Lancer un conteneur à partir d'une image 

```bash
docker run <nom-image>
```

* `-t` Pour ajouter le support de TTY
* `-i` Pour lancer le conteneur en interactif 
* `-d` Pour lancer le conteneur en détaché
* `--name` Pour nommer notre conteneur et éviter de le perdre 
* `--rm` Pour supprimer les données également lors de la suppression du conteneur
* `-p <port-hote>:<port-conteneur>` Pour faire du port forwarding entre l'hôte (notre machine) et le conteneur
* `-v <chemin-conteneur>` Création d'un volume anonyme dans le but de sauvegarder un chemin de fichier / dossier
* `-v <nom-volume>:<chemin-conteneur>` Création d'un volume nommé  dans le but de sauvegarder un chemin de fichier / dossier (possibilité de lier plusieurs conteneurs à ce même volume)
* `-v <chemin-hote>:<chemin-conteneur>` Création d'un bind mount dans le but de lier un chemin de fichier / dossier entre le conteneur et l'hôte
* `--network <nom>` Pour faire en sorte de brancher le conteneur à un réseau

### Pour stopper des conteneurs

```bash
docker stop <id | nom>
```

### Pour supprimer un conteneur 

```bash
docker rm <id | nom>
```

* `-f` Forcer la fermeture du conteneur en amont de la suppression

### Pour libérer toute une catégorie de ressource

```bash
docker <type-ressource> prune
```

### Pour exécuter des commandes dans un conteneur

```bash
docker exec <id | nom> <command>
```

* `-i` Pour le faire en mode intéractif
* `-t` Pour le faire avec prise en charge de TTY

# Pour créer un réseau

```bash
docker network create <nom>
```

# Pour lister une ressource Docker 

```bash
docker <resource> ls
```