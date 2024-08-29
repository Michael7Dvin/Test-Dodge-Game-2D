using System.Threading.Tasks;
using _Codebase.Infrastructure.Services.HeroFactory;
using _Codebase.Infrastructure.Services.ProjectileFactory;
using _Codebase.Infrastructure.StateMachine.States.Base;
using Cysharp.Threading.Tasks;

namespace _Codebase.Infrastructure.StateMachine.States
{
    public class WorldSpawningState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IHeroFactory _heroFactory;
        private readonly IProjectileFactory _projectileFactory;

        public WorldSpawningState(IGameStateMachine gameStateMachine, IHeroFactory heroFactory)
        {
            _gameStateMachine = gameStateMachine;
            _heroFactory = heroFactory;
        }

        public async void Enter()
        {
            await WarmUpFactories();

            await _heroFactory.CreateAsync();
            
            _gameStateMachine.EnterState<GameplayState>();
        }

        private async UniTask WarmUpFactories()
        {
            UniTask heroFactoryWarmUp = _heroFactory.WarmUpAsync();
            UniTask projectileFactoryWarmUp = _projectileFactory.WarmUpAsync();

            await UniTask.WhenAll(heroFactoryWarmUp, projectileFactoryWarmUp);
        }
    }
}