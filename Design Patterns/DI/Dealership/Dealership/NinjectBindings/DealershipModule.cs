using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Dealership.IOProviders.Contracts;
using Dealership.IOProviders;

namespace Dealership.NinjectBindings
{
    public class DealershipModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            Bind<IInputProvider>().To<ConsoleInputProvider>();
            Bind<IOutputProvider>().To<ConsoleOutputProviders>();


        }
    }
}
