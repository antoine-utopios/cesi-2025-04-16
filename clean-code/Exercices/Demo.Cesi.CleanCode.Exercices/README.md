# Exercices sur les principes SOLID

## Exercices sur le SRP (Single Responsibility Principle)

### Exercice 1 : Identifier la violation du SRP

Lis le code suivant. Quelles responsabilités sont mélangées dans cette classe ? Refactore en plusieurs classes selon SRP.

```csharp
public class Invoice
{
    public int Id { get; set; }
    public double Amount { get; set; }

    public void SaveToFile()
    {
        // Code pour sauvegarder dans un fichier
    }

    public double CalculateTotalWithTaxes()
    {
        return Amount * 1.2;
    }

    public void PrintInvoice()
    {
        // Code pour imprimer l'Invoice
    }
}
```

Séparer les responsabilités de :
* Calcul
* Persistance (sauvegarde)
* Affichage

### Exercice 2 : Appliquer le SRP

Crée une application console avec les classes suivantes :

* `User`: représente un utilisateur avec nom, email.
* `UserRepository`: gère la persistance dans une base de données fictive (ex. liste en mémoire).
* `UserValidator`: valide que le nom et l'email ne sont pas vides.
* `UserService`: ajoute un utilisateur en validant d'abord, puis en sauvegardant.

Tu dois appliquer le SRP dans chaque classe.

### Exercice 3 : Violation volontaire + correction

Crée une classe `ReportGenerator` qui :
* Génére un rapport
* Envoie un email avec le rapport
* Sauvegarde le rapport dans un fichier


Montre que c’est une violation du SRP.

Refactore-la pour avoir une classe par responsabilité :

* `ReportBuilder`
* `EmailSender`
* `FileSaver`

### Exercice 4 : "OrderManager"

Implémente une application console C# qui permet de :

* Créer une commande à partir d’une liste de produits.
* Calculer le total avec une éventuelle réduction.
* Sauvegarder la commande.
* Envoyer une notification à l'utilisateur.

Tu vas commencer avec une classe monolithique (OrderManager) qui fait tout.

* Implémente cette classe (tu peux t’inspirer de l’exemple ci-dessous).
* Identifie les responsabilités mélangées.
* Refactore en plusieurs classes respectant le SRP.

**Exemple initial de OrderManager (monolithe à refactorer)**
```csharp
public class OrderManager
{
    private List<string> _products = new List<string>();
    private double _total = 0;

    public void AddProduct(string name, double price)
    {
        _products.Add(name + ":" + price);
        _total += price;
    }

    public void ApplyDiscount(double percentage)
    {
        _total = _total - (_total * (percentage / 100));
    }

    public void SaveOrder()
    {
        File.WriteAllText("order.txt", string.Join(",", _products) + "\nTotal: " + _total);
    }

    public void NotifyUser(string email)
    {
        Console.WriteLine("Email envoyé à " + email + " pour la commande de " + _total + "€");
    }

    public void PrintSummary()
    {
        Console.WriteLine("Produits:");
        foreach (var product in _products)
            Console.WriteLine("- " + product);
        Console.WriteLine("Total: " + _total + "€");
    }
}
```

Crée des classes comme :

* `Product` (modèle)
* `Order` (modèle)
* `OrderCalculator` (calculs, réductions)
* `OrderRepository` (sauvegarde)
* `Notifier` (notification utilisateur)
* `OrderService` (coordination)

Utilise l'injection de dépendances manuelle dans `Program.cs`.

**Bonus pour aller plus loin:**

* Ajoute une stratégie de réduction (ex: pour les clients VIP).
* Remplace la sauvegarde fichier par une sauvegarde JSON.
* Simule l’envoi d’un email avec une classe FakeEmailSender.

### Exercice 5 : Gestion d’un système de comptes bancaires

Tu vas développer un système qui permet de :

* Créer des comptes bancaires
* Effectuer des dépôts et des retraits
* Générer un relevé de compte
* Journaliser les transactions
* Envoyer des notifications si le compte passe sous un seuil critique

