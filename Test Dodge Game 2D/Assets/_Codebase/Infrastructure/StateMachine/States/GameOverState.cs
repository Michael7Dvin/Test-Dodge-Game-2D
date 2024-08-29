using _Codebase.Infrastructure.StateMachine.States.Base;
using _Codebase.UI.Services.WindowService;
using _Codebase.UI.Windows.Base;

namespace _Codebase.Infrastructure.StateMachine.States
{
    public class GameOverState : IState
    {
        private readonly IWindowService _windowService;

        public GameOverState(IWindowService windowService)
        {
            _windowService = windowService;
        }

        public void Enter()
        {
            _windowService.ShowWindow(WindowID.GameOverWindow);
        }

        public void Exit()
        {
            _windowService.HideWindow(WindowID.GameOverWindow);
        }
    }
}