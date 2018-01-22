using System;
using Caliburn.Micro.Xamarin.Forms;
using LogoFX.Bootstrapping;
using LogoFX.Client.Bootstrapping;
using Samples.Cross.Forms.Presentation.Shell.ViewModels;
using Solid.Practices.IoC;
using Xamarin.Forms;

namespace Samples.Cross.Forms.Launcher
{
    public class FormsApp : FormsApplication
    {
        private readonly IDependencyRegistrator _dependencyRegistrator;

        public FormsApp(IDependencyRegistrator dependencyRegistrator)
        {
            Initialize();
                       
            _dependencyRegistrator = dependencyRegistrator;
            var bootstrapper =
                new Bootstrapper(_dependencyRegistrator)
                    .Use(new RegisterCompositionModulesMiddleware<Bootstrapper>())
                    .Use(new RegisterViewModelsMiddleware<Bootstrapper>(new Type[] { }));
            bootstrapper.Initialize();
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override void PrepareViewFirst(NavigationPage navigationPage)
        {
            _dependencyRegistrator.RegisterInstance<INavigationService>(new NavigationPageAdapter(navigationPage));
        }
    }
}
