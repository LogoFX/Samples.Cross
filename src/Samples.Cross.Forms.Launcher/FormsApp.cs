using LogoFX.Client.Bootstrapping.Xamarin.Forms;
using Samples.Cross.Forms.Presentation.Shell.ViewModels;
using Solid.Practices.IoC;

namespace Samples.Cross.Forms.Launcher
{
    public class FormsApp : LogoFXApplication<ShellViewModel>
    {
        public FormsApp(BootstrapperBase bootstrapper, IDependencyRegistrator dependencyRegistrator) :
        base(
            bootstrapper.UseMiddlewares(), 
            dependencyRegistrator)
        {            
        }
    }
}
