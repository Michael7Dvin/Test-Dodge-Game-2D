using UniRx;

namespace _Codebase.Gameplay.Services.ScoreService
{
    public interface IScoreService
    {
        IReadOnlyReactiveProperty<int> CurrentScore { get; }
        
        void Enable();
        void Disable();
        void Reset();
    }
}