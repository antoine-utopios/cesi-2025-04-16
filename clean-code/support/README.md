# Clean Code et Optimisation du code

## Introduction

### Qu'est-ce que le Clean Code ? 

Le Clean Code est un code qui est simple à lire, comprendre et maintenir. Il suit des principes de conception et des bonnes pratiques qui permettent de réduire les erreurs, d'améliorer la qualité et de faciliter la collaboration entre les développeurs.

**Exemple en .NET :**
```csharp
// Mauvais exemple : code difficile à lire et à comprendre
int x = 10;
int y = 20;
int z = x + y;
Console.WriteLine(z);

// Bon exemple : code clair et lisible
int firstNumber = 10;
int secondNumber = 20;
int sum = firstNumber + secondNumber;
Console.WriteLine($"The sum is: {sum}");
```

### A quoi ça sert ? 

Le Clean Code permet de réduire la dette technique, d'améliorer la productivité des équipes et de garantir que le logiciel reste évolutif et maintenable sur le long terme.

**Exemple en .NET :**
```csharp
// Mauvais exemple : code non maintenable
void ProcessData(string data) {
  if (data == "TypeA") {
    Console.WriteLine("Processing TypeA data...");
  } else if (data == "TypeB") {
    Console.WriteLine("Processing TypeB data...");
  }
}

// Bon exemple : code extensible et maintenable
interface IDataProcessor {
  void Process(string data);
}

class TypeAProcessor : IDataProcessor {
  public void Process(string data) {
    Console.WriteLine("Processing TypeA data...");
  }
}

class TypeBProcessor : IDataProcessor {
  public void Process(string data) {
    Console.WriteLine("Processing TypeB data...");
  }
}
```

### Les principales erreurs de coding

Les erreurs courantes incluent le code dupliqué, les méthodes trop longues, les classes trop grandes, et les dépendances mal gérées.

**Exemple en .NET :**
```csharp
// Mauvais exemple : duplication de code
void PrintWelcomeMessage() {
  Console.WriteLine("Welcome to the application!");
}

void PrintGoodbyeMessage() {
  Console.WriteLine("Goodbye and thank you for using the application!");
}

// Bon exemple : réutilisation de code
void PrintMessage(string message) {
  Console.WriteLine(message);
}
```

### La Dette technique ?

La dette technique représente le coût futur lié à des choix de conception ou de développement rapides mais sous-optimaux. Elle peut ralentir le développement et augmenter les coûts de maintenance.

**Exemple en .NET :**
```csharp
// Mauvais exemple : dette technique due à un couplage fort
class Database {
  public void Save(string data) {
    Console.WriteLine($"Saving {data} to the database.");
  }
}

class ReportGenerator {
  private Database _database = new Database();

  public void GenerateReport(string data) {
    _database.Save(data);
  }
}

// Bon exemple : réduction de la dette technique avec une abstraction
interface IDataStorage {
  void Save(string data);
}

class Database : IDataStorage {
  public void Save(string data) {
    Console.WriteLine($"Saving {data} to the database.");
  }
}

class ReportGenerator {
  private readonly IDataStorage _dataStorage;

  public ReportGenerator(IDataStorage dataStorage) {
    _dataStorage = dataStorage;
  }

  public void GenerateReport(string data) {
    _dataStorage.Save(data);
  }
}
```

### Les règles du Clean Code 

Les règles incluent : utiliser des noms clairs, éviter les méthodes longues, limiter les dépendances, et respecter les principes SOLID.

**Exemple en .NET :**
```csharp
// Mauvais exemple : noms peu descriptifs
class A {
  public void DoSomething() {
    Console.WriteLine("Doing something...");
  }
}

// Bon exemple : noms clairs et significatifs
class ReportGenerator {
  public void GenerateMonthlyReport() {
    Console.WriteLine("Generating monthly report...");
  }
}
```

### Faire des tests

Les tests permettent de garantir que le code fonctionne comme prévu et qu'il reste fiable lors des modifications.

**Exemple en .NET avec xUnit :**
```csharp
// Exemple de test unitaire
public class Calculator {
  public int Add(int a, int b) {
    return a + b;
  }
}

public class CalculatorTests {
  [Fact]
  public void Add_ShouldReturnSumOfTwoNumbers() {
    var calculator = new Calculator();
    int result = calculator.Add(2, 3);
    Assert.Equal(5, result);
  }
}
```

### Les Code Smells ?

Les Code Smells sont des indicateurs de problèmes dans le code, comme le code dupliqué, les méthodes longues, ou les dépendances mal gérées.

