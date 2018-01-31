using Samples.Cross.Shared;
using Solid.Practices.IoC;

namespace Samples.Cross.Forms.Launcher
{
    public class Bridge
    {
        public static void Initialize()
        {
            ContainerContext.Registrator
                .AddInstance(ContainerContext.Registrator)
                .AddSingleton<FormsApp>();            
        }
    }
}