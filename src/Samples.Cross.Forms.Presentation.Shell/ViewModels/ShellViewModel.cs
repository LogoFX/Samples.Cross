using Caliburn.Micro;
using LogoFX.Client.Mvvm.ViewModel.Services;

#if NETSTANDARD2_0
namespace Samples.Cross.Forms.Presentation.Shell.ViewModels
#elif NET
namespace Samples.Cross.WPF.Presentation.Shell.ViewModels
#endif
{
    public class ShellViewModel : Conductor<object>.Collection.OneActive
    {
        private readonly IViewModelCreatorService _viewModelCreatorService;

        public ShellViewModel(           
            IViewModelCreatorService viewModelCreatorService)
        {
            _viewModelCreatorService = viewModelCreatorService;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            var loginViewModel = _viewModelCreatorService.CreateViewModel<LoginViewModel>();
            var mainViewModel = _viewModelCreatorService.CreateViewModel<MainViewModel>();
            Items.Add(loginViewModel);
            Items.Add(mainViewModel);
            ActivateItem(loginViewModel);
        }
    }
}
