using System.Threading.Tasks;
using Samples.Cross.Model.Contracts;

namespace Samples.Cross.Model
{
    class LoginService : ILoginService
    {
        public Task LoginAsync(string username, string password)
        {
            return new TaskFactory().StartNew(() => { });
        }
    }
}
