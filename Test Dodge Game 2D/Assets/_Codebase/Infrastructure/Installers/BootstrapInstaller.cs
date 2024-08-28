using _Codebase.Infrastructure.Bootstrappers;
using Zenject;

namespace _Codebase.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindBootstrapper();
        }

        private void BindBootstrapper()
        {
            Container.BindInterfacesTo<AppBootstrapper>().AsSingle();
        }
    }
}