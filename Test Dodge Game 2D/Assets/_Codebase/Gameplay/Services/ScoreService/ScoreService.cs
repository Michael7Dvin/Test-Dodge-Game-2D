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

        public ScoreService(ScoreServiceConfig config)
        {
            _config = config;
        }

        public int CurrentScore { get; private set; }

        public void Enable()
        {
            Observable.Interval(TimeSpan.FromSeconds(_config.ScoreAccrualIntervalInSeconds))
                .Subscribe(_ => AccrueScore())
                .AddTo(_compositeDisposable);
        }

        public void Disable() => 
            _compositeDisposable.Clear();

        public void Reset() => 
            CurrentScore = 0;

        public void Dispose() => 
            _compositeDisposable?.Dispose();

        private void AccrueScore()
        {
            CurrentScore += _config.ScorePerSecond;
            Debug.Log(CurrentScore);
        }
    }
}