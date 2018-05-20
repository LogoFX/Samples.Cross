using LogoFX.Client.Bootstrapping.Xamarin.Forms;
using Samples.Cross.Forms.Launcher;

namespace Samples.Cross.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
           
            LoadApplication(ContainerContext.Resolver.Resolve<FormsApp>());
        }
    }
}
