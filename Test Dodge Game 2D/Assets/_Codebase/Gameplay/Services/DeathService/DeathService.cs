using System;
using _Codebase.Gameplay.Heroes;
using _Codebase.Gameplay.Services.HeroProvider;
using _Codebase.Infrastructure.StateMachine;
using _Codebase.Infrastructure.StateMachine.States;

namespace _Codebase.Gameplay.Services.DeathService
{
    public class DeathService : IDeathService, IDisposable
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IHeroProvider _heroProvider;

        private Hero _hero;

        public DeathService(IGameStateMachine gameStateMachine, IHeroProvider heroProvider)
        {
            _gameStateMachine = gameStateMachine;
            _heroProvider = heroProvider;
        }

        public void Enable()
        {
            _hero = _heroProvider.Hero;
            _hero.Health.Died += EnterGameOverState;
        }

        private void EnterGameOverState()
        {
            _hero.Health.Died -= EnterGameOverState;
            _gameStateMachine.EnterState<GameOverState>();
        }

        public void Dispose() => 
            _hero.Health.Died -= EnterGameOverState;
    }
}