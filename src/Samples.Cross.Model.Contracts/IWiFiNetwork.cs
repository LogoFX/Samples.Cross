using LogoFX.Client.Mvvm.Model.Contracts;

namespace Samples.Cross.Model.Contracts
{
    public interface IWiFiNetwork : IModel<string>
    {
        ConnectionStatus IsConnected { get; set; }
        bool IsEnabled { get; set; }
    }

    public enum ConnectionStatus
    {
        Disconnected = 0,
        Connected = 1,
        Error = 2
    }
}