```csharp
using System;
using System.Collections.Generic;
using System.IO;

public class BankAccountManager
{
    private string _accountNumber;
    private double _balance;
    private List<string> _transactionHistory;

    public BankAccountManager(string accountNumber)
    {
        _accountNumber = accountNumber;
        _balance = 0;
        _transactionHistory = new List<string>();
    }

    public void Deposit(double amount)
    {
        _balance += amount;
        string entry = $"{DateTime.Now}: Dépôt de {amount}€";
        _transactionHistory.Add(entry);
        LogTransaction(entry);
        Console.WriteLine("Dépôt effectué.");
    }

    public void Withdraw(double amount)
    {
        if (amount > _balance)
        {
            Console.WriteLine("Fonds insuffisants.");
            return;
        }

        _balance -= amount;
        string entry = $"{DateTime.Now}: Retrait de {amount}€";
        _transactionHistory.Add(entry);
        LogTransaction(entry);
        Console.WriteLine("Retrait effectué.");

        if (_balance < 100)
        {
            NotifyLowBalance();
        }
    }

    public void PrintStatement()
    {
        Console.WriteLine($"Relevé du compte {_accountNumber}");
        foreach (var t in _transactionHistory)
        {
            Console.WriteLine(t);
        }
        Console.WriteLine($"Solde actuel : {_balance}€");
    }

    private void LogTransaction(string message)
    {
        File.AppendAllText("transactions.log", message + Environment.NewLine);
    }

    private void NotifyLowBalance()
    {
        Console.WriteLine("⚠️  Alerte : votre solde est inférieur à 100€ !");
    }
}
```

Cette classe viole le SRP car elle a plusieurs responsabilités entremêlées.

Identifie les responsabilités distinctes, par exemple :

* Logique métier (compte, dépôt, retrait)
* Notification
* Persistance ou journalisation
* Génération de relevé

Divise le code en classes spécialisées comme :

| Classe               | Responsabilité unique                  |
| -------------------- | -------------------------------------- |
| `BankAccount`        | Gestion du solde (dépôt/retrait)       |
| `TransactionLogger`  | Journalisation dans un fichier         |
| `Notifier`           | Envoi d’alerte si solde < seuil        |
| `StatementGenerator` | Génération du relevé de compte         |
| `BankService`        | Orchestration entre toutes les classes |

**Bonus optionnels:**

* Ajoute une gestion de plusieurs comptes
* Implémente un export PDF ou JSON du relevé
* Envoie une alerte par email (simulation)

## Exercices sur le OCP (Open/Closed Principle)

### Exercice 1 : Mauvaise implémentation (violant OCP)

Crée une classe InvoicePrinter qui imprime différents types de factures selon un type passé en paramètre.

```csharp
public class InvoicePrinter
{
    public void PrintInvoice(string type)
    {
        if (type == "PDF")
        {
            Console.WriteLine("Printing PDF Invoice...");
        }
        else if (type == "Excel")
        {
            Console.WriteLine("Printing Excel Invoice...");
        }
        else
        {
            Console.WriteLine("Unknown invoice type");
        }
    }
}
```

Refactorer ce code pour qu’il respecte le principe Open/Closed, en utilisant une interface et des classes spécifiques à chaque type de facture.

### Exercice 2 : OCP avec une opération de calcul

Tu dois créer un système qui effectue différentes opérations mathématiques (addition, soustraction, etc.).

On te donne une interface :

```csharp
public interface IOperation
{
    double Calculate(double a, double b);
}
```

Implémente deux classes :

* `AdditionOperation`
* `SubtractionOperation`

Crée une classe `Calculator` qui prend une liste d’opérations à exécuter.

Ajoute une nouvelle opération (`MultiplicationOperation`) sans modifier la classe `Calculator`.

A l'exécution, on est censé avoir une sortie console telle que: 

```text
Addition : 3 + 2 = 5  
Soustraction : 5 - 1 = 4  
Multiplication : 3 * 4 = 12
```

