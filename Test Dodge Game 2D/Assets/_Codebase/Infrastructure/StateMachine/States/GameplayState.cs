using _Codebase.Gameplay.Services.DeathService;
using _Codebase.Infrastructure.StateMachine.States.Base;

namespace _Codebase.Infrastructure.StateMachine.States
{
    public class GameplayState : IState
    {
        private readonly IDeathService _deathService;

        public GameplayState(IDeathService deathService)
        {
            _deathService = deathService;
        }

        public void Enter()
        {
            _deathService.Enable();
        }
    }
}