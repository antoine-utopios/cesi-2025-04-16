namespace Lsp.Exercice04.Classes
{
    public class InternationalDelivery : Delivery
    {
        public override void ShipOrder(string destination)
        {
            if (destination.ToLower() == "france")
            {
                throw new InvalidOperationException("Use local shipping for France.");
            }

            Console.WriteLine($"Shipping internationally to {destination}");
        }
    }

}