**Exemple en .NET :**
```csharp
// Mauvais exemple : méthode longue
void ProcessOrder() {
  Console.WriteLine("Validating order...");
  // Validation logic
  Console.WriteLine("Processing payment...");
  // Payment logic
  Console.WriteLine("Sending confirmation...");
  // Confirmation logic
}

// Bon exemple : méthode courte et spécifique
void ValidateOrder() {
  Console.WriteLine("Validating order...");
}

void ProcessPayment() {
  Console.WriteLine("Processing payment...");
}

void SendConfirmation() {
  Console.WriteLine("Sending confirmation...");
}
```

## Code Design 

### Une bonne architecture 

Une bonne architecture logicielle est essentielle pour garantir que le code est maintenable, évolutif et facile à comprendre. Elle repose sur des principes solides, comme la séparation des préoccupations, le respect des principes SOLID, et l'utilisation de modèles de conception adaptés.

#### Exemple en .NET : Architecture en couches

L'architecture en couches est un modèle classique qui divise une application en plusieurs couches logiques, chacune ayant une responsabilité spécifique. Les couches typiques incluent la couche de présentation, la couche métier et la couche d'accès aux données.

**Exemple :**
```csharp
// Couche d'accès aux données
public class ProductRepository {
  public Product GetProductById(int id) {
    // Simule l'accès à une base de données
    return new Product { Id = id, Name = "Laptop", Price = 1200 };
  }
}

// Couche métier
public class ProductService {
  private readonly ProductRepository _repository;

  public ProductService(ProductRepository repository) {
    _repository = repository;
  }

  public Product GetProductDetails(int id) {
    var product = _repository.GetProductById(id);
    // Logique métier supplémentaire
    product.Price += 100; // Exemple : ajout de frais
    return product;
  }
}

// Couche de présentation
public class ProductController {
  private readonly ProductService _service;

  public ProductController(ProductService service) {
    _service = service;
  }

  public void DisplayProduct(int id) {
    var product = _service.GetProductDetails(id);
    Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
  }
}

// Utilisation
var repository = new ProductRepository();
var service = new ProductService(repository);
var controller = new ProductController(service);

controller.DisplayProduct(1);
```

#### Exemple en .NET : Architecture basée sur les événements

Une architecture basée sur les événements est utile pour les systèmes distribués ou les applications nécessitant une communication asynchrone. Elle repose sur des événements pour déclencher des actions entre différents composants.

**Exemple :**
```csharp
// Définition d'un événement
public class ProductEvent {
  public string ProductName { get; set; }
  public DateTime EventTime { get; set; }
}

// Gestionnaire d'événements
public class ProductEventHandler {
  public void OnProductCreated(ProductEvent productEvent) {
    Console.WriteLine($"Product created: {productEvent.ProductName} at {productEvent.EventTime}");
  }
}

// Émetteur d'événements
public class ProductService {
  public event Action<ProductEvent> ProductCreated;

  public void CreateProduct(string productName) {
    Console.WriteLine($"Creating product: {productName}");
    ProductCreated?.Invoke(new ProductEvent { ProductName = productName, EventTime = DateTime.Now });
  }
}

// Utilisation
var productService = new ProductService();
var eventHandler = new ProductEventHandler();

productService.ProductCreated += eventHandler.OnProductCreated;
productService.CreateProduct("Smartphone");
```

Ces exemples montrent comment une bonne architecture peut organiser le code pour le rendre plus modulaire, testable et évolutif.

### Le Couplage fort

Le couplage fort se produit lorsque les classes ou les modules dépendent fortement les uns des autres. Cela rend le code difficile à modifier, tester et maintenir, car un changement dans une classe peut avoir un impact sur plusieurs autres.

**Exemple en C# :**
```csharp
// Mauvais exemple : couplage fort entre les classes
class Database {
  public void Save(string data) {
    Console.WriteLine($"Saving {data} to the database.");
  }
}

class ReportGenerator {
  private Database _database = new Database();

  public void GenerateReport(string data) {
    Console.WriteLine("Generating report...");
    _database.Save(data); // Dépendance directe à la classe Database
  }
}
```

Dans cet exemple, `ReportGenerator` est fortement couplé à `Database`. Si la méthode de sauvegarde change ou si une autre base de données doit être utilisée, il faudra modifier la classe `ReportGenerator`.

### Le Couplage faible

Le couplage faible, en revanche, consiste à réduire les dépendances entre les classes ou les modules en utilisant des abstractions. Cela rend le code plus flexible, testable et maintenable.

