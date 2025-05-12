namespace Dip.Exercice03.Classes
{
    public class UserService
    {
        private UserRepository _repository = new UserRepository();

        public string GetUserName()
        {
            return _repository.GetUser();
        }
    }

}
