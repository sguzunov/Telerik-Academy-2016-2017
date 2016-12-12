using System.Linq;

using Dealership.Core.Contracts;

namespace Dealership.CommandExecutors
{
    public class LoginUserCommandExecutor : GenericCommandExecutor, ICommandExecutor
    {
        private const string CommandName = "Login";
        private const string UserLoggedInAlready = "User {0} is logged in! Please log out first!";
        private const string UserLoggedIn = "User {0} successfully logged in!";
        private const string WrongUsernameOrPassword = "Wrong username or password!";

        private readonly IUsersManager usersManager;

        public LoginUserCommandExecutor(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }

        protected override bool CanExecuteCommand(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Execute(ICommand command)
        {
            string username = command.Parameters[0];
            string password = command.Parameters[1];

            return this.LoginUser(username, password);
        }

        private string LoginUser(string username, string password)
        {
            if (this.usersManager.LoggedUser != null)
            {
                return string.Format(UserLoggedInAlready, username);
            }

            var foundUser = this.usersManager.Users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
            if (foundUser != null && foundUser.Password.ToLower() == password.ToLower())
            {
                this.usersManager.Login(foundUser);
                return string.Format(UserLoggedIn, username);
            }

            return WrongUsernameOrPassword;
        }
    }
}
