using LogoFX.Client.Bootstrapping;

namespace Samples.Cross.WPF.Launcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            var bootstrapper = new AppBootstrapper();
            bootstrapper
                .UseResolver()               
                .Initialize();
        }
    }
}
