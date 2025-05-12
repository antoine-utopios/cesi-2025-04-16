namespace Dip.Exercice02.Classes
{
    public class AppManager
    {
        private FileLogger _logger = new FileLogger();

        public void Run()
        {
            _logger.Log("Application démarrée");
        }
    }

}
