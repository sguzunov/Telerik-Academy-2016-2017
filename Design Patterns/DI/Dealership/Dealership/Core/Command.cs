using System;
using System.Collections.Generic;

using Dealership.Core.Contracts;

namespace Dealership.Core
{
    public class Command : ICommand
    {
        private string name;
        private IList<string> parameters;

        public Command(string name, List<string> parameters)
        {
            this.Name = name;
            this.Parameters = parameters;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {

                    throw new ArgumentNullException("Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IList<string> Parameters
        {
            get
            {
                return this.parameters;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of strings cannot be null.");
                }

                this.parameters = value;
            }
        }
    }
}
