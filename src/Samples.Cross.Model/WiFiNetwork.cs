using Samples.Cross.Model.Contracts;

namespace Samples.Cross.Model
{
    public class WiFiNetwork : LogoFX.Client.Mvvm.Model.Model<string>, IWiFiNetwork
    {
        public WiFiNetwork(string name)
        {
            Id = name;
            Name = name;
            IsConnected = ConnectionStatus.Disconnected;
            IsEnabled = true;
        }

        private ConnectionStatus _isConnected;
        public ConnectionStatus IsConnected
        {
            get => _isConnected;
            set
            {
                if (value == _isConnected)
                {
                    return;
                }
                _isConnected = value;
                NotifyOfPropertyChange();
            }
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (value == _isEnabled)
                {
                    return;
                }
                _isEnabled = value;
                NotifyOfPropertyChange();
            }
        }
    }
}
