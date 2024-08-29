using _Codebase.Gameplay.Services.DeathService;
using _Codebase.Gameplay.Services.ProjectileSpawner;
using _Codebase.Infrastructure.StateMachine.States.Base;

namespace _Codebase.Infrastructure.StateMachine.States
{
    public class GameplayState : IState
    {
        private readonly IDeathService _deathService;
        private readonly IProjectileSpawner _projectileSpawner;

        public GameplayState(IDeathService deathService, IProjectileSpawner projectileSpawner)
        {
            _deathService = deathService;
            _projectileSpawner = projectileSpawner;
        }

        public void Enter()
        {
            _deathService.Initialize();
            _projectileSpawner.Enable();
        }

        public void Exit()
        {
            _projectileSpawner.Disable();
        }
    }
}