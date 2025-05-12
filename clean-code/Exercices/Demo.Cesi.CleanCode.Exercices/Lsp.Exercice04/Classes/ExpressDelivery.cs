namespace Lsp.Exercice04.Classes
{
    public class ExpressDelivery : Delivery
    {
        public override void ShipOrder(string destination)
        {
            Console.WriteLine($"Shipping express to {destination} (24h)");
        }
    }

}
