using _Codebase.Infrastructure.Services.AddressablesLoader;
using _Codebase.Infrastructure.Services.SceneLoader;
using _Codebase.Infrastructure.StateMachine;
using _Codebase.Infrastructure.StateMachine.States;
using Zenject;

namespace _Codebase.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameStateMachine();
            BindServices();
        }
        
        private void BindGameStateMachine()
        {
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
            Container.Bind<InitializationState>().AsSingle();
            Container.Bind<SceneLoadingState>().AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<IAddressablesLoader>().To<AddressablesLoader>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }
    }
}