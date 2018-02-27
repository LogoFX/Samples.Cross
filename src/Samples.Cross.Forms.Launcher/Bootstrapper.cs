using Samples.Cross.Forms.Infra;
using Solid.Practices.IoC;

namespace Samples.Cross.Forms.Launcher
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper(IDependencyRegistrator dependencyRegistrator)
            : base(dependencyRegistrator)
        {

        }

        public override string[] Prefixes
        {
            get
            {
                return new[] { "Samples.Cross" };
            }
        }
    }
}
