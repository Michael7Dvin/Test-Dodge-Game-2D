using System;
using _Codebase.Gameplay.Heroes;
using _Codebase.Infrastructure.Providers.HeroProvider;
using _Codebase.Infrastructure.StateMachine;
using _Codebase.Infrastructure.StateMachine.States;
using UniRx;
using UnityEngine;

namespace _Codebase.Gameplay.Services.DeathService
{
    public class DeathService : IDeathService, IDisposable
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IHeroProvider _heroProvider;

        private readonly CompositeDisposable _compositeDisposable = new();
        
        private Hero _hero;

        public DeathService(IGameStateMachine gameStateMachine, IHeroProvider heroProvider)
        {
            _gameStateMachine = gameStateMachine;
            _heroProvider = heroProvider;
        }

        public void Initialize()
        {
            _hero = _heroProvider.Hero;
            _hero.Health.IsDead
                .Where(isDead => isDead == true)
                .Subscribe(_ => _gameStateMachine.EnterState<GameOverState>())
                .AddTo(_compositeDisposable);
        }

        public void Dispose() =>
            _compositeDisposable.Dispose();
    }
}