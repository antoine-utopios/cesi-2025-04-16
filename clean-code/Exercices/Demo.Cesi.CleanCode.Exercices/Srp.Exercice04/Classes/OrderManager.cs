using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srp.Exercice04.Classes
{
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
}
