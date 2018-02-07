using System.Collections;
using System.Windows.Input;
using Caliburn.Micro;
using LogoFX.Client.Mvvm.Commanding;
using LogoFX.Client.Mvvm.ViewModel;
using LogoFX.Client.Mvvm.ViewModel.Services;
using Samples.Cross.Model.Contracts;

#if NETSTANDARD2_0
namespace Samples.Cross.Forms.Presentation.Shell.ViewModels
#elif NET
namespace Samples.Cross.WPF.Presentation.Shell.ViewModels
#endif
{
    public class MainViewModel : Screen
    {
        private readonly IDataService _dataService;
        private readonly IViewModelCreatorService _viewModelCreatorService;

        public MainViewModel(
            IDataService dataService,
            IViewModelCreatorService viewModelCreatorService)
        {
            _dataService = dataService;
            _viewModelCreatorService = viewModelCreatorService;
            DisplayName = "Main";
        }

        private WrappingCollection _wifiNetworks;
        public IEnumerable WiFiNetworks => _wifiNetworks ?? (_wifiNetworks = CreateWiFiNetworks());

        private WrappingCollection CreateWiFiNetworks()
        {
            var wc = new WrappingCollection.WithSelection(SelectionMode.ZeroOrOne)
            {
                FactoryMethod = arg => _viewModelCreatorService.CreateViewModel<IWiFiNetwork, WiFiObjectViewModel>(arg as IWiFiNetwork)
            };
            wc.AddSource(_dataService.WiFiNetworks);
            return wc;
        }

        private ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand = ActionCommand.When(() => SelectedItem != null &&
                                                                                SelectedItem?.Model.IsConnected != ConnectionStatus.Connected &&
                                                                                SelectedItem.Model.IsEnabled).Do(async () =>
                                                                                {
                                                                                    await _dataService.Connect(SelectedItem.Model);
                                                                                    NotifyOfPropertyChange(() => SelectedItem);
                                                                                }).RequeryOnPropertyChanged(this, () => SelectedItem).RequeryOnPropertyChanged(this, () => SelectedItem.Model.IsConnected));
            }
        }

        private ICommand _disconnectCommand;
        public ICommand DisconnectCommand
        {
            get
            {
                return _disconnectCommand ?? (_disconnectCommand = ActionCommand.When(() => SelectedItem != null &&
                                                                                      SelectedItem.Model.IsConnected == ConnectionStatus.Connected &&
                                                                                     SelectedItem.Model.IsEnabled).Do(async () =>
                                                                                     {
                                                                                         await _dataService.Disconnect(SelectedItem.Model);
                                                                                         NotifyOfPropertyChange(() => SelectedItem);
                                                                                     }).RequeryOnPropertyChanged(this, () => SelectedItem).RequeryOnPropertyChanged(this, () => SelectedItem.Model.IsConnected));
            }
        }

        private ICommand _forgetCommand;
        public ICommand ForgetCommand
        {
            get
            {
                return _forgetCommand ?? (_forgetCommand = ActionCommand.When(() => SelectedItem != null && SelectedItem.Model.IsEnabled).Do(async () =>
                {
                    await _dataService.Forget(SelectedItem.Model);
                    NotifyOfPropertyChange(() => SelectedItem);
                }).RequeryOnPropertyChanged(this, () => SelectedItem).RequeryOnPropertyChanged(this, () => SelectedItem.Model.IsEnabled));
            }
        }

        private ICommand _restoreCommand;
        public ICommand RestoreCommand
        {
            get
            {
                return _restoreCommand ?? (_restoreCommand = ActionCommand.When(() => SelectedItem != null && (SelectedItem.Model.IsEnabled == false)).Do(async () =>
                {
                    await _dataService.Restore(SelectedItem.Model);
                    NotifyOfPropertyChange(() => SelectedItem);
                }).RequeryOnPropertyChanged(this, () => SelectedItem).RequeryOnPropertyChanged(this, () => SelectedItem.Model.IsEnabled));
            }
        }

        private ICommand _clearSelectionCommand;
        public ICommand ClearSelectionCommand
        {
            get
            {
                return _clearSelectionCommand ?? (_clearSelectionCommand = ActionCommand.When(() => SelectedItem != null).Do(() =>
                {
                    SelectedItem = null;
                }).RequeryOnPropertyChanged(this, () => SelectedItem).RequeryWhenExecuted());
            }
        }

        private WiFiObjectViewModel _selectedItem;
        public WiFiObjectViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                NotifyOfPropertyChange();
            }
        }

        protected override async void OnInitialize()
        {
            base.OnInitialize();
            await _dataService.GetNetworks();                  
        }
    }

    public class WiFiObjectViewModel : ObjectViewModel<IWiFiNetwork>
    {
        public WiFiObjectViewModel(IWiFiNetwork model) : base(model)
        {
        }
    }
}
