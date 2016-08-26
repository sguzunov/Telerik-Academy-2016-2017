namespace Events
{
    using System;

    public class Startup
    {
        private const string AddCommand = "AddEvent";
        private const string DeleteCommand = "DeleteEvents";
        private const string ListCommand = "ListEvents";

        private static EventHolder events = new EventHolder();

        public static void Main()
        {
            bool hasNextCommand = ExecuteNextCommand();
            while (hasNextCommand)
            {
                hasNextCommand = ExecuteNextCommand();
            }

            Console.WriteLine(Messages.GetOutput());
        }

        private static bool ExecuteNextCommand()
        {
            string command = Console.ReadLine();
            if (command[0] == AddCommand[0])
            {
                AddEvent(command);
            }
            else if (command[0] == DeleteCommand[0])
            {
                DeleteEvents(command);
            }
            else if (command[0] == ListCommand[0])
            {
                ListEvents(command);
            }
            else
            {
                return false;
            }

            return true;
        }

        private static void ListEvents(string command)
        {
            int pipeIndex = command.IndexOf('|');
            DateTime date = GetDate(command, ListCommand);
            string countString = command.Substring(pipeIndex + 1);
            int count = int.Parse(countString);

            events.ListEvents(date, count);
        }

        private static void DeleteEvents(string command)
        {
            string title = command.Substring(DeleteCommand.Length + 1);
            events.DeleteEvents(title);
        }

        private static void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;
            GetParameters(command, AddCommand, out date, out title, out location);

            events.AddEvent(date, title, location);
        }

        private static void GetParameters(
            string commandForExecution,
            string commandType,
            out DateTime dateAndTime,
            out string eventTitle,
            out string eventLocation)
        {
            dateAndTime = GetDate(commandForExecution, commandType);
            int firstPipeIndex = commandForExecution.IndexOf('|');
            int lastPipeIndex = commandForExecution.LastIndexOf('|');
            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }

        private static DateTime GetDate(string command, string commandType)
        {
            DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));

            return date;
        }
    }
}