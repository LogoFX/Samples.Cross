using System;
using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Xamarin.Forms;
using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Client.Mvvm.ViewModelFactory.SimpleContainer;

namespace Samples.Cross.Forms.Launcher
{
    internal static class BootstrapperExtensions
    {
        internal static BootstrapperBase UseMiddlewares(this BootstrapperBase bootstrapper)
        {
            return bootstrapper
                .UseViewModelCreatorService()
                .UseViewModelFactory()
                .Use(new RegisterViewModelsMiddleware<BootstrapperBase>(new Type[] { }));
        }
    }
}
