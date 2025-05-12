namespace Lsp.Exercice03.Classes
{
    public class CreditCardPayment : PaymentMethod
    {
        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount}€");
        }
    }
}
