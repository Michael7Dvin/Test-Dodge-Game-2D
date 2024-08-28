using _Codebase.Infrastructure.StateMachine;
using _Codebase.Infrastructure.StateMachine.States;
using Zenject;

namespace _Codebase.Infrastructure.Bootstrappers
{
    public class ForestLevelBootstrapper : IInitializable
    {
        private readonly IGameStateMachine _gameStateMachine;

        public ForestLevelBootstrapper(IGameStateMachine gameStateMachine,
            WorldSpawningState worldSpawningState,
            GameplayState gameplayState,
            GameOverState gameOverState,
            RestartState restartState)
        {
            _gameStateMachine = gameStateMachine;
            
            _gameStateMachine.AddState(worldSpawningState);
            _gameStateMachine.AddState(gameplayState);
            _gameStateMachine.AddState(gameOverState);
            _gameStateMachine.AddState(restartState);
        }
        
        public void Initialize()
        {
            _gameStateMachine.EnterState<WorldSpawningState>();
        }
    }
}