**Exemple en C# :**
```csharp
// Bon exemple : couplage faible grâce à une interface
interface IDataStorage {
  void Save(string data);
}

class Database : IDataStorage {
  public void Save(string data) {
    Console.WriteLine($"Saving {data} to the database.");
  }
}

class ReportGenerator {
  private readonly IDataStorage _dataStorage;

  public ReportGenerator(IDataStorage dataStorage) {
    _dataStorage = dataStorage;
  }

  public void GenerateReport(string data) {
    Console.WriteLine("Generating report...");
    _dataStorage.Save(data); // Dépendance à une abstraction
  }
}

// Utilisation
IDataStorage database = new Database();
ReportGenerator reportGenerator = new ReportGenerator(database);
reportGenerator.GenerateReport("Report Data");
```

Dans cet exemple, `ReportGenerator` dépend de l'interface `IDataStorage` au lieu de la classe concrète `Database`. Cela permet de remplacer facilement `Database` par une autre implémentation, comme un stockage en mémoire ou un fichier, sans modifier la classe `ReportGenerator`.

### La Cohésion

La cohésion mesure à quel point les éléments d'une classe ou d'un module travaillent ensemble pour accomplir une tâche unique. Une forte cohésion signifie que les responsabilités d'une classe ou d'un module sont bien définies et étroitement liées, ce qui rend le code plus facile à comprendre, maintenir et tester.

**Exemple en C# :**
```csharp
// Mauvais exemple : faible cohésion, la classe gère des responsabilités non liées
class Utility {
  public void CalculateSalary() {
    Console.WriteLine("Calculating salary...");
  }

  public void SendEmail() {
    Console.WriteLine("Sending email...");
  }

  public void GenerateReport() {
    Console.WriteLine("Generating report...");
  }
}

// Bon exemple : forte cohésion, chaque classe a une responsabilité claire
class SalaryCalculator {
  public void CalculateSalary() {
    Console.WriteLine("Calculating salary...");
  }
}

class EmailSender {
  public void SendEmail() {
    Console.WriteLine("Sending email...");
  }
}

class ReportGenerator {
  public void GenerateReport() {
    Console.WriteLine("Generating report...");
  }
}
```

### Les Changements locaux

Les changements locaux consistent à limiter l'impact des modifications dans le code à une seule classe ou module. Cela réduit le risque d'introduire des bugs et facilite la maintenance.

**Exemple en C# :**
```csharp
// Mauvais exemple : un changement dans une classe nécessite des modifications dans plusieurs endroits
class Database {
  public void Save(string data) {
    Console.WriteLine($"Saving {data} to the database.");
  }
}

class ReportGenerator {
  private Database _database = new Database();

  public void GenerateReport(string data) {
    Console.WriteLine("Generating report...");
    _database.Save(data); // Dépendance directe
  }
}

// Bon exemple : utilisation d'une abstraction pour limiter les changements
interface IDataStorage {
  void Save(string data);
}

class Database : IDataStorage {
  public void Save(string data) {
    Console.WriteLine($"Saving {data} to the database.");
  }
}

class ReportGenerator {
  private readonly IDataStorage _dataStorage;

  public ReportGenerator(IDataStorage dataStorage) {
    _dataStorage = dataStorage;
  }

  public void GenerateReport(string data) {
    Console.WriteLine("Generating report...");
    _dataStorage.Save(data);
  }
}
```

### Les règles de Nommage

Les noms dans le code doivent être clairs, descriptifs et refléter leur intention. Un bon nommage améliore la lisibilité et réduit les ambiguïtés.

**Exemple en C# :**
```csharp
// Mauvais exemple : noms peu descriptifs
class A {
  public void DoSomething() {
    Console.WriteLine("Doing something...");
  }
}

// Bon exemple : noms clairs et significatifs
class ReportGenerator {
  public void GenerateMonthlyReport() {
    Console.WriteLine("Generating monthly report...");
  }
}
```

### L'Héritage

L'héritage permet de réutiliser le code en définissant une classe de base et en créant des classes dérivées qui héritent de ses propriétés et méthodes. Cependant, il doit être utilisé avec précaution pour éviter un couplage fort.

**Exemple en C# :**
```csharp
// Mauvais exemple : utilisation excessive de l'héritage
class Animal {
  public void Eat() {
    Console.WriteLine("Eating...");
  }
}

class Dog : Animal {
  public void Bark() {
    Console.WriteLine("Barking...");
  }
}

class RobotDog : Dog {
  public void Recharge() {
    Console.WriteLine("Recharging...");
  }
}

// Bon exemple : utilisation de la composition au lieu de l'héritage excessif
class Animal {
  public void Eat() {
    Console.WriteLine("Eating...");
  }
}

class Dog {
  private Animal _animal = new Animal();

  public void Eat() {
    _animal.Eat();
  }

  public void Bark() {
    Console.WriteLine("Barking...");
  }
}

class RobotDog {
  private Dog _dog = new Dog();

  public void Recharge() {
    Console.WriteLine("Recharging...");
  }

  public void Bark() {
    _dog.Bark();
  }
}
```

