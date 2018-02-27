using Foundation;
using LogoFX.Client.Bootstrapping.Xamarin.Forms;
using Samples.Cross.Forms.Launcher;
using UIKit;

namespace Samples.Cross.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private readonly ApplicationDelegate appDelegate = new ApplicationDelegate();

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.Init();

            // Code for starting up the Xamarin Test Cloud Agent
#if DEBUG
            Xamarin.Calabash.Start();
#endif
            LoadApplication(ContainerContext.Resolver.Resolve<FormsApp>());

            return base.FinishedLaunching(app, options);
        }
    }
}
