using Android.App;
using Android.Content.PM;
using Android.OS;
using Samples.Cross.Forms.Launcher;
using Samples.Cross.Shared;
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

            LoadApplication(ContainerContext.Resolver.Resolve<FormsApp>());
        }
    }
}