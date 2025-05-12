using Demo.Cesi.Strategy.Interfaces;

// Stategy pattern : Capacité de pouvoir faire se dérouler plusieurs algorithme différents via leur caractère interchangeables. On passe généralement par des interfaces pour cela.

void FaireVoler(IFlying flyingItem, double distance)
{
    flyingItem.Fly(distance);
}