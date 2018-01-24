using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogoFX.Core;
using Samples.Cross.Data.Contracts.Providers;
using Samples.Cross.Model.Contracts;

namespace Samples.Cross.Model
{
    public class DataService : IDataService
    {
        private readonly object _syncObject = new object();

        private readonly INetworksProvider _wifiNetworksProvider;

        private RangeObservableCollection<IWiFiNetwork> _wifiNetworks = new RangeObservableCollection<IWiFiNetwork>();
        RangeObservableCollection<IWiFiNetwork> WiFiNetworks => _wifiNetworks;
        IEnumerable<IWiFiNetwork> IDataService.WiFiNetworks => WiFiNetworks;

        public DataService(INetworksProvider wifiNetworksProvider)
        {
            _wifiNetworksProvider = wifiNetworksProvider;
        }

        async Task IDataService.GetNetworks()
        {
            await ServiceRunner.RunAsync((Action)GetNetworksImpl);
        }

        private void GetNetworksImpl()
        {
            lock (_syncObject)
            {
                _wifiNetworks.Clear();
                _wifiNetworks.AddRange(_wifiNetworksProvider.GetWiFiNetworks().Select(t => new WiFiNetwork(t)));
            }
        }

        async Task IDataService.Connect(IWiFiNetwork network)
        {
            if (_wifiNetworks.Contains(network) == false)
            {
                throw new Exception($"Unknown network {network}");
            }

            if (network.IsConnected == ConnectionStatus.Connected)
            {
                return;
            }

            await ServiceRunner.RunAsync(() =>
            {
                try
                {
                    _wifiNetworksProvider.Connect(network.Name);
                    var currentConnection = _wifiNetworks.FirstOrDefault(t => t.IsConnected == ConnectionStatus.Connected);
                    if (currentConnection != null)
                    {
                        DisconnectImpl(currentConnection);
                    }
                    network.IsConnected = ConnectionStatus.Connected;
                }
                catch (Exception)
                {
                    network.IsConnected = ConnectionStatus.Error;
                }
            });
        }

        async Task IDataService.Disconnect(IWiFiNetwork network)
        {
            if (_wifiNetworks.Contains(network) == false)
            {
                throw new Exception($"Unknown network {network}");
            }

            if (network.IsConnected == ConnectionStatus.Disconnected)
            {
                return;
            }

            await ServiceRunner.RunAsync(() => DisconnectImpl(network));
        }

        private void DisconnectImpl(IWiFiNetwork network)
        {
            try
            {
                _wifiNetworksProvider.Disconnect(network.Name);
                network.IsConnected = ConnectionStatus.Disconnected;
            }
            catch (Exception)
            {
                network.IsConnected = ConnectionStatus.Error;
            }
        }

        async Task IDataService.Forget(IWiFiNetwork network)
        {
            await ServiceRunner.RunAsync(() =>
            {
                if (_wifiNetworks.Contains(network) == false)
                {
                    throw new Exception($"Unknown network {network}");
                }

                if (network.IsConnected == ConnectionStatus.Connected)
                {
                    DisconnectImpl(network);
                }
                network.IsEnabled = false;
            });
        }

        async Task IDataService.Restore(IWiFiNetwork network)
        {
            await ServiceRunner.RunAsync(() =>
            {
                network.IsEnabled = true;
            });
        }
    }
}
