using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Solid.Bootstrapping;
using Solid.Extensibility;
using Solid.Practices.Composition;
using Solid.Practices.Composition.Container;
using Solid.Practices.Composition.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;
using Solid.Practices.Modularity;

namespace Samples.Cross.Forms.Launcher
{
    public class Bootstrapper : IInitializable,
        IExtensible<Bootstrapper>,
        ICompositionModulesProvider,
        IHaveRegistrator,
        IAssemblySourceProvider
    {
        private readonly
            List<IMiddleware<Bootstrapper>>
            _middlewares =
                new List<IMiddleware<Bootstrapper>>();

        public Bootstrapper(IDependencyRegistrator dependencyRegistrator)
        {
            Registrator = dependencyRegistrator;
            PlatformProvider.Current = new NetStandardPlatformProvider();
        }

        /// <summary>
        /// Gets the list of modules that were discovered during bootstrapper configuration.
        /// </summary>
        /// <value>
        /// The list of modules.
        /// </value>
        public IEnumerable<ICompositionModule> Modules { get; private set; } = new ICompositionModule[] { };

        public IDependencyRegistrator Registrator { get; }

        //TODO: Load assemblies by prefix
        public IEnumerable<Assembly> Assemblies => new Assembly[]
            {
                //Assembly.GetAssembly(typeof(ShellViewModel)),
                //Assembly.GetAssembly(typeof(HelloXamarinForms.Model.Module)),
                //Assembly.GetAssembly(typeof(HelloXamarinForms.Data.Fake.Providers.Module)),
                //Assembly.GetAssembly(typeof(HelloXamarinForms.Data.Fake.ProviderBuilders.Module))
            };

        private void InitializeCompositionModules()
        {
            //TODO: File-Based assembly loading does not work in mobile platforms yet     
            ICompositionContainer<ICompositionModule> innerContainer = new SimpleCompositionContainer<ICompositionModule>(
                Assemblies,
                new ActivatorCreationStrategy());
            innerContainer.Compose();
            Modules = innerContainer.Modules.ToArray();
        }

        /// <summary>
        /// Extends the functionality by using the specified middleware.
        /// </summary>
        /// <param name="middleware">The middleware.</param>
        /// <returns></returns>
        public Bootstrapper Use(
            IMiddleware<Bootstrapper> middleware)
        {
            _middlewares.Add(middleware);
            return this;
        }

        public void Initialize()
        {
            InitializeCompositionModules();
            MiddlewareApplier.ApplyMiddlewares(this, _middlewares);
        }
    }
}
