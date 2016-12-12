using System.Collections.Generic;

using Dealership.Models.Contracts;

namespace Dealership.Core.Contracts
{
    public interface IUsersManager
    {
        IUser LoggedUser { get; }

        IEnumerable<IUser> Users { get; }

        void Register(IUser user);

        void Login(IUser user);

        void Logout();

        bool HasRegisteredUser(string username);
    }
}
