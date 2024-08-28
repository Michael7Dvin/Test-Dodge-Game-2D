using _Codebase.Infrastructure.Services.HeroFactory;
using _Codebase.Infrastructure.StateMachine.States.Base;

namespace _Codebase.Infrastructure.StateMachine.States
{
    public class WorldSpawningState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IHeroFactory _heroFactory;

        public WorldSpawningState(IGameStateMachine gameStateMachine, IHeroFactory heroFactory)
        {
            _gameStateMachine = gameStateMachine;
            _heroFactory = heroFactory;
        }

        public void Enter()
        {
            _heroFactory.WarmUpAsync();

            _heroFactory.CreateAsync();
            
            _gameStateMachine.EnterState<GameplayState>();
        }
    }
}