using Samples.Cross.Data.Contracts.Providers;

namespace Samples.Cross.Data.Fake.Providers
{
    public class FakeNetworksProvider : INetworksProvider
    {
        void INetworksProvider.Connect(string name)
        {
            var parts = name.Split(new[] { ' ' });
            var index = int.Parse(parts[1]);
            if (index > 25)
            {
                return;
            }
            else
            {
                throw new System.Exception($"Can't connect to network {name}");
            }
        }

        void INetworksProvider.Disconnect(string name)
        {
            var parts = name.Split(new[] { ' ' });
            var index = int.Parse(parts[1]);
            if (index > 25)
            {
                return;
            }
            else
            {
                throw new System.Exception($"Can't disconnect from network {name}");
            }
        }

        string[] INetworksProvider.GetWiFiNetworks()
        {
            return new[] {
                "Wifi 10",
                "Wifi 20",
                "Wifi 30",
                "Wifi 40",
                "Wifi 50",
            };
        }
    }
}
