using LogoFX.Client.Bootstrapping.Adapters.Contracts;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using Solid.Practices.IoC;

namespace Samples.Cross.Shared
{
    public static class ContainerContext
    {
        private static readonly ExtendedSimpleContainerAdapter _instance = new ExtendedSimpleContainerAdapter();

        public static IDependencyRegistrator Registrator { get => _instance; }

        //TODO: Remove explicit service location - it's used on one occasion only
        public static IDependencyResolver Resolver { get => _instance; }

        //TODO: Move all associated logic to the dedicated bootstrapper
        public static IBootstrapperAdapter Adapter { get => _instance; }
    }
}