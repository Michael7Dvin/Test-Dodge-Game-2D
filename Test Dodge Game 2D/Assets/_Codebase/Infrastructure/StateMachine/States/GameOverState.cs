using _Codebase.Infrastructure.Providers.HeroProvider;
using _Codebase.Infrastructure.StateMachine.States.Base;
using _Codebase.UI.Services.WindowService;
using _Codebase.UI.Windows.Base;

namespace _Codebase.Infrastructure.StateMachine.States
{
    public class GameOverState : IState
    {
        private readonly IWindowService _windowService;
        private readonly IHeroProvider _heroProvider;

        public GameOverState(IWindowService windowService, IHeroProvider heroProvider)
        {
            _windowService = windowService;
            _heroProvider = heroProvider;
        }

        public void Enter()
        {
            _heroProvider.Hero.Mover.Enabled = false;
            _windowService.ShowWindow(WindowID.GameOverWindow);
        }

        public void Exit()
        {
            _windowService.HideWindow(WindowID.GameOverWindow);
        }
    }
}