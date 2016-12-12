using System;

using Dealership.Common.Enums;
using Dealership.Core.Contracts;
using Dealership.Factories;

namespace Dealership.CommandExecutors
{
    public class RegisterUserCommandExecutor : GenericCommandExecutor, ICommandExecutor
    {
        private const string CommandName = "RegisterUser";
        private const string UserAlreadyExist = "User {0} already exist. Choose a different username!";
        private const string UserLoggedInAlready = "User {0} is logged in! Please log out first!";
        private const string UserRegisterеd = "User {0} registered successfully!";

        private readonly IUsersManager userManager;
        private readonly IDealershipFactory dealershipFactory;

        public RegisterUserCommandExecutor(IUsersManager userManager, IDealershipFactory dealershipFactory)
        {
            this.dealershipFactory = dealershipFactory;
            this.userManager = userManager;
        }

        protected override bool CanExecuteCommand(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Execute(ICommand command)
        {
            var username = command.Parameters[0];
            var firstName = command.Parameters[1];
            var lastName = command.Parameters[2];
            var password = command.Parameters[3];

            var role = Role.Normal;

            if (command.Parameters.Count > 4)
            {
                role = (Role)Enum.Parse(typeof(Role), command.Parameters[4]);
            }

            string message = this.RegisterUser(username, firstName, lastName, password, role);

            return message;
        }

        private string RegisterUser(string username, string firstName, string lastName, string password, Role role)
        {
            if (this.userManager.LoggedUser != null)
            {
                return string.Format(UserLoggedInAlready, this.userManager.LoggedUser.Username);
            }

            if (this.userManager.HasRegisteredUser(username))
            {
                return string.Format(UserAlreadyExist, username);
            }

            var user = this.dealershipFactory.CreateUser(username, firstName, lastName, password, role.ToString());
            this.userManager.Register(user);
            this.userManager.Login(user);

            return string.Format(UserRegisterеd, username);
        }
    }
}