### Exercice 3 : OCP avec une stratégie de notification (avec injection)

Tu veux créer un système de notification (par e-mail, SMS, etc.).

On te donne une interface :
```csharp
public interface INotifier
{
    void Notify(string message);
}
```

Implémente deux classes concrètes :

* `EmailNotifier`
* `SmsNotifier`

Crée une classe `NotificationService` qui prend une collection de `INotifier` via injection (utilise `Microsoft.Extensions.DependencyInjection`).

Enregistre les notificateurs et déclenche les notifications.

Ajoute un nouveau canal (`SlackNotifier`) sans toucher aux autres classes existantes.

Objectif de sortie console: 

```text
[Email] Notification: Hello World  
[SMS] Notification: Hello World  
[Slack] Notification: Hello World
```

### Exercice 4 : Système de tarification dynamique pour e-commerce

Tu construis un système pour appliquer des règles de tarification différentes selon le type de produit ou le contexte (soldes, clients premium, etc.).

On te donne une interface :

```csharp
public interface IPricingStrategy
{
    decimal CalculatePrice(Product product);
}
Et une classe Product de base :

csharp
Copier
Modifier
public class Product
{
    public string Name { get; set; }
    public decimal BasePrice { get; set; }
    public string Category { get; set; } // e.g. "Books", "Electronics"
}
```

Implémente deux stratégies :

* `DefaultPricingStrategy` (retourne BasePrice)
* `BookDiscountStrategy` (10% de réduction si Category == "Books")

Crée une classe `PricingService` qui accepte une collection de `IPricingStrategy` et applique la première applicable (chaque stratégie peut avoir une méthode bool `IsApplicable(Product product)`).

Ajoute une nouvelle règle (`PremiumCustomerStrategy`) sans toucher aux autres classes.

Objectif de sortie console: 

```text
Product: "C# Book" | Price: 18.00 (Base: 20.00)
Product: "Smartphone" | Price: 500.00
Product: "C# Book" for Premium Client | Price: 16.00
```

### Exercice 5 : Analyse de fichiers avec analyseurs modulaires

Tu crées une application de diagnostic de fichiers. Chaque type d’analyse (taille, extension, encodage, etc.) est une stratégie d’analyse.

Voici l’interface de base :

```csharp
public interface IFileAnalyzer
{
    void Analyze(string filePath, AnalysisReport report);
}
```
Et une classe pour stocker les résultats :

```csharp
public class AnalysisReport
{
    public List<string> Results { get; } = new List<string>();

    public void AddResult(string result) => Results.Add(result);
}
```

Implémente deux analyseurs :

* `FileSizeAnalyzer` : indique la taille en Ko
* `FileExtensionAnalyzer` : indique l’extension du fichier

Crée une classe `FileAnalysisService` qui prend une liste de `IFileAnalyzer` et exécute chaque analyseur.

Ajoute un nouvel analyseur (`TextEncodingAnalyzer`) sans toucher au service ou aux anciens analyseurs.

Exécution attendue :

```text
Analysing: readme.txt
- Size: 12.4 KB
- Extension: .txt
- Encoding: UTF-8
```

## Exercices sur le LSP (Liskov Substitution Principle)

### Exercice 1 : Violation du LSP

Identifier et corriger une violation du LSP.

Code de départ :
```csharp
public class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Flying");
    }
}

public class Ostrich : Bird
{
    public override void Fly()
    {
        throw new NotImplementedException("Ostriches can't fly!");
    }
}
```

Pourquoi ce code viole-t-il le LSP ?

Propose une refactorisation pour respecter le LSP.

### Exercice 2 : LSP et polymorphisme

Tester la substitution dans une méthode générique.

Code :
```csharp
public class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }

    public int GetArea() => Width * Height;
}

public class Square : Rectangle
{
    public override int Width 
    { 
        set 
        {
            base.Width = value;
            base.Height = value;
        } 
    }

    public override int Height 
    { 
        set 
        {
            base.Width = value;
            base.Height = value;
        } 
    }
}

public static void PrintArea(Rectangle r)
{
    r.Width = 5;
    r.Height = 10;
    Console.WriteLine("Expected area: 50, Actual: " + r.GetArea());
}
```

