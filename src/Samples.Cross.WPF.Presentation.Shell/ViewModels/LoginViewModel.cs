using System;
using System.Windows.Input;
using Caliburn.Micro;
using LogoFX.Client.Mvvm.Commanding;
using Samples.Cross.Model.Contracts;

namespace Samples.Cross.WPF.Presentation.Shell.ViewModels
{
    class LoginViewModel : Screen
    {
        private readonly ILoginService _loginService;

        public LoginViewModel(ILoginService loginService)
        {
            _loginService = loginService;
            DisplayName = "Login View";
        }

        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                NotifyOfPropertyChange();
            }
        }

        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set
            {
                if (_password == value)
                    return;

                _password = value;
                NotifyOfPropertyChange();
            }
        }

        private ICommand _loginCommand;

        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand ??
                       (_loginCommand = ActionCommand
                           .When(() => !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password))
                           .Do(async () =>
                           {
                               LoginFailureCause = null;

                               try
                               {
                                   IsBusy = true;
                                   await _loginService.LoginAsync(UserName, Password);
                                   //TODO: improve     
                                   var conductor = (Parent as Conductor<object>.Collection.OneActive);
                                   conductor.ActivateItem(conductor.Items[1]);
                               }

                               catch (Exception ex)
                               {
                                   LoginFailureCause = "Failed to log in: " + ex.Message;
                               }

                               finally
                               {
                                   Password = string.Empty;
                                   IsBusy = false;
                               }
                           }).RequeryOnPropertyChanged(this, () => UserName)
                           .RequeryOnPropertyChanged(this, () => Password));
            }
        }

        private ICommand _cancelCommand;
        public ICommand LoginCancelCommand
        {
            get
            {
                return _cancelCommand ??
                       (_cancelCommand = ActionCommand
                           .Do(() =>
                           {
                               TryClose();
                           }));
            }
        }

        private string _loginFailureCause;
        public string LoginFailureCause
        {
            get => _loginFailureCause;
            set
            {
                if (_loginFailureCause == value)
                    return;

                _loginFailureCause = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => IsLoginFailureTextVisible);
            }
        }

        public bool IsLoginFailureTextVisible => string.IsNullOrWhiteSpace(LoginFailureCause) == false;

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy == value)
                    return;

                _isBusy = value;
                NotifyOfPropertyChange();                
            }
        }
    }
}
