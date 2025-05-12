namespace Dip.Exercice03.Classes
{
    public class UserInterface
    {
        private UserService _service = new UserService();

        public void ShowUser()
        {
            Console.WriteLine(_service.GetUserName());
        }
    }

}
