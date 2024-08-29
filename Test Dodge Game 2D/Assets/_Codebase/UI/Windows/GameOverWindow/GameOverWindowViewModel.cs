using _Codebase.Gameplay.Services.ScoreService;
using _Codebase.Infrastructure.StateMachine;
using _Codebase.Infrastructure.StateMachine.States;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Codebase.UI.Windows.GameOverWindow
{
    [RequireComponent(typeof(GameOverWindowView))]
    public class GameOverWindowViewModel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _score;

        private IGameStateMachine _gameStateMachine;
        private IScoreService _scoreService;
        
        public GameOverWindowView View { get; private set; }

        [Inject]
        public void InjectServices(IGameStateMachine gameStateMachine, IScoreService scoreService)
        {
            _gameStateMachine = gameStateMachine;
            _scoreService = scoreService;
        }
        
        private void Awake()
        {
            View = GetComponent<GameOverWindowView>();
            View.Shown += OnViewShown;
        }

        private void OnDestroy() => 
            View.Shown -= OnViewShown;

        public void Restart() => 
            _gameStateMachine.EnterState<RestartState>();

        private void OnViewShown() => 
            _score.text = _scoreService.CurrentScore.Value.ToString();
    }
}