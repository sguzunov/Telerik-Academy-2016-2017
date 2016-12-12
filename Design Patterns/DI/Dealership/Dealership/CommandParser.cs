using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Dealership.Core.Contracts;
using Dealership.Factories.Contracts;

namespace Dealership
{
    public class CommandParser : ICommandParser
    {
        private const char SplitCommandSymbol = ' ';
        private const string CommentOpenSymbol = "{{";
        private const string CommentCloseSymbol = "}}";

        private readonly ICommandsFactory commandsFactory;

        public ICommand ParseCommand(string commandAsString)
        {
            string commandName = this.ExtractName(commandAsString);
            IList<string> parameters = this.ExtractParameters(commandAsString);
            ICommand command = this.commandsFactory.CreateCommand(commandName, parameters);

            return command;
        }

        private string ExtractName(string commandAsString)
        {
            var indexOfFirstSeparator = commandAsString.IndexOf(SplitCommandSymbol);
            if (indexOfFirstSeparator < 0)
            {
                return commandAsString;
            }

            return commandAsString.Substring(0, indexOfFirstSeparator);
        }

        private IList<string> ExtractParameters(string commandAsString)
        {
            var indexOfFirstSeparator = commandAsString.IndexOf(SplitCommandSymbol);
            var indexOfOpenComment = commandAsString.IndexOf(CommentOpenSymbol);
            var indexOfCloseComment = commandAsString.IndexOf(CommentCloseSymbol);
            Regex regex = new Regex("{{.+(?=}})}}");

            var parameters = new List<string>();
            if (indexOfOpenComment >= 0)
            {
                parameters.Add(commandAsString.Substring(indexOfOpenComment + CommentOpenSymbol.Length,
                    indexOfCloseComment - CommentCloseSymbol.Length - indexOfOpenComment));
                commandAsString = regex.Replace(commandAsString, string.Empty);
            }

            parameters.AddRange(commandAsString.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol },
                StringSplitOptions.RemoveEmptyEntries));

            return parameters;
        }
    }
}