Quelle est la sortie si on passe un `Square` à `PrintArea()` ?

Pourquoi cela viole-t-il le LSP ?

Propose une solution pour respecter le LSP (indice : repenser la relation entre `Square` et `Rectangle`).

### Exercice 3 : Paiements (version à refactoriser pour respecter le LSP)

Tu travailles sur un système de paiement avec des classes pour chaque type de méthode de paiement. Cependant, le code ci-dessous viole le LSP.

Code de départ (à refactoriser) :
```csharp
public abstract class PaymentMethod
{
    public abstract void ProcessPayment(decimal amount);
}

public class CreditCardPayment : PaymentMethod
{
    public override void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing credit card payment of {amount}€");
    }
}

public class PayPalPayment : PaymentMethod
{
    public override void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing PayPal payment of {amount}€");
    }
}

public class BankTransferPayment : PaymentMethod
{
    public override void ProcessPayment(decimal amount)
    {
        if (amount < 100)
        {
            throw new InvalidOperationException("Bank transfers are only available for amounts of 100€ or more.");
        }

        Console.WriteLine($"Processing bank transfer of {amount}€");
    }
}

public class OrderService
{
    public void PayOrder(PaymentMethod method, decimal amount)
    {
        method.ProcessPayment(amount);
    }
}
```

Quelle méthode concrète viole le LSP ?

Pourquoi ce comportement pose-t-il un problème si on traite toutes les méthodes comme des `PaymentMethod` ?

Que se passerait-il si `OrderService` traitait tous les paiements de façon uniforme ?

Corrige le code pour respecter le LSP.

### Exercice 4 : Livraison express : refactoriser pour respecter le LSP

Tu développes un système de livraison. Tu as plusieurs classes représentant des types de livraisons : standard, express, internationale. Le système doit pouvoir utiliser toutes ces livraisons de manière interchangeable… mais ce n’est pas le cas actuellement.

Code à corriger :
```csharp
public class Delivery
{
    public virtual void ShipOrder(string destination)
    {
        Console.WriteLine($"Shipping order to {destination}");
    }
}

public class ExpressDelivery : Delivery
{
    public override void ShipOrder(string destination)
    {
        Console.WriteLine($"Shipping express to {destination} (24h)");
    }
}

public class InternationalDelivery : Delivery
{
    public override void ShipOrder(string destination)
    {
        if (destination.ToLower() == "france")
        {
            throw new InvalidOperationException("Use local shipping for France.");
        }

        Console.WriteLine($"Shipping internationally to {destination}");
    }
}

public class OrderProcessor
{
    public void Process(Delivery delivery, string destination)
    {
        delivery.ShipOrder(destination);
    }
}
```

Pourquoi `InternationalDelivery` viole-t-elle le LSP ?

Quelle est la conséquence d'utiliser cette classe dans `OrderProcessor` ?

Refactorise ce code pour que toutes les livraisons respectent le LSP.

Concevoir une solution où chaque type de livraison peut être utilisée sans générer de comportement spécial ou de restriction arbitraire dans une méthode polymorphe comme `Process`.

### Exercice 5 : Génération de rapports (mauvaise abstraction)

Un outil génère différents types de rapports : PDF, Excel, HTML. Tu veux que tous les rapports puissent être exportés et prévisualisés. Sauf qu’un des types de rapports ne se comporte pas comme les autres...