### La Composition

La composition est une technique de conception où une classe est composée d'autres objets pour réutiliser leur comportement. Cela favorise la flexibilité et permet d'éviter les problèmes liés à l'héritage, comme le couplage fort.

**Exemple en C# :**
```csharp
// Exemple de composition
class Engine {
  public void Start() {
    Console.WriteLine("Engine started.");
  }
}

class Car {
  private Engine _engine;

  public Car(Engine engine) {
    _engine = engine;
  }

  public void StartCar() {
    Console.WriteLine("Starting the car...");
    _engine.Start();
  }
}

// Utilisation
Engine engine = new Engine();
Car car = new Car(engine);
car.StartCar();
```

Dans cet exemple, la classe `Car` utilise un objet `Engine` pour démarrer la voiture. Cela permet de remplacer ou de modifier le comportement du moteur sans modifier la classe `Car`.

### L'Agrégation

L'agrégation est une forme particulière de composition où une classe contient une référence à un autre objet, mais cet objet peut exister indépendamment de la classe qui le contient. Cela reflète une relation "a un" (has-a) entre les objets.

**Exemple en C# :**
```csharp
// Exemple d'agrégation
class Student {
  public string Name { get; set; }

  public Student(string name) {
    Name = name;
  }
}

class Classroom {
  public List<Student> Students { get; set; } = new List<Student>();

  public void AddStudent(Student student) {
    Students.Add(student);
  }

  public void ListStudents() {
    foreach (var student in Students) {
      Console.WriteLine(student.Name);
    }
  }
}

// Utilisation
Student student1 = new Student("Alice");
Student student2 = new Student("Bob");

Classroom classroom = new Classroom();
classroom.AddStudent(student1);
classroom.AddStudent(student2);

classroom.ListStudents();
```

Dans cet exemple, les objets `Student` existent indépendamment de l'objet `Classroom`. La classe `Classroom` agrège plusieurs étudiants, mais la suppression d'une salle de classe n'entraîne pas la suppression des étudiants.

### Les ValueObjects

Un Value Object (ou objet valeur) est un concept clé dans la conception orientée domaine (DDD). Contrairement aux entités, les Value Objects n'ont pas d'identité propre. Ils sont définis uniquement par leurs attributs et sont immuables. Cela signifie que toute modification d'un Value Object entraîne la création d'un nouvel objet.

Les Value Objects sont utiles pour représenter des concepts du domaine qui ne nécessitent pas d'identité unique, comme une adresse, une monnaie ou une plage de dates.

**Exemple en C# :**

```csharp
// Exemple de Value Object : Adresse
public class Address
{
  public string Street { get; }
  public string City { get; }
  public string PostalCode { get; }

  public Address(string street, string city, string postalCode)
  {
    Street = street;
    City = city;
    PostalCode = postalCode;
  }

  // Méthode pour comparer deux Value Objects
  public override bool Equals(object obj)
  {
    if (obj is Address other)
    {
      return Street == other.Street &&
           City == other.City &&
           PostalCode == other.PostalCode;
    }
    return false;
  }

  public override int GetHashCode()
  {
    return HashCode.Combine(Street, City, PostalCode);
  }
}
```

Dans cet exemple, `Address` est un Value Object. Deux adresses avec les mêmes valeurs pour `Street`, `City` et `PostalCode` sont considérées comme égales.

**Utilisation :**

```csharp
var address1 = new Address("123 Main St", "Paris", "75001");
var address2 = new Address("123 Main St", "Paris", "75001");

Console.WriteLine(address1.Equals(address2)); // True
```

Les Value Objects sont également immuables. Toute modification nécessite la création d'un nouvel objet.

**Exemple d'immuabilité :**

```csharp
// Création d'une nouvelle adresse basée sur une adresse existante
var originalAddress = new Address("123 Main St", "Paris", "75001");
var updatedAddress = new Address(originalAddress.Street, "Lyon", originalAddress.PostalCode);

Console.WriteLine(originalAddress.City); // Paris
Console.WriteLine(updatedAddress.City);  // Lyon
```

L'utilisation de Value Objects améliore la lisibilité, réduit les erreurs et favorise une conception orientée domaine plus robuste.

## Principes SOLID

