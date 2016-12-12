using System.Collections.Generic;
using System.Linq;

using Dealership.Core.Contracts;
using Dealership.Exceptions;
using Dealership.Models.Contracts;

namespace Dealership.Core
{
    public class UserManager : IUsersManager
    {
        private readonly ICollection<IUser> registeredUsers;

        private IUser loggedUser;

        public IUser LoggedUser => this.loggedUser;

        public IEnumerable<IUser> Users => this.registeredUsers;

        public UserManager()
        {
            this.loggedUser = null;
            this.registeredUsers = new HashSet<IUser>();
        }

        public bool HasLoggedUser()
        {
            return this.loggedUser != null;
        }

        public void Login(IUser user)
        {
            if (!this.HasRegisteredUser(user.Username))
            {
                throw new NotExistingUserException($"User with username \"{user.Username}\" is not logged in!");
            }

            this.loggedUser = user;
        }

        public void Logout()
        {
            this.loggedUser = null;
        }

        public void Register(IUser user)
        {
            if (this.HasRegisteredUser(user.Username))
            {
                throw new UserAlreadyExistsException($"User with username \"{user.Username}\" already exists!");
            }

            this.registeredUsers.Add(user);
        }

        public bool HasRegisteredUser(string username)
        {
            return this.registeredUsers.Any(x => x.Username.ToLower() == username.ToLower());
        }
    }
}
