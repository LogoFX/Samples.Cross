using System;
using System.Collections.Generic;
using System.Windows.Threading;
using Caliburn.Micro;
using LogoFX.Client.Bootstrapping.Adapters.Contracts;
using Samples.Cross.Forms.Infra;
using Solid.Practices.IoC;

namespace Samples.Cross.iOS.Infra
{
    public class LogoFXApplicationDelegate<TApp, TBootstrapper, TContainerAdapter> : CaliburnApplicationDelegate
        where TApp : class
        where TBootstrapper : BootstrapperBase
        where TContainerAdapter : IDependencyRegistrator, IDependencyResolver, IBootstrapperAdapter, new()
    {
        public LogoFXApplicationDelegate()
        {
            Initialize();
        }

        protected override void Configure()
        {
            Bridge<TApp, TBootstrapper>.Initialize(new TContainerAdapter());
            Dispatch.Current = new PlatformDispatch();
        }

        protected override void BuildUp(object instance)
        {
            ContainerContext.Adapter.BuildUp(instance);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return ContainerContext.Adapter.GetAllInstances(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return ContainerContext.Adapter.GetInstance(service, key);
        }

    }
}
