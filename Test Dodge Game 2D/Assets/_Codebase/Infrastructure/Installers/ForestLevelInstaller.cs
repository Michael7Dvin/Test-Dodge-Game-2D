using _Codebase.Gameplay.Services.DeathService;
using _Codebase.Infrastructure.Bootstrappers;
using _Codebase.Infrastructure.Services.HeroFactory;
using _Codebase.Infrastructure.Services.HeroProvider;
using _Codebase.Infrastructure.StateMachine.States;
using Zenject;

namespace _Codebase.Infrastructure.Installers
{
    public class ForestLevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStates();
            BindServices();
            BindBootstrapper();
        }

        private void BindStates()
        {
            Container.Bind<WorldSpawningState>().AsSingle();
            Container.Bind<GameplayState>().AsSingle();
            Container.Bind<GameOverState>().AsSingle();
            Container.Bind<RestartState>().AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
            Container.Bind<IHeroProvider>().To<HeroProvider>().AsSingle();
            Container.Bind<IDeathService>().To<DeathService>().AsSingle();
        }

        private void BindBootstrapper()
        {
            Container.BindInterfacesTo<ForestLevelBootstrapper>().AsSingle();
        }
    }
}