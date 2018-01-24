using Samples.Cross.Data.Contracts.Providers;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Cross.Data.Fake.Providers
{
    public class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.RegisterSingleton<INetworksProvider, FakeNetworksProvider>();           
        }
    }
}
