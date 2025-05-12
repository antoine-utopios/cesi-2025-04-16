
using Demo.Cesi.Builder.Classes;

// Builder pattern : Permet l'instanciation de de classes avec leurs paramètres en choisissant de set ou pas chaque paramètre lors de l'instanciation sans utiliser une infinité de constructeurs et le poylmorphisme

AppUser appUser = new AppUser();
AppUser appUserJohnDoe = new AppUser.Builder()
    .SetFirstName("John")
    .SetLastName("Doe")
    .Build();

AppUser appUdserEmailAndLastNameSet = new AppUser.Builder()
    .SetEmail("example@host.com")
    .SetLastName("Doe")
    .Build();