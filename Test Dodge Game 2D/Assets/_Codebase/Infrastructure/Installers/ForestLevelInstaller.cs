﻿using _Codebase.Gameplay.Services.DeathService;
using _Codebase.Gameplay.Services.ProjectileSpawner;
using _Codebase.Gameplay.Services.ScoreService;
using _Codebase.Infrastructure.Bootstrappers;
using _Codebase.Infrastructure.Factories.CameraFactory;
using _Codebase.Infrastructure.Factories.HeroFactory;
using _Codebase.Infrastructure.Factories.ProjectileFactory;
using _Codebase.Infrastructure.Factories.UIFactory;
using _Codebase.Infrastructure.Factories.WindowFactory;
using _Codebase.Infrastructure.Providers.CameraProvider;
using _Codebase.Infrastructure.Providers.HeroProvider;
using _Codebase.Infrastructure.Providers.UIProvider;
using _Codebase.Infrastructure.Services.ProjectilePool;
using _Codebase.Infrastructure.StateMachine.States;
using _Codebase.UI.Services.WindowService;
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
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
            Container.Bind<IWindowFactory>().To<WindowFactory>().AsSingle();
        }

        private void BindProviders()
        {
            Container.Bind<IHeroProvider>().To<HeroProvider>().AsSingle();
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
            Container.Bind<IUIProvider>().To<UIProvider>().AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<IDeathService>().To<DeathService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ProjectileSpawner>().AsSingle();
            Container.Bind<IProjectilePool>().To<ProjectilePool>().AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreService>().AsSingle();
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
        }

        private void BindBootstrapper()
        {
            Container.BindInterfacesTo<ForestLevelBootstrapper>().AsSingle();
        }
    }
}