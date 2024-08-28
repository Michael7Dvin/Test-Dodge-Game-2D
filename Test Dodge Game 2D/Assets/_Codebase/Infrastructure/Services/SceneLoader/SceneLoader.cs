using _Codebase.Infrastructure.Services.AddressablesLoader;
using _Codebase.StaticData;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace _Codebase.Infrastructure.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        private readonly IAddressablesLoader _addressablesLoader;
        private readonly ScenesAddresses _scenes;

        public SceneLoader(IAddressablesLoader addressablesLoader, ScenesAddresses scenes)
        {
            _addressablesLoader = addressablesLoader;
            _scenes = scenes;
        }

        public Scene CurrentScene { get; private set; }

        public async UniTask LoadAsync(SceneID id)
        {
            switch (id)
            {
                case SceneID.Forest:
                    await LoadAsync(_scenes.Forest);
                    break;
                default:
                    Debug.LogError($"Unable to load scene. Unsupported {nameof(SceneID)}: '{id}'");
                    break;
            }    
        }

        private async UniTask LoadAsync(AssetReference sceneReference)
        {
            CurrentScene = await _addressablesLoader.LoadSceneAsync(sceneReference);
            Debug.Log($"Scene loaded: '{CurrentScene.name}'");
        }
    }
}