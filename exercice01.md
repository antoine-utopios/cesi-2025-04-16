# Exercice : Réaliser le déploiement d'une page d'accueil sur un serveur web conteneurisé

Via Docker, faire en sorte de déployer un site internet puis d'en personnaliser la page d'accueil


## Correction

Lancer un conteneur NGINX sur Docker Engine : 

```bash
docker run -d -p --name nginx 80:80 nginx
```

On entre dans le conteneur et on y exécute Bash:

```bash
docker exec -it nginx bash
```

Installer nano pour la modification de fichier: 

```bash
apt update 

apt install -y nano
```

```bash
nano /usr/share/nginx/html/index.html

# On édite le fichier, puis CTRL+O, CTRL+X pour sauvegarder et fermer le fichier
```

On peut ensuite vérifier le site via http://localhost/