Code à corriger :
```csharp
public abstract class Report
{
    public abstract void Export(string path);
    public abstract string Preview();
}

public class PdfReport : Report
{
    public override void Export(string path)
    {
        Console.WriteLine($"Exporting PDF to {path}");
    }

    public override string Preview()
    {
        return "PDF preview";
    }
}

public class HtmlReport : Report
{
    public override void Export(string path)
    {
        Console.WriteLine($"Exporting HTML to {path}");
    }

    public override string Preview()
    {
        return "<html><body>Preview</body></html>";
    }
}

public class ExcelReport : Report
{
    public override void Export(string path)
    {
        Console.WriteLine($"Exporting Excel to {path}");
    }

    public override string Preview()
    {
        throw new NotSupportedException("Excel preview not supported.");
    }
}

public class ReportService
{
    public void GeneratePreview(Report report)
    {
        Console.WriteLine(report.Preview());
    }
}
```

Quelle classe viole le LSP ?

Que se passe-t-il si on passe un `ExcelReport` à `GeneratePreview()` ?

Propose une nouvelle architecture pour que toutes les classes de rapport puissent être utilisées sans casser le système.

## Exercices sur le ISP (Interface Segregation Principle)

### Exercice 1 : Refactoriser une interface trop large

On te donne une interface IMachine :

```csharp
public interface IMachine
{
    void Print();
    void Scan();
    void Fax();
}
```

Et deux classes l’implémentent :

```csharp
public class MultiFunctionPrinter : IMachine
{
    public void Print() { Console.WriteLine("Printing..."); }
    public void Scan() { Console.WriteLine("Scanning..."); }
    public void Fax() { Console.WriteLine("Faxing..."); }
}

public class OldPrinter : IMachine
{
    public void Print() { Console.WriteLine("Printing..."); }
    public void Scan() { throw new NotImplementedException(); }
    public void Fax() { throw new NotImplementedException(); }
}
```

Refactorise le code pour respecter le principe ISP, en divisant IMachine en plusieurs interfaces pertinentes. Puis ajuste les classes.

### Exercice 2 : Créer des interfaces spécifiques

Un système de gestion d’employés utilise l’interface suivante :

```csharp
public interface IEmployee
{
    void Work();
    void AttendMeeting();
    void ManageTeam();
}
```

Mais on a deux types d’employés :
* Un développeur
* Un chef de projet

Refactorise l’interface `IEmployee` en plusieurs interfaces spécifiques.

Implémente `Developer` et `ProjectManager` en respectant ISP.

### Exercice 3 : Trouver la violation de ISP

Voici une interface :

```csharp
public interface IAnimal
{
    void Eat();
    void Fly();
}
```

Et les classes :

```csharp
public class Bird : IAnimal
{
    public void Eat() { Console.WriteLine("Bird is eating"); }
    public void Fly() { Console.WriteLine("Bird is flying"); }
}

public class Dog : IAnimal
{
    public void Eat() { Console.WriteLine("Dog is eating"); }
    public void Fly() { throw new NotImplementedException(); }
}
```

Où se situe la violation de ISP ?

Corrige-la en restructurant l’interface et les classes.

### Exercice 4 : Système de notification multi-canaux

Tu dois implémenter un système de notifications.

On t’a donné l’interface suivante, censée gérer toutes les formes de notifications :

```csharp
public interface INotificationService
{
    void SendEmail(string to, string subject, string body);
    void SendSms(string phoneNumber, string message);
    void SendPush(string deviceToken, string message);
}
```

Et tu dois créer des services :
* `EmailNotificationService` : envoie uniquement des e-mails.
* `SmsNotificationService` : envoie uniquement des SMS.
* `PushNotificationService` : envoie uniquement des notifications push.

Avec cette interface, chaque classe est forcée d’implémenter des méthodes qu’elle n’utilisera pas.

Refactorise l’interface `INotificationService` en plusieurs interfaces spécifiques.

Implémente chaque service (`EmailNotificationService`, `SmsNotificationService`, `PushNotificationService`) en ne respectant que ce qu’il utilise vraiment.

**Bonus:** 

Crée une classe `NotificationDispatcher` qui utilise une interface générique de notification pour envoyer le bon type de message dynamiquement.

### Exercice 5 : Gestion d'une application bancaire (comptes utilisateurs)

Tu travailles sur une application bancaire. Une interface a été conçue pour gérer les actions sur les comptes :

