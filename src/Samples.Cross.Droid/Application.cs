using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Threading;
using Android.App;
using Android.Runtime;
using Caliburn.Micro;
using Samples.Cross.Forms.Launcher;
using Samples.Cross.Forms.Presentation.Shell.ViewModels;
using Samples.Cross.Shared;

namespace Samples.Cross.Droid
{
    [Application]
    public class Application : CaliburnApplication
    {
        public Application(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        protected override void Configure()
        {
            Bridge.Initialize();
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

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return
                new[]
                {                    
                    //TODO: Needed for views to be registered - consider using this manually in the bootstrapper
                    Assembly.GetAssembly(typeof(ShellViewModel))
                };
        }
    }
}