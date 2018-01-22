using Samples.Cross.Forms.Launcher;
using Samples.Cross.Shared;

namespace Samples.Cross.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
           
            LoadApplication(ContainerContext.Resolver.Resolve<FormsApp>());
        }
    }
}
