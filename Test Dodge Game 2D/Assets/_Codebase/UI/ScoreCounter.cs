using _Codebase.Gameplay.Services.ScoreService;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Codebase.UI
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counter;
        
        private IScoreService _scoreService;

        [Inject]
        public void InjectServices(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        public void Initialize()
        {
            _scoreService.CurrentScore
                .Subscribe(score => _counter.text = score.ToString())
                .AddTo(this);
        }
    }
}