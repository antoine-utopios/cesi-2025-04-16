# Exercice 5 : Réaliser une image de MySql avec des données d'initialisation

Via un fichier `Dockerfile`, réaliser une image d'une base de données de type MySql permettant la création d'un conteneur possédant à son initialisation une base de données et des tables par défaut. L'entité de données est au choix, il peut s'agir d'albums, d'animaux, de livres, peu importe. 

## Correction

Création du fichier de peuplement de la BdD : 

```sql
create database testdb;

use testdb;

create table dogs (
    id int auto_increment primary key,
    name varchar(255) not null,
    age int not null,
    breed varchar(255) not null
);  

insert into dogs (name, age, breed) values ('Buddy', 3, 'Golden Retriever');
insert into dogs (name, age, breed) values ('Max', 5, 'Bulldog');
```

Création du dockerfile : 

```dockerfile
# On part de l'image de base de Mysql
FROM mysql

# On ajoute notre fichier d'initialisation de la base de données au point d'entrée du conteneur
ADD init.sql /docker-entrypoint-initdb.d/init.sql

EXPOSE 3306 33060
```

Build d'une image de notre base de données : 

```bash
docker build -t msql:exo05 .
```

Lancement d'un conteneur basé sur cette image : 

```bash
docker run --name exo05 -e MYSQL_ROOT_PASSWORD=password -d mysql:exo05
```

Vérification des informations contenues dans la base de données :

```bash
docker exec -it exo05 mysql -u root -p 

# On tape le mot de passe 
```

Une fois connecté, on vérifie les données présentes dans la BdD :

```sql
show databases;

select * from testdb.dogs;
```