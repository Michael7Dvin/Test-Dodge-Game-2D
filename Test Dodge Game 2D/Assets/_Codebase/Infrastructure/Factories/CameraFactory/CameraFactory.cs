using _Codebase.Infrastructure.Providers.CameraProvider;
using _Codebase.Infrastructure.Providers.HeroProvider;
using _Codebase.Infrastructure.Services.AddressablesLoader;
using _Codebase.StaticData;
using Cinemachine;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Codebase.Infrastructure.Factories.CameraFactory
{
    public class CameraFactory : ICameraFactory
    {
        private readonly IAddressablesLoader _addressablesLoader;
        private readonly IInstantiator _instantiator;
        private readonly PrefabAddresses _prefabAddresses;
        private readonly IHeroProvider _heroProvider;
        private readonly ICameraProvider _cameraProvider;
        
        private GameObject _cameraPrefab;

        public CameraFactory(IAddressablesLoader addressablesLoader,
            IInstantiator instantiator,
            PrefabAddresses prefabAddresses,
            IHeroProvider heroProvider,
            ICameraProvider cameraProvider)
        {
            _addressablesLoader = addressablesLoader;
            _instantiator = instantiator;
            _prefabAddresses = prefabAddresses;
            _heroProvider = heroProvider;
            _cameraProvider = cameraProvider;
        }

        public async UniTask WarmUpAsync() => 
            _cameraPrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Camera);

        public Camera Create()
        {
            ValidateWarmUpping().Forget();
            
            GameObject cameraGameObject = _instantiator.InstantiatePrefab(_cameraPrefab);

            Camera camera = cameraGameObject.GetComponentInChildren<Camera>();
            
            CinemachineVirtualCamera virtualCamera = cameraGameObject.GetComponentInChildren<CinemachineVirtualCamera>();
            
            Transform heroTransform = _heroProvider.Hero.Transform;
            virtualCamera.Follow = heroTransform;
            virtualCamera.LookAt = heroTransform;

            _cameraProvider.SetCamera(camera);
            
            return camera;
        }
        
        private async UniTaskVoid ValidateWarmUpping()
        {
            if (_cameraPrefab == null)
            {
                Debug.LogError($"{nameof(CameraFactory)} is not warmed up. Call {nameof(WarmUpAsync)} before {nameof(Create)}.");
                await WarmUpAsync();
            }
        }
    }
}