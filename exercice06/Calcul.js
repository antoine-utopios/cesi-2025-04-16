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
