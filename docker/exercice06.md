# Exercice 6 : Conteneur utilitaire 

Réaliser, via Docker, le déploiement d'un conteneur utilitaire permettant le calcul de nombres en Javascript

Ce conteneur devra permettre, via ENTRYPOINT et la présence de plusieurs paramètres d'entrée, de réaliser les 4 opérations de base (Addition, Soustraction, Division, Multiplication) sous la forme de : 

```bash
Calculator.js 4 5 --addition

# 4 + 5 = 9
```

Pour cela, vous pourrez soit utiliser 4 scripts (addition.js, soustraction.js, ...) ou un seul script en utilisant un flag permettant la sélection de l'opération à effectuer

## Correction

On réaliser un fichier de script node : 

```js
// On peut obtenir les arguments d'entrée avec process.argv. Les deux premiers ne nous intéressent pas car il s'agira de ['node', 'Calcul.js']
const args = process.argv.slice(2);

// On peut récupérer le flag dans le tableau en en extraiyant le premier élément ('-a', '-s', '-d', '-m' )
const flag = args[0];

// On va récupérer les deux nombres à additionner, soustraire, diviser ou multiplier
const nbA = parseFloat(args[1]);
const nbB = parseFloat(args[2]);

// On fait un affichage conditionné par le type d'opération
switch (flag) {
  // Addition
  case "-a":
  case "--add":
    console.log(`${nbA} + ${nbB} = ${nbA + nbB}`);
    break;

  // Soustraction
  case "-s":
  case "--substract":
    console.log(`${nbA} - ${nbB} = ${nbA - nbB}`);
    break;

  // Multiplication
  case "-m":
  case "--multiply":
    console.log(`${nbA} * ${nbB} = ${nbA * nbB}`);
    break;

  // Division
  case "-d":
  case "--divide":
    // On vérifie qu'il ne s'agit pas d'une division par zéro
    if (nbB === 0) {
      console.error("Erreur : Division par zéro !");
      break;
      // Si c'est bon...
    } else {
      console.log(`${nbA} / ${nbB} = ${nbA / nbB}`);
      break;
    }
}
```

On fait un Dockerfile permettant de lancer le script en tant qu'entrypoint de sorte à ne pas pouvoir faire autre chose avec le conteneur:

```dockerfile
FROM node:slim

WORKDIR /scripts

COPY ./Calcul.js /scripts/Calcul.js

ENTRYPOINT [ "node", "Calcul.js" ]
```

On fait un build de notre image : 

```bash
docker build -t exercice-06 .
```

On lance un conteneur en envoyant les bons paramètres : 

```bash
docker run exercice-06 --substract 10 7

# 10 - 7 = 3
```