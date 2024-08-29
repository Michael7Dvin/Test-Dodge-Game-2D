using _Codebase.Gameplay.Services.ScoreService;
using _Codebase.Infrastructure.Providers.HeroProvider;
using _Codebase.Infrastructure.StateMachine.States.Base;
using _Codebase.StaticData;
using _Codebase.UI.Services.WindowService;
using _Codebase.UI.Windows.Base;

namespace _Codebase.Infrastructure.StateMachine.States
{
    public class RestartState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IScoreService _scoreService;
        private readonly IWindowService _windowService;
        private readonly IHeroProvider _heroProvider;
        private readonly HeroConfig _heroConfig;

        public RestartState(IGameStateMachine gameStateMachine,
            IScoreService scoreService,
            IWindowService windowService,
            IHeroProvider heroProvider,
            HeroConfig heroConfig)
        {
            _gameStateMachine = gameStateMachine;
            _scoreService = scoreService;
            _windowService = windowService;
            _heroProvider = heroProvider;
            _heroConfig = heroConfig;
        }

        public void Enter()
        {
            _scoreService.Reset();
            _windowService.HideWindow(WindowID.GameOverWindow);
            _heroProvider.Hero.Transform.position = _heroConfig.SpawnPoint;
            _heroProvider.Hero.Health.Revive();
            _heroProvider.Hero.Mover.Enabled = true;
            
            _gameStateMachine.EnterState<GameplayState>();
        }
    }
}