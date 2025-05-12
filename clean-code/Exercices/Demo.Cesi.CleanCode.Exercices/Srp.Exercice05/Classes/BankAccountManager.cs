using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srp.Exercice05.Classes
{
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

}
