using Android.App;
using Android.Content.PM;
using Android.OS;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using Samples.Cross.Forms.Infra;
using Samples.Cross.Forms.Launcher;
using Xamarin.Forms.Platform.Android;

namespace Samples.Cross.Droid
{
    [Activity(Label = "Samples.Cross", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(ContainerContext<ExtendedSimpleContainerAdapter>.Resolver.Resolve<FormsApp>());
        }
    }
}