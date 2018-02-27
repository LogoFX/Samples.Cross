using LogoFX.Client.Bootstrapping.Adapters.Contracts;
using Solid.Practices.IoC;

namespace Samples.Cross.Forms.Infra
{
    public static class ContainerContext<TContainerAdapter>
        where TContainerAdapter : IDependencyRegistrator, IDependencyResolver, IBootstrapperAdapter, new()
    {
        private static readonly TContainerAdapter _instance = new TContainerAdapter();

        public static IDependencyRegistrator Registrator => _instance;

        public static IDependencyResolver Resolver => _instance;

        public static IBootstrapperAdapter Adapter => _instance;
    }
}
