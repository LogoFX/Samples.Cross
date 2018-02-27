using LogoFX.Client.Bootstrapping.Adapters.Contracts;
using Solid.Practices.IoC;

namespace Samples.Cross.Forms.Infra
{
    public class Bridge<TApp, TBootstrapper, TContainerAdapter>
        where TApp : class
        where TBootstrapper : BootstrapperBase
        where TContainerAdapter : IDependencyRegistrator, IDependencyResolver, IBootstrapperAdapter, new()
    {
        public static void Initialize()
        {
            ContainerContext<TContainerAdapter>.Registrator.RegisterInstance(ContainerContext<TContainerAdapter>.Registrator);
            ContainerContext<TContainerAdapter>.Registrator.RegisterInstance(ContainerContext<TContainerAdapter>.Resolver);
            ContainerContext<TContainerAdapter>.Registrator.RegisterSingleton<TApp>();
            ContainerContext<TContainerAdapter>.Registrator.RegisterSingleton<TBootstrapper>();
            ContainerContext<TContainerAdapter>.Registrator.RegisterSingleton<BootstrapperBase, TBootstrapper>();
        }
    }
}
