using Demo.Cesi.Factory.Classes;

// Factory pattern: On masque l'instanciation d'un objet en passant par une méthode provenant d'une classe de type Factory. On va donc devoir créer plusieurs constructeurs via un switch-case

var burgerA = BurgerFactory.CreateHamburger("Classic");
Console.WriteLine(burgerA.GetType().Name);