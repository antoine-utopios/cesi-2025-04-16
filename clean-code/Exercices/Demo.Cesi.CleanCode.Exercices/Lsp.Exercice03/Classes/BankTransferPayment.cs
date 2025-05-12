namespace Lsp.Exercice03.Classes
{
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
}
