# Exercice : Communication entre conteneurs

Réaliser, via Docker, le déploiement de deux conteneurs de type Ubuntu. Faire ensuite en sorte que les deux conteneurs puissent se `ping` l'un l'autre via la commande linux dédiée. Pour cela, il faudra que les deux conteneurs se trouvent dans le même réseau vis à vis de Docker.


## Correction

Création du réseau pour les deux conteneurs: 

```bash
docker network create exo04
```

```bash
docker run -it --network exo04 --name ub-a ubuntu
docker run -it --network exo04 --name ub-b ubuntu
```

Installer la command `ping` : 

```bash
apt update 

apt install iputils-ping
```

Pinger, depuis le conteneur, l'autre conteneur : 

```bash
# Depuis `ub-b`
ping ub-a
```