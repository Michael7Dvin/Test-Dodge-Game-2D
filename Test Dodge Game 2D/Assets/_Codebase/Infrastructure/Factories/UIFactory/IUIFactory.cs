using Cysharp.Threading.Tasks;

namespace _Codebase.Infrastructure.Factories.UIFactory
{
    public interface IUIFactory
    {
        UniTask WarmUpAsync();
        void CreateCanvas();
        void CreateEventSystem();
        void CreateScoreCounter();
    }
}