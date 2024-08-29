namespace _Codebase.Gameplay.Services.ScoreService
{
    public interface IScoreService
    {
        int CurrentScore { get; }
        
        void Enable();
        void Disable();
        void Reset();
    }
}