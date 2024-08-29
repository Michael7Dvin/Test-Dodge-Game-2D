using _Codebase.Gameplay.Services.DeathService;
using _Codebase.Gameplay.Services.ProjectileSpawner;
using _Codebase.Infrastructure.Bootstrappers;
using _Codebase.Infrastructure.Factories.CameraFactory;
using _Codebase.Infrastructure.Factories.HeroFactory;
using _Codebase.Infrastructure.Factories.ProjectileFactory;
using _Codebase.Infrastructure.Providers.CameraProvider;
using _Codebase.Infrastructure.Providers.HeroProvider;
using _Codebase.Infrastructure.StateMachine.States;
using Zenject;

namespace _Codebase.Infrastructure.Installers
{
    public class ForestLevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStates();
            BindFactories();
            BindProviders();
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

        private void BindFactories()
        {
            Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
            Container.Bind<ICameraFactory>().To<CameraFactory>().AsSingle();
            Container.Bind<IProjectileFactory>().To<ProjectileFactory>().AsSingle();
        }

        private void BindProviders()
        {
            Container.Bind<IHeroProvider>().To<HeroProvider>().AsSingle();
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<IDeathService>().To<DeathService>().AsSingle();
            Container.Bind<IProjectileSpawner>().To<ProjectileSpawner>().AsSingle();
        }

        private void BindBootstrapper()
        {
            Container.BindInterfacesTo<ForestLevelBootstrapper>().AsSingle();
        }
    }
}