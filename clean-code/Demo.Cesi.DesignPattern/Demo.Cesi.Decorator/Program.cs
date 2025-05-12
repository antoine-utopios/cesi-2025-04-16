// Decorator pattern : Faire en sorte de pouvoir provoquer des instructions en plus de celle prévues de base par la classe que l'on va décorer

using Demo.Cesi.Decorator.Classes;
using Demo.Cesi.Decorator.Interfaces;
using Demo.Cesi.Decorator.Extensions;

IConsolePrinter basePrinter = new ConsolePrinter();
basePrinter.PrintToConsole("Hello, World!");

IConsolePrinter loggedPrinter = new ConsoleLoggerDecorator(new ConsolePrinter());
loggedPrinter.PrintToConsole("Hello, World!");

// Une autre solution pour étendre les fonctionnalités d'une classe tout en respectant l'Open / Close Principle (second principe SOLID) est d'utiliser des extensions de méthodes

basePrinter.SendEmail("Hello, World!");