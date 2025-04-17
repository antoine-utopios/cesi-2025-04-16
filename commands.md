# Commandes principales de Docker

### Lister les conteneurs en cours d'exécution sur la machine 

```bash
docker ps
```

* `-a` Pour également voir ceux en état d'arret.

### Voir la liste des images disponibles sur la machine 

```bash
docker images

docker image ls
```

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

### Pour sauvegarder l'état d'un conteneur afin d'en avoir une image 

```bash
docker commit <nom | id> <nom-image>
```

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

# Démo Dockerfile

```dockerfile

# Permet de choisir une image de base pour la suite des instructions
FROM image 

# Choisir un dossier de travail pour la suite des commandes (création à la volée si non existant)
WORKDIR /chemin/dossier

# On va exécuter la suite des instructions dans le build en tant que...
USER utilisateur

# Pour exécuter des commandes lors du build de notre image
RUN command subcommand 
RUN ["command", "subcommand"]

# Ajouter des fichiers dans l'image
COPY <chemin-hote> <chemin-image>

# Ajouter des fichiers dans l'image (plus de fichiers pris en charge, désarchivage à la volée)
ADD <chemin-hote> <chemin-image>

# Exposer un port (pour informer que le conteneur peut être branché à ce port)
EXPOSE port

# On choisi le point d'entrée dans le conteneur avec l'instruction suivante
CMD ["command", "subcommand"]

# On choisi le point d'entrée dans le conteneur avec l'instruction suivante (Plus resctrictive et utilisée pour faire des conteneurs utilitaires)
ENTRYPOINT ["command", "subcommand"]
```

### Structure de base du YAML 

Le Yaml est un langage de sayntaxe permettant le déploiement de ressources Docker via docker compose, il se structure de la sorte

* Pour faire une propriété et une valeur 

```yml
property: value
```

* Pour faire une propriété possédant plusieurs valeurs sous la forme d'une liste 

```yml
property: 
- valueA
- valueB
- valueC
```

Pour faire une propriété ayant comme valeur un objet :

```yml
property: 
  subPropA: value
  subPropB: value
  subPropC: value
```

