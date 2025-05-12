# On part de l'image de base de Mysql
FROM mysql

# On ajoute notre fichier d'initialisation de la base de données au point d'entrée du conteneur
ADD init.sql /docker-entrypoint-initdb.d/init.sql

EXPOSE 3306 33060