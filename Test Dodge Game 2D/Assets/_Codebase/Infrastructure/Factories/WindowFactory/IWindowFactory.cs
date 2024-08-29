using _Codebase.UI.Windows.Base;
using Cysharp.Threading.Tasks;

namespace _Codebase.Infrastructure.Factories.WindowFactory
{
    public interface IWindowFactory
    {
        UniTask WarmUpAsync();
        BaseWindowView CreateGameOverWindow();
    }
}