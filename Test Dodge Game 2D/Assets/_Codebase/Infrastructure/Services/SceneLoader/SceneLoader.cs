using _Codebase.Infrastructure.Services.AddressablesLoader;
using _CodeBase.StaticData;
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

        public async UniTask Load(SceneID id)
        {
            switch (id)
            {
                case SceneID.Forest:
                    await Load(_scenes.Forest);
                    break;
                default:
                    Debug.LogError($"Unable to load scene. Unsupported {nameof(SceneID)}: '{id}'");
                    break;
            }    
        }

        private async UniTask Load(AssetReference sceneReference)
        {
            CurrentScene = await _addressablesLoader.LoadSceneAsync(sceneReference);
            Debug.Log($"Scene loaded: '{CurrentScene.name}'");
        }
    }
}