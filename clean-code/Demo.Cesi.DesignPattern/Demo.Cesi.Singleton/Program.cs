using Demo.Cesi.Singleton.Classes;

// Singleton pattern : L'objectif est ici de s'assurer que l'on travaillera toujours avec la même instance de notre classe, de sorte à ne pas avoir plusieurs références inutiles dans notre application. Attention cependant en cas de processus bloquant ou de modification de données liées à un type référence

DatabaseConnection connection = new DatabaseConnection();
DatabaseConnection connectionBis = new DatabaseConnection();

// Sauvegarde A 
DatabaseConnection.Instance.SaveToDatabase("A");
// Sauvegarde B
DatabaseConnection.Instance.SaveToDatabase(2);