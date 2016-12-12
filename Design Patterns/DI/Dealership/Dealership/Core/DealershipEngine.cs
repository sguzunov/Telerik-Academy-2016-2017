using System;
using System.Collections.Generic;
using System.Text;

using Dealership.CommandExecutors;
using Dealership.Core.Contracts;
using Dealership.IOProviders.Contracts;

namespace Dealership.Core
{
    public sealed class DealershipEngine : IEngine
    {
        private const string UserNotLogged = "You are not logged! Please login first!";

        private readonly IOutputProvider outputProvider;
        private readonly IUsersManager usersManager;
        private ICommandExecutor executor;

        private DealershipEngine(
            IOutputProvider outputProvider,
            ICommandExecutor executor)
        {
            this.outputProvider = outputProvider;
            this.executor = executor;
        }

        public void Start(IEnumerable<ICommand> commands)
        {
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        private IList<string> ProcessCommands(IEnumerable<ICommand> commands)
        {
            var reports = new List<string>();
            foreach (var command in commands)
            {
                try
                {
                    var report = this.ProcessSingleCommand(command);
                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }
            }

            return reports;
        }

        private void PrintReports(IList<string> reports)
        {
            var output = new StringBuilder();
            foreach (var report in reports)
            {
                output.AppendLine(report);
                output.AppendLine(new string('#', 20));
            }

            this.outputProvider.Write(output.ToString());
        }

        private string ProcessSingleCommand(ICommand command)
        {
            if ((command.Name != "RegisterUser" && command.Name != "Login") &&
                this.usersManager.LoggedUser == null)
            {
                return UserNotLogged;
            }

            return this.executor.ExecuteCommand(command);
        }
    }
}
