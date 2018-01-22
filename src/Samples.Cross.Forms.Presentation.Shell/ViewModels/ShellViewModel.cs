using Caliburn.Micro;
using Samples.Cross.Model.Contracts;

namespace Samples.Cross.Forms.Presentation.Shell.ViewModels
{
    public class ShellViewModel : Conductor<object>.Collection.OneActive
    {
        private readonly ILoginService _loginService;

        public ShellViewModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            //TODO: Use View Model factory
            var loginViewModel = new LoginViewModel(_loginService);
            Items.Add(loginViewModel);
            ActivateItem(loginViewModel);
        }
    }
}
