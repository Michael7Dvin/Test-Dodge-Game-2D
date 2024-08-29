using _Codebase.Infrastructure.Factories.CameraFactory;
using _Codebase.Infrastructure.Factories.HeroFactory;
using _Codebase.Infrastructure.Factories.ProjectileFactory;
using _Codebase.Infrastructure.Factories.UIFactory;
using _Codebase.Infrastructure.Factories.WindowFactory;
using _Codebase.Infrastructure.Services.ProjectilePool;
using _Codebase.Infrastructure.StateMachine.States.Base;
using Cysharp.Threading.Tasks;

namespace _Codebase.Infrastructure.StateMachine.States
{
    public class WorldSpawningState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IHeroFactory _heroFactory;
        private readonly ICameraFactory _cameraFactory;
        private readonly IUIFactory _uiFactory;
        private readonly IWindowFactory _windowFactory;
        private readonly IProjectileFactory _projectileFactory;
        private readonly IProjectilePool _projectilePool;

        public WorldSpawningState(IGameStateMachine gameStateMachine,
            IHeroFactory heroFactory,
            IProjectileFactory projectileFactory,
            IProjectilePool projectilePool,
            ICameraFactory cameraFactory,
            IUIFactory uiFactory,
            IWindowFactory windowFactory)
        {
            _gameStateMachine = gameStateMachine;
            _heroFactory = heroFactory;
            _projectileFactory = projectileFactory;
            _projectilePool = projectilePool;
            _cameraFactory = cameraFactory;
            _uiFactory = uiFactory;
            _windowFactory = windowFactory;
        }

        public async void Enter()
        {
            await WarmUpFactories();

            _projectilePool.Initialize();
            
            _heroFactory.Create();
            _cameraFactory.Create();
            
            _uiFactory.CreateCanvas();
            _uiFactory.CreateEventSystem();
            _uiFactory.CreateScoreCounter();
            
            _gameStateMachine.EnterState<GameplayState>();
        }

        private async UniTask WarmUpFactories()
        {
            UniTask heroFactoryWarmUp = _heroFactory.WarmUpAsync();
            UniTask projectileFactoryWarmUp = _projectileFactory.WarmUpAsync();
            UniTask cameraFactoryWarmUp = _cameraFactory.WarmUpAsync();
            UniTask uiFactoryWarmUp = _uiFactory.WarmUpAsync();
            UniTask windowFactoryWarmUp = _windowFactory.WarmUpAsync();
            
            await UniTask.WhenAll(heroFactoryWarmUp,
                projectileFactoryWarmUp,
                cameraFactoryWarmUp,
                uiFactoryWarmUp,
                windowFactoryWarmUp);
        }
    }
}