### Single Responsibility Principle (SRP)
Une classe doit avoir une seule responsabilité, c'est-à-dire une seule raison de changer. Cela permet de rendre le code plus lisible, maintenable et testable.

**Exemple en Java :**
```java
// Mauvais exemple : une classe qui gère à la fois les données utilisateur et leur affichage
class User {
  public void saveToDatabase() {
    // Sauvegarde dans la base de données
  }

  public void displayUserInfo() {
    // Affiche les informations utilisateur
  }
}

// Bon exemple : séparation des responsabilités
class User {
  private String name;

  public String getName() {
    return name;
  }
}

class UserRepository {
  public void save(User user) {
    // Sauvegarde dans la base de données
  }
}

class UserView {
  public void display(User user) {
    // Affiche les informations utilisateur
  }
}
```

### Open/Closed Principle (OCP)
Les entités logicielles (classes, modules, fonctions, etc.) doivent être ouvertes à l'extension mais fermées à la modification. Cela signifie que vous pouvez ajouter de nouvelles fonctionnalités sans modifier le code existant.

**Exemple en Java :**
```java
// Mauvais exemple : modification directe de la classe pour ajouter un nouveau type de forme
class Shape {
  public double calculateArea(String shapeType) {
    if (shapeType.equals("Circle")) {
      // Calcul de l'aire d'un cercle
    } else if (shapeType.equals("Rectangle")) {
      // Calcul de l'aire d'un rectangle
    }
    return 0;
  }
}

// Bon exemple : utilisation de l'héritage pour étendre les fonctionnalités
abstract class Shape {
  public abstract double calculateArea();
}

class Circle extends Shape {
  private double radius;

  public Circle(double radius) {
    this.radius = radius;
  }

  @Override
  public double calculateArea() {
    return Math.PI * radius * radius;
  }
}

class Rectangle extends Shape {
  private double width, height;

  public Rectangle(double width, double height) {
    this.width = width;
    this.height = height;
  }

  @Override
  public double calculateArea() {
    return width * height;
  }
}
```

### Liskov Substitution Principle (LSP)
Les objets d'une classe dérivée doivent pouvoir remplacer les objets de la classe de base sans altérer le comportement attendu du programme.

**Exemple en Java :**
```java
// Mauvais exemple : une classe dérivée qui viole le comportement attendu
class Bird {
  public void fly() {
    System.out.println("Je vole !");
  }
}

class Penguin extends Bird {
  @Override
  public void fly() {
    throw new UnsupportedOperationException("Les pingouins ne volent pas !");
  }
}

// Bon exemple : refactorisation pour respecter LSP
abstract class Bird {
  public abstract void move();
}

class FlyingBird extends Bird {
  @Override
  public void move() {
    System.out.println("Je vole !");
  }
}

class Penguin extends Bird {
  @Override
  public void move() {
    System.out.println("Je nage !");
  }
}
```

### Interface Segregation Principle (ISP)
Les clients ne doivent pas être forcés de dépendre d'interfaces qu'ils n'utilisent pas. Il est préférable de diviser les interfaces en plusieurs interfaces spécifiques.

**Exemple en Java :**
```java
// Mauvais exemple : une interface trop large
interface Worker {
  void work();
  void eat();
}

class Robot implements Worker {
  @Override
  public void work() {
    System.out.println("Je travaille !");
  }

  @Override
  public void eat() {
    throw new UnsupportedOperationException("Les robots ne mangent pas !");
  }
}

// Bon exemple : interfaces spécifiques
interface Workable {
  void work();
}

interface Eatable {
  void eat();
}

class Human implements Workable, Eatable {
  @Override
  public void work() {
    System.out.println("Je travaille !");
  }

  @Override
  public void eat() {
    System.out.println("Je mange !");
  }
}

class Robot implements Workable {
  @Override
  public void work() {
    System.out.println("Je travaille !");
  }
}
```

### Dependency Inversion Principle (DIP)
Les modules de haut niveau ne doivent pas dépendre des modules de bas niveau. Les deux doivent dépendre d'abstractions. Les abstractions ne doivent pas dépendre des détails, mais les détails doivent dépendre des abstractions.

**Exemple en Java :**
```java
// Mauvais exemple : dépendance directe à une classe concrète
class Keyboard {
}

class Computer {
  private Keyboard keyboard;

  public Computer() {
    this.keyboard = new Keyboard();
  }
}

// Bon exemple : utilisation d'une abstraction
interface InputDevice {
}

class Keyboard implements InputDevice {
}

class Computer {
  private InputDevice inputDevice;

  public Computer(InputDevice inputDevice) {
    this.inputDevice = inputDevice;
  }
}
```

## Les Code Smells

### Duplicated Code
Le code dupliqué se produit lorsque des blocs de code identiques ou très similaires apparaissent à plusieurs endroits dans le programme. Cela rend le code difficile à maintenir, car une modification doit être répercutée partout où le code est dupliqué.

**Exemple en C# :**
```csharp
// Mauvais exemple : duplication de code pour calculer l'aire de différentes formes
class AreaCalculator {
  public double CalculateCircleArea(double radius) {
    return Math.PI * radius * radius;
  }

  public double CalculateRectangleArea(double width, double height) {
    return width * height;
  }
}

// Bon exemple : refactorisation pour éviter la duplication
abstract class Shape {
  public abstract double CalculateArea();
}

class Circle : Shape {
  public double Radius { get; set; }

  public override double CalculateArea() {
    return Math.PI * Radius * Radius;
  }
}

class Rectangle : Shape {
  public double Width { get; set; }
  public double Height { get; set; }

  public override double CalculateArea() {
    return Width * Height;
  }
}
```

### Long Method
Une méthode longue est difficile à lire, comprendre et maintenir. Elle peut souvent être divisée en plusieurs méthodes plus courtes et spécifiques.

**Exemple en C# :**
```csharp
// Mauvais exemple : une méthode longue avec plusieurs responsabilités
class ReportGenerator {
  public void GenerateReport() {
    Console.WriteLine("Fetching data...");
    // Code pour récupérer les données

    Console.WriteLine("Processing data...");
    // Code pour traiter les données

    Console.WriteLine("Generating report...");
    // Code pour générer le rapport
  }
}

// Bon exemple : division en méthodes plus courtes
class ReportGenerator {
  public void GenerateReport() {
    FetchData();
    ProcessData();
    Generate();
  }

  private void FetchData() {
    Console.WriteLine("Fetching data...");
    // Code pour récupérer les données
  }

  private void ProcessData() {
    Console.WriteLine("Processing data...");
    // Code pour traiter les données
  }

  private void Generate() {
    Console.WriteLine("Generating report...");
    // Code pour générer le rapport
  }
}
```

### Large Class
Une classe trop grande a trop de responsabilités, ce qui viole le principe de responsabilité unique. Elle doit être divisée en plusieurs classes plus petites et spécifiques.

**Exemple en C# :**
```csharp
// Mauvais exemple : une classe qui gère plusieurs responsabilités
class UserManager {
  public void CreateUser() {
    // Code pour créer un utilisateur
  }

  public void SendEmail() {
    // Code pour envoyer un email
  }

  public void LogActivity() {
    // Code pour enregistrer une activité
  }
}

// Bon exemple : séparation des responsabilités
class UserCreator {
  public void CreateUser() {
    // Code pour créer un utilisateur
  }
}

class EmailSender {
  public void SendEmail() {
    // Code pour envoyer un email
  }
}

class ActivityLogger {
  public void LogActivity() {
    // Code pour enregistrer une activité
  }
}
```

### Feature Envy
Un code qui accède fréquemment aux données d'une autre classe au lieu d'utiliser ses propres données. Cela indique que la logique devrait être déplacée dans la classe appropriée.

**Exemple en C# :**
```csharp
// Mauvais exemple : une classe qui dépend trop des données d'une autre classe
class InvoicePrinter {
  public void PrintInvoice(Invoice invoice) {
    Console.WriteLine($"Invoice for {invoice.CustomerName}: {invoice.Amount}");
  }
}

class Invoice {
  public string CustomerName { get; set; }
  public double Amount { get; set; }
}

// Bon exemple : déplacer la logique dans la classe appropriée
class Invoice {
  public string CustomerName { get; set; }
  public double Amount { get; set; }

  public string GetInvoiceDetails() {
    return $"Invoice for {CustomerName}: {Amount}";
  }
}

class InvoicePrinter {
  public void PrintInvoice(Invoice invoice) {
    Console.WriteLine(invoice.GetInvoiceDetails());
  }
}
```

### Primitive Obsession
L'utilisation excessive de types primitifs au lieu de créer des types spécifiques pour représenter des concepts du domaine.

**Exemple en C# :**
```csharp
// Mauvais exemple : utilisation de types primitifs pour représenter des concepts
class Order {
  public string ProductCode { get; set; }
  public string CustomerId { get; set; }
}

// Bon exemple : création de types spécifiques pour représenter des concepts
class ProductCode {
  public string Value { get; }

  public ProductCode(string value) {
    Value = value;
  }
}

class CustomerId {
  public string Value { get; }

  public CustomerId(string value) {
    Value = value;
  }
}

class Order {
  public ProductCode ProductCode { get; set; }
  public CustomerId CustomerId { get; set; }
}
```

### Switch Statements
Les instructions `switch` sont souvent un signe de violation du principe ouvert/fermé. Elles peuvent être remplacées par le polymorphisme.

**Exemple en C# :**
```csharp
// Mauvais exemple : utilisation de switch pour gérer différents types
class Shape {
  public string Type { get; set; }
}

class AreaCalculator {
  public double CalculateArea(Shape shape) {
    switch (shape.Type) {
      case "Circle":
        // Calcul de l'aire d'un cercle
        break;
      case "Rectangle":
        // Calcul de l'aire d'un rectangle
        break;
    }
    return 0;
  }
}

// Bon exemple : utilisation du polymorphisme
abstract class Shape {
  public abstract double CalculateArea();
}

class Circle : Shape {
  public double Radius { get; set; }

  public override double CalculateArea() {
    return Math.PI * Radius * Radius;
  }
}

class Rectangle : Shape {
  public double Width { get; set; }
  public double Height { get; set; }

  public override double CalculateArea() {
    return Width * Height;
  }
}
```

### Speculative Generality
L'ajout de fonctionnalités ou de généralisations inutiles qui ne sont pas encore nécessaires. Cela complique le code sans apporter de valeur immédiate.

**Exemple en C# :**
```csharp
// Mauvais exemple : ajout de fonctionnalités inutiles
class DataProcessor<T> where T : class {
  public void ProcessData(T data) {
    // Code pour traiter les données
  }
}

// Bon exemple : garder le code simple et spécifique
class DataProcessor {
  public void ProcessData(string data) {
    // Code pour traiter les données
  }
}
```

### Loi de Déméter
La loi de Déméter (LoD) est un principe de conception logicielle qui stipule qu'un module ne doit interagir qu'avec ses dépendances directes. Cela réduit le couplage et améliore la maintenabilité.

**Exemple en C# :**
```csharp
// Mauvais exemple : violation de la loi de Déméter
class Order {
  public Customer Customer { get; set; }
}

class Customer {
  public Address Address { get; set; }
}

class Address {
  public string City { get; set; }
}

class OrderProcessor {
  public void PrintOrderCity(Order order) {
    Console.WriteLine(order.Customer.Address.City);
  }
}

// Bon exemple : respect de la loi de Déméter
class Order {
  public Customer Customer { get; set; }

  public string GetOrderCity() {
    return Customer.GetCustomerCity();
  }
}

class Customer {
  public Address Address { get; set; }

  public string GetCustomerCity() {
    return Address.City;
  }
}

class Address {
  public string City { get; set; }
}

class OrderProcessor {
  public void PrintOrderCity(Order order) {
    Console.WriteLine(order.GetOrderCity());
  }
}
```

## Design Pattern

### Singleton

Le pattern Singleton garantit qu'une classe n'a qu'une seule instance et fournit un point d'accès global à cette instance. Il est souvent utilisé pour gérer des ressources partagées comme des connexions à une base de données ou des fichiers de configuration.

**Exemple en C# :**
```csharp
public class Singleton
{
  private static Singleton _instance;

  private Singleton() { }

  public static Singleton Instance
  {
    get
    {
      if (_instance == null)
      {
        _instance = new Singleton();
      }
      return _instance;
    }
  }

  public void DoSomething()
  {
    Console.WriteLine("Singleton instance in action!");
  }
}

// Utilisation
Singleton.Instance.DoSomething();
```


### Factory

Le pattern Factory permet de créer des objets sans exposer la logique de création au client. Il délègue la responsabilité de l'instanciation à une méthode ou une classe dédiée, ce qui facilite l'ajout de nouveaux types d'objets.

**Exemple en C# :**
```csharp
public abstract class Animal
{
  public abstract void Speak();
}

public class Dog : Animal
{
  public override void Speak() => Console.WriteLine("Woof!");
}

public class Cat : Animal
{
  public override void Speak() => Console.WriteLine("Meow!");
}

public class AnimalFactory
{
  public static Animal CreateAnimal(string type)
  {
    return type switch
    {
      "dog" => new Dog(),
      "cat" => new Cat(),
      _ => throw new ArgumentException("Unknown animal type")
    };
  }
}

// Utilisation
Animal animal = AnimalFactory.CreateAnimal("dog");
animal.Speak(); // Woof!
```


### Strategy

Le pattern Strategy permet de définir une famille d'algorithmes, de les encapsuler et de les rendre interchangeables. Il permet de modifier dynamiquement le comportement d'un objet.

**Exemple en C# :**
```csharp
public interface IPaymentStrategy
{
  void Pay(decimal amount);
}

public class CreditCardPayment : IPaymentStrategy
{
  public void Pay(decimal amount) => Console.WriteLine($"Paid {amount}€ with credit card.");
}

public class PaypalPayment : IPaymentStrategy
{
  public void Pay(decimal amount) => Console.WriteLine($"Paid {amount}€ with PayPal.");
}

public class ShoppingCart
{
  private IPaymentStrategy _paymentStrategy;

  public ShoppingCart(IPaymentStrategy paymentStrategy)
  {
    _paymentStrategy = paymentStrategy;
  }

  public void Checkout(decimal amount)
  {
    _paymentStrategy.Pay(amount);
  }
}

// Utilisation
var cart = new ShoppingCart(new PaypalPayment());
cart.Checkout(50); // Paid 50€ with PayPal.
```


### Observer

Le pattern Observer définit une dépendance un-à-plusieurs entre des objets, de sorte que lorsqu'un objet change d'état, tous ses observateurs sont notifiés et mis à jour automatiquement.

**Exemple en C# :**
```csharp
public interface IObserver
{
  void Update(string message);
}

public class User : IObserver
{
  public string Name { get; set; }
  public User(string name) => Name = name;
  public void Update(string message) => Console.WriteLine($"{Name} received: {message}");
}

public class NotificationService
{
  private List<IObserver> _observers = new List<IObserver>();

  public void Subscribe(IObserver observer) => _observers.Add(observer);
  public void Unsubscribe(IObserver observer) => _observers.Remove(observer);

  public void Notify(string message)
  {
    foreach (var observer in _observers)
      observer.Update(message);
  }
}

// Utilisation
var service = new NotificationService();
var alice = new User("Alice");
var bob = new User("Bob");
service.Subscribe(alice);
service.Subscribe(bob);
service.Notify("Nouvelle notification !");
```


### Adapter

Le pattern Adapter permet de faire fonctionner ensemble des interfaces incompatibles. Il agit comme un traducteur entre deux objets qui n'auraient pas pu collaborer autrement.

**Exemple en C# :**
```csharp
// Interface attendue
public interface ITarget
{
  void Request();
}

// Classe existante incompatible
public class LegacyService
{
  public void SpecificRequest() => Console.WriteLine("Legacy request executed.");
}

// Adaptateur
public class Adapter : ITarget
{
  private readonly LegacyService _legacyService;
  public Adapter(LegacyService legacyService) => _legacyService = legacyService;
  public void Request() => _legacyService.SpecificRequest();
}

// Utilisation
ITarget target = new Adapter(new LegacyService());
target.Request(); // Legacy request executed.
```


### Decorator

Le pattern Decorator permet d'ajouter dynamiquement des fonctionnalités à un objet sans modifier sa structure. Il favorise la composition plutôt que l'héritage.

**Exemple en C# :**
```csharp
public interface INotifier
{
  void Send(string message);
}

public class EmailNotifier : INotifier
{
  public void Send(string message) => Console.WriteLine($"Email: {message}");
}

public class SmsDecorator : INotifier
{
  private readonly INotifier _notifier;
  public SmsDecorator(INotifier notifier) => _notifier = notifier;
  public void Send(string message)
  {
    _notifier.Send(message);
    Console.WriteLine($"SMS: {message}");
  }
}

// Utilisation
INotifier notifier = new SmsDecorator(new EmailNotifier());
notifier.Send("Hello!"); // Email: Hello! puis SMS: Hello!
```


### Builder

Le pattern Builder sépare la construction d'un objet complexe de sa représentation, permettant de créer différents types et représentations d'un même objet.

**Exemple en C# :**
```csharp
public class Pizza
{
  public string Dough { get; set; }
  public string Sauce { get; set; }
  public string Topping { get; set; }
}

public class PizzaBuilder
{
  private Pizza _pizza = new Pizza();

  public PizzaBuilder SetDough(string dough) { _pizza.Dough = dough; return this; }
  public PizzaBuilder SetSauce(string sauce) { _pizza.Sauce = sauce; return this; }
  public PizzaBuilder SetTopping(string topping) { _pizza.Topping = topping; return this; }
  public Pizza Build() => _pizza;
}

// Utilisation
var pizza = new PizzaBuilder()
  .SetDough("Thin Crust")
  .SetSauce("Tomato")
  .SetTopping("Cheese")
  .Build();
Console.WriteLine($"{pizza.Dough}, {pizza.Sauce}, {pizza.Topping}");
```