```csharp
public interface IBankAccount
{
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
    void RequestLoan(decimal amount);
    void OpenCreditLine(decimal amount);
}
```

On distingue deux types de comptes :

* `SavingsAccount` : peut faire des dépôts et des retraits, mais pas de prêts ni de lignes de crédit.
* `CreditAccount` : ne fait que du crédit (prêts et lignes de crédit), pas de dépôt ni retrait classique.

Le contrat de `IBankAccount` force les classes à implémenter des méthodes inutiles pour leur logique métier.

Refactorise `IBankAccount` pour respecter le principe de ségrégation des interfaces.

Implémente correctement SavingsAccount et `CreditAccount` en fonction de leurs capacités.

**Bonus :** 

Implémente un gestionnaire de comptes (`AccountManager`) qui dépend uniquement de ce dont il a réellement besoin pour fonctionner (ex. : il peut gérer un `IDepositable`, `ICreditable`, etc.).

## Exercices sur le DIP (Dependency Inversion Principle)

### Exercice 1 : Refactorisation simple avec interface

Appliquer le DIP en extrayant une interface.

Tu as ces classes :

```csharp
public class EmailService
{
    public void SendEmail(string message)
    {
        Console.WriteLine($"Email envoyé : {message}");
    }
}

public class OrderProcessor
{
    private EmailService _emailService = new EmailService();

    public void Process()
    {
        // Traitement de la commande...
        _emailService.SendEmail("Commande traitée.");
    }
}
```

Applique le principe DIP pour que `OrderProcessor` ne dépende plus de `EmailService` directement.

Utilise une interface `INotificationService`.

### Exercice 2 : Injection de dépendances

Mettre en œuvre le DIP avec une injection de dépendance via le constructeur.

Tu dois créer un système de journalisation. Voici le scénario :

```csharp
public class FileLogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Fichier : {message}");
    }
}

public class AppManager
{
    private FileLogger _logger = new FileLogger();

    public void Run()
    {
        _logger.Log("Application démarrée");
    }
}
```

Refactore pour que `AppManager` ne dépende que d’une abstraction `ILogger`.

Permets l’injection d’un autre logger plus tard (`ConsoleLogger`, par exemple).

### Exercice 3 : Architecture modulaire avec inversion des dépendances

Créer une architecture simple en 3 couches (UI → Service → Repository) sans dépendance directe entre UI et la base.

Tu veux simuler la récupération d’un utilisateur depuis une source de données.

```csharp
public class UserRepository
{
    public string GetUser()
    {
        return "Jean Dupont";
    }
}

public class UserService
{
    private UserRepository _repository = new UserRepository();

    public string GetUserName()
    {
        return _repository.GetUser();
    }
}

public class UserInterface
{
    private UserService _service = new UserService();

    public void ShowUser()
    {
        Console.WriteLine(_service.GetUserName());
    }
}
```

Crée une interface `IUserRepository`.

Modifie la hiérarchie pour que chaque couche ne connaisse que des abstractions.

Injecte les dépendances via les constructeurs.

### Exercice 4 : Système de paiement modulaire

Créer un système de paiement supportant plusieurs passerelles (Stripe, PayPal...) sans que le module principal ne dépende des implémentations concrètes.

Tu développes une application de e-commerce. La classe `PaymentProcessor` ne doit pas dépendre directement de `StripeService` ou `PaypalService`.

Crée une interface `IPaymentService` avec une méthode void `ProcessPayment(decimal amount)`

**Optionnel:** utilise `Microsoft.Extensions.DependencyInjection` pour gérer l’injection de dépendance.

### Exercice 5 : Application modulaire de monitoring système

Appliquer DIP dans un scénario multi-couches, avec logging, monitoring, et simulation d’environnement extensible.


Tu conçois un service de surveillance d’un serveur. L’application doit :

* Collecter l’état du système via des capteurs (CPU, RAM, réseau)
* Logger les événements
* Alerter si un seuil critique est dépassé

