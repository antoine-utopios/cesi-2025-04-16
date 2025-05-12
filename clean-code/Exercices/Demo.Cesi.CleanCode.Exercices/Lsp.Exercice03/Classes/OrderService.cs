namespace Lsp.Exercice03.Classes
{
    public class OrderService
    {
        public void PayOrder(PaymentMethod method, decimal amount)
        {
            method.ProcessPayment(amount);
        }
    }
}
