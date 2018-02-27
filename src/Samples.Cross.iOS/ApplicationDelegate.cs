using System.Collections.Generic;
using System.Reflection;
using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using Samples.Cross.Forms.Launcher;
using Samples.Cross.Forms.Presentation.Shell.ViewModels;

namespace Samples.Cross.iOS
{
    public class ApplicationDelegate : LogoFXApplicationDelegate<FormsApp, Bootstrapper, ExtendedSimpleContainerAdapter>
    {
        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return
                new[]
                {                    
                    //TODO: Needed for views to be registered - consider using this manually in the bootstrapper
                    typeof(ShellViewModel).Assembly
                };
        }
    }
}
