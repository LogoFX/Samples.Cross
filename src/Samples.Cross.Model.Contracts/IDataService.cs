using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samples.Cross.Model.Contracts
{
    public interface IDataService
    {
        IEnumerable<IWiFiNetwork> WiFiNetworks { get; }

        Task GetNetworks();

        Task Connect(IWiFiNetwork network);

        Task Disconnect(IWiFiNetwork network);

        Task Forget(IWiFiNetwork network);

        Task Restore(IWiFiNetwork network);
    }
}
