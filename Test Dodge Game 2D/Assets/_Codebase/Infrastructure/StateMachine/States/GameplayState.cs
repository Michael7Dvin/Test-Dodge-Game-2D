using _Codebase.Gameplay.Services.DeathService;
using _Codebase.Gameplay.Services.ProjectileSpawner;
using _Codebase.Gameplay.Services.ScoreService;
using _Codebase.Infrastructure.Providers.UIProvider;
using _Codebase.Infrastructure.StateMachine.States.Base;

namespace _Codebase.Infrastructure.StateMachine.States
{
    public class GameplayState : IState
    {
        private readonly IDeathService _deathService;
        private readonly IProjectileSpawner _projectileSpawner;
        private readonly IScoreService _scoreService;
        private readonly IUIProvider _uiProvider;

        public GameplayState(IDeathService deathService,
            IProjectileSpawner projectileSpawner,
            IScoreService scoreService,
            IUIProvider uiProvider)
        {
            _deathService = deathService;
            _projectileSpawner = projectileSpawner;
            _scoreService = scoreService;
            _uiProvider = uiProvider;
        }

        public void Enter()
        {
            _deathService.Initialize();
            _projectileSpawner.Enable();
            _scoreService.Enable();
            
            _uiProvider.ScoreCounter.Initialize();
        }

        public void Exit()
        {
            _projectileSpawner.Disable();
            _scoreService.Disable();
        }
    }
}