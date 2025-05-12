namespace Lsp.Exercice04.Classes
{
    public class OrderProcessor
    {
        public void Process(Delivery delivery, string destination)
        {
            delivery.ShipOrder(destination);
        }
    }

}
