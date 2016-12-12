using Dealership.Core.Contracts;

namespace Dealership.CommandExecutors
{
    public class LogoutUserCommandExecutor : GenericCommandExecutor, ICommandExecutor
    {
        private const string CommandName = "Logout";
        private const string UserLoggedOut = "You logged out!";

        private readonly IUsersManager usersManager;

        public LogoutUserCommandExecutor(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }

        protected override bool CanExecuteCommand(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Execute(ICommand command)
        {
            this.usersManager.Logout();
            return UserLoggedOut;
        }
    }
}
