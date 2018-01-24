namespace Samples.Cross.Data.Contracts.Providers
{
    public interface INetworksProvider
    {
        string[] GetWiFiNetworks();
        void Connect(string name);
        void Disconnect(string name);
    }
}
