using System;

using Dealership.Common.Enums;
using Dealership.Core.Contracts;
using Dealership.Factories;
using Dealership.Models.Contracts;

namespace Dealership.CommandExecutors
{
    public class AddVehicleCommandExecutor : GenericCommandExecutor, ICommandExecutor
    {
        private const string CommandName = "AddVehicle";
        private const string VehicleAddedSuccessfully = "{0} added vehicle successfully!";

        private IDealershipFactory dealershipFactory;
        private IUsersManager usersManager;

        public AddVehicleCommandExecutor(IDealershipFactory dealershipFactory, IUsersManager usersManager)
        {
            this.dealershipFactory = dealershipFactory;
            this.usersManager = usersManager;
        }

        protected override bool CanExecuteCommand(ICommand command)
        {
            return command.Name == CommandName;
        }

        protected override string Execute(ICommand command)
        {
            var type = command.Parameters[0];
            var make = command.Parameters[1];
            var model = command.Parameters[2];
            var price = decimal.Parse(command.Parameters[3]);
            var additionalParam = command.Parameters[4];

            var typeEnum = (VehicleType)Enum.Parse(typeof(VehicleType), type, true);

            string message = this.AddVehicle(typeEnum, make, model, price, additionalParam);

            return message;
        }

        private string AddVehicle(VehicleType type, string make, string model, decimal price, string additionalParam)
        {
            IVehicle vehicle = null;

            if (type == VehicleType.Car)
            {
                vehicle = this.dealershipFactory.CreateCar(make, model, price, int.Parse(additionalParam));
            }
            else if (type == VehicleType.Motorcycle)
            {
                vehicle = this.dealershipFactory.CreateMotorcycle(make, model, price, additionalParam);
            }
            else if (type == VehicleType.Truck)
            {
                vehicle = this.dealershipFactory.CreateTruck(make, model, price, int.Parse(additionalParam));
            }

            this.usersManager.LoggedUser.AddVehicle(vehicle);

            return string.Format(VehicleAddedSuccessfully, this.usersManager.LoggedUser.Username);
        }
    }
}
