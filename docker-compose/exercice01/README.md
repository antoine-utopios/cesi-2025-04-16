# Exercice Docker Compose #1

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