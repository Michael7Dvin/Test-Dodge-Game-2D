using _Codebase.Infrastructure.Factories.CameraFactory;
using _Codebase.Infrastructure.Factories.HeroFactory;
using _Codebase.Infrastructure.Factories.ProjectileFactory;
using _Codebase.Infrastructure.StateMachine.States.Base;
using Cysharp.Threading.Tasks;

namespace _Codebase.Infrastructure.StateMachine.States
{
    public class WorldSpawningState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IHeroFactory _heroFactory;
        private readonly ICameraFactory _cameraFactory;
        private readonly IProjectileFactory _projectileFactory;

        public WorldSpawningState(IGameStateMachine gameStateMachine,
            IHeroFactory heroFactory,
            IProjectileFactory projectileFactory,
            ICameraFactory cameraFactory)
        {
            _gameStateMachine = gameStateMachine;
            _heroFactory = heroFactory;
            _projectileFactory = projectileFactory;
            _cameraFactory = cameraFactory;
        }

        public async void Enter()
        {
            await WarmUpFactories();

            await _heroFactory.CreateAsync();
            await _cameraFactory.CreateAsync();
            
            _gameStateMachine.EnterState<GameplayState>();
        }

        private async UniTask WarmUpFactories()
        {
            UniTask heroFactoryWarmUp = _heroFactory.WarmUpAsync();
            UniTask projectileFactoryWarmUp = _projectileFactory.WarmUpAsync();
            UniTask cameraFactoryWarmUp = _cameraFactory.WarmUpAsync();

            await UniTask.WhenAll(heroFactoryWarmUp, projectileFactoryWarmUp, cameraFactoryWarmUp);
        }
    }
}