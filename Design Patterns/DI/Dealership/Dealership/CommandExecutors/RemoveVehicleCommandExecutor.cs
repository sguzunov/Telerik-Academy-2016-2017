using System;

using Dealership.Core.Contracts;

namespace Dealership.CommandExecutors
{
    public class RemoveVehicleCommandExecutor : GenericCommandExecutor, ICommandExecutor
    {
        private const string CommandName = "RemoveVehicle";
        private const string RemovedVehicleDoesNotExist = "Cannot remove comment! The vehicle does not exist!";
        private const string VehicleRemovedSuccessfully = "{0} removed vehicle successfully!";

        private readonly IUsersManager usersManager;

        public RemoveVehicleCommandExecutor(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }

        protected override bool CanExecuteCommand(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Execute(ICommand command)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;

            return this.RemoveVehicle(vehicleIndex);
        }

        private string RemoveVehicle(int vehicleIndex)
        {
            var loggedUser = this.usersManager.LoggedUser;
            if (vehicleIndex < 0 || vehicleIndex >= loggedUser.Vehicles.Count)
            {
                throw new ArgumentException(RemovedVehicleDoesNotExist);
            }

            var vehicle = this.usersManager.LoggedUser.Vehicles[vehicleIndex];

            loggedUser.RemoveVehicle(vehicle);

            return string.Format(VehicleRemovedSuccessfully, loggedUser.Username);
        }
    }
}
