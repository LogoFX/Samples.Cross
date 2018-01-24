using Caliburn.Micro;
using Samples.Cross.Model.Contracts;

#if NETSTANDARD2_0
namespace Samples.Cross.Forms.Presentation.Shell.ViewModels
#elif NET
namespace Samples.Cross.WPF.Presentation.Shell.ViewModels
#endif
{
    public class ShellViewModel : Conductor<object>.Collection.OneActive
    {
        private readonly ILoginService _loginService;
        private readonly IDataService _dataService;

        public ShellViewModel(
            ILoginService loginService,
            IDataService dataService)
        {            
            _loginService = loginService;
            _dataService = dataService;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            //TODO: Use View Model factory
            var loginViewModel = new LoginViewModel(_loginService);
            var mainViewModel = new MainViewModel(_dataService);
            Items.Add(loginViewModel);
            Items.Add(mainViewModel);
            ActivateItem(loginViewModel);
        }
    }
}
