using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace _Codebase.Infrastructure.Services.SceneLoader
{
    public interface ISceneLoader
    {
        Scene CurrentScene { get; }
        UniTask Load(SceneID id);
    }
}