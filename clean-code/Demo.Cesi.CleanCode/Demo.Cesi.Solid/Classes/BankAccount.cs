using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Cesi.Solid.Interfaces;

namespace Demo.Cesi.Solid.Classes
{
    internal class BankAccount
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public List<string> operations { get; set; } = new List<string>();

        public void Deposit(IOperationBancaire operation)
        {
            // Réaliser le calcul du solde final à partir de l'opération
        }

        public bool SaveToDatabase()
        {
            // Methode de connexion puis sauvegarde en base de données
    }
}
