# Exercice 6 : Conteneur utilitaire 

Réaliser, via Docker, le déploiement d'un conteneur utilitaire permettant le calcul de nombres en Javascript

Ce conteneur devra permettre, via ENTRYPOINT et la présence de plusieurs paramètres d'entrée, de réaliser les 4 opérations de base (Addition, Soustraction, Division, Multiplication) sous la forme de : 

```bash
Calculator.js 4 5 --addition

# 4 + 5 = 9
```

Pour cela, vous pourrez soit utiliser 4 scripts (addition.js, soustraction.js, ...) ou un seul script en utilisant un flag permettant la sélection de l'opération à effectuer

## Correction
