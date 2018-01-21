using Caliburn.Micro;
using Samples.Cross.Model.Contracts;

namespace Samples.Cross.WPF.Presentation.Shell.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private readonly ILoginService _loginService;

        public ShellViewModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            _loginService.LoginAsync("username", "pass");
        }
    }
}
