using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace _Codebase.Infrastructure.Services.AddressablesLoader
{
    public interface IAddressablesLoader
    {
        UniTask<GameObject> LoadGameObjectAsync(AssetReferenceGameObject assetReference);
        UniTask<Scene> LoadSceneAsync(AssetReference sceneReference);
    }
}