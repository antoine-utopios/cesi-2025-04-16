namespace Dip.Exercice01.Classes
{
    public class OrderProcessor
    {
        private EmailService _emailService = new EmailService();

        public void Process()
        {
            // Traitement de la commande...
            _emailService.SendEmail("Commande traitée.");
        }
    }

}
