// Adapter patter: Faire en sorte de faire fonctionner deux interfaces différentes ensemble

using Demo.Cesi.Adapter.Classes;
using Demo.Cesi.Adapter.Interfaces;

List<IOldPrinter> printers = new List<IOldPrinter>();
_printers.Add(new CanonOldPrinter());
_printers.Add(new FrenchPrinterAdapter(new VieilleImprimante()));

for (var printer in printers) printer.Print("0123456789Hello world");