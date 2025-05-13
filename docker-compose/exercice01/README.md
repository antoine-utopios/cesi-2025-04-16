# Exercices Docker Compose

## Exercice Docker Compose - 1 - Communication entre APIs

Réaliser le déploiement et la communication de deux APIs via l'utilisation de docker compose. 

Les deux APIs sont réalisées en deux langages différents (l'une en Node.js, l'autre en ASP.NET).

L'API réalisée en Node.js sert à stocker dans une base de données des logs prevenant d'autres APIs. Ces logs doivent être transmis sous la forme d'un JSON tel que: 

```json
{
  "message": "value",
  "level": "info | warn | debug",
  "source": "value"
}
```

D'un autre côté, une API en ASP.NET propose de manipuler une entité de type `Dog` (un chien classique composé comme ceci : 

```csharp
public class Dog {
  public int Id [ get; set; ]
  public string Name [ get; set; ]
  public string Breed [ get; set; ]
  public int Age [ get; set; ]
}
```

Ces chiens sont stockés en RAM via une fausse base de données (`FakeDB`) injectée à notre contrôleur via un singleton. Néanmoins, l'API des chiens cherchera, lors de son exécurition, à envoyer des logs de l'accès à ses routes de lecture des données multiples ou via un id de chien. 

L'objectif est donc de faire en sorte: 

* De posséder une base de données de type MySQL via un conteneur de base de données
* Tester l'API de stockage des logs
* Tester l'API de manipulation des chiens et vérifier qu'elle arrive à communiquer avec l'API en Node.js
* Dockerizer l'API de Node.js et faire en sorte qu'elle puisse fonctionner via des appels depuis l'extérieur (exposer les ports)
* Dockerizer l'API réalisée en ASP.NET de sorte à ce que l'on puisse l'appeler de l'extérieur, vérifier ensuite qu'elle communique bien avec l'API de logs et que celle-ci peut stocker en BdD les informations

## Exercice Docker Compose - 2 - Création d'un panel de microservices

Créer un ensemble d'API possédant chacune une base de données, déployées d'une seule commande et communiquant via des requêtes HTTP.

La première API servira à manipuler des entités de type Livre dont la structure pourrait être telle que: 

```json
{
  "id": "value",
  "isbn": "value",
  "title": "value",
  "description": "value",
  "price": 123.456
}
```

La seconde API servira à manipuler des entités de type Client dont la structure pourrait être telle que: 

```json
{
  "id": "value",
  "firstName": "value",
  "lastName": "value",
  "email": "value",
  "phoneNumber": "value",
  "borrows": []
}
```

La dernière de la série servira à manipuler les Emprunts, dont la structure serait: 

```json
{
  "id": "value",
  "clientId": "value",
  "bookId": "value",
  "dueDate": "value"
}
```

Les APIs pourront être réalisées dans le langage de votre choix, mais devront communiquer entre elles et ne pas avoir à gérer des entités autres que celle concernée par leur base de données de sorte à respecter les bonnes pratiques. Cela n'empêchera cependant pas les APIs de peupler les informations provenant de liaisons via des requêtes et l'envoi ou la réception de DTOs, comme cela serait par exemple le cas pour obtenir les emprunts en cours pour un client de la bibliothèque (récupérations de ces emprunts, puis récupération des informations des livres concernés par l'emprunt via les autres API).

Il ne devra pas être possible d'emprunter plusieurs fois le même ouvrage, et un client ne devrait pas pouvoir emprunter plus de 5 livres en même temps. 

Idéalement, les APIs devront être traitées via une API unique qui sera la seule à réceptionner les requêtes des utilisateurs, celle-ci communiquera ensuite en interne avec les trois autres APIs de sorte à répondre aux demandes de l'utilisateur. 