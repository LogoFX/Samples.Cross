using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Samples.Cross.Forms.Presentation.Shell.Views
{
    //TODO: Check EmbeddedResource issue
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShellView : ContentPage
	{
		public ShellView ()
		{
			InitializeComponent ();
		}
	}
}