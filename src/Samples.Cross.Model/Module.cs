using Samples.Cross.Model.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Cross.Model
{
    public class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.RegisterSingleton<ILoginService, LoginService>();
        }
    }
}
