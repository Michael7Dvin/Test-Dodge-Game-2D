using System;
using _Codebase.StaticData;
using UniRx;
using UnityEngine;

namespace _Codebase.Gameplay.Services.ScoreService
{
    public class ScoreService : IScoreService, IDisposable
    {
        private readonly ScoreServiceConfig _config;
        private CompositeDisposable _compositeDisposable = new();
        
        private readonly ReactiveProperty<int> _currentScore = new();

        public ScoreService(ScoreServiceConfig config)
        {
            _config = config;
        }

        public IReadOnlyReactiveProperty<int> CurrentScore => _currentScore;

        public void Enable()
        {
            Observable.Interval(TimeSpan.FromSeconds(_config.ScoreAccrualIntervalInSeconds))
                .Subscribe(_ => AccrueScore())
                .AddTo(_compositeDisposable);
        }

        public void Disable() => 
            _compositeDisposable.Clear();

        public void Reset() => 
            _currentScore.Value = 0;

        public void Dispose() => 
            _compositeDisposable?.Dispose();

        private void AccrueScore() => 
            _currentScore.Value += _config.ScorePerSecond;
    }
}