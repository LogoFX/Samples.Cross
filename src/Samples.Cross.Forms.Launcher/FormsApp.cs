using LogoFX.Client.Bootstrapping.Xamarin.Forms;
using Samples.Cross.Forms.Presentation.Shell.ViewModels;

namespace Samples.Cross.Forms.Launcher
{
    public class FormsApp : LogoFXApplication<ShellViewModel>
    {
        public FormsApp(Bootstrapper bootstrapper) :
        base(
            bootstrapper.UseMiddlewares())
        {            
        }
    }
}
