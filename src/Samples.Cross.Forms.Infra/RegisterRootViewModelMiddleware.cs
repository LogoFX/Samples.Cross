using Solid.Bootstrapping;
using Solid.Practices.Middleware;

namespace Samples.Cross.Forms.Infra
{
    public class RegisterRootViewModelMiddleware<TBootstrapper, TRootViewModel> : IMiddleware<TBootstrapper>
        where TBootstrapper : class, IHaveRegistrator
        where TRootViewModel : class
    {
        public TBootstrapper Apply(TBootstrapper @object)
        {
            @object.Registrator.RegisterSingleton<TRootViewModel>();
            return @object;
        }
    }
}
