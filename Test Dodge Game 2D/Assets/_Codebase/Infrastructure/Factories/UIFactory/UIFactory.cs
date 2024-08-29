using _Codebase.Infrastructure.Providers.UIProvider;
using _Codebase.Infrastructure.Services.AddressablesLoader;
using _Codebase.StaticData;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace _Codebase.Infrastructure.Factories.UIFactory
{
    public class UIFactory : IUIFactory
    {
        private readonly IAddressablesLoader _addressablesLoader;
        private readonly PrefabAddresses _prefabAddresses;
        private readonly IUIProvider _uiProvider;
        private readonly IInstantiator _instantiator;

        private GameObject _canvasPrefab;
        private GameObject _eventSystemPrefab;
        
        public UIFactory(IAddressablesLoader addressablesLoader,
            IInstantiator instantiator,
            PrefabAddresses prefabAddresses,
            IUIProvider uiProvider)
        {
            _addressablesLoader = addressablesLoader;
            _instantiator = instantiator;
            _prefabAddresses = prefabAddresses;
            _uiProvider = uiProvider;
        }

        public async UniTask WarmUpAsync()
        {
            _canvasPrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Canvas);
            _eventSystemPrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.EventSystem);
        }

        public void CreateCanvas()
        {
            ValidateWarmUpping().Forget();
            
            GameObject canvasGameObject  = _instantiator.InstantiatePrefab(_canvasPrefab);

            Canvas canvas = canvasGameObject.GetComponent<Canvas>();
            _uiProvider.SetCanvas(canvas);
        }

        public void CreateEventSystem()
        {
            ValidateWarmUpping().Forget();
            
            GameObject eventSystemGameObject = _instantiator.InstantiatePrefab(_eventSystemPrefab);
            
            EventSystem eventSystem = eventSystemGameObject.GetComponent<EventSystem>();
            _uiProvider.SetEventSystem(eventSystem);
        }
        
        private async UniTaskVoid ValidateWarmUpping()
        {
            if (_canvasPrefab == null || _eventSystemPrefab == null)
            {
                Debug.LogError($"{nameof(HeroFactory)} is not warmed up. Call {nameof(WarmUpAsync)} before using factory.");
                await WarmUpAsync();
            }
        }
    }
}