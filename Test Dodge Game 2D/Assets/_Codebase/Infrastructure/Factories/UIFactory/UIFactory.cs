using _Codebase.Infrastructure.Providers.UIProvider;
using _Codebase.Infrastructure.Services.AddressablesLoader;
using _Codebase.StaticData;
using _Codebase.UI.Score;
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
        private GameObject _scoreCounterPrefab;

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

        private Transform CanvasTransform => _uiProvider.Canvas.transform;

        public async UniTask WarmUpAsync()
        {
            _canvasPrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Canvas);
            _eventSystemPrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.EventSystem);
            _scoreCounterPrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.ScoreCounter);
        }

        public void CreateCanvas()
        {
            ValidateWarmUpping().Forget();
            
            GameObject canvasGameObject  = _instantiator.InstantiatePrefab(_canvasPrefab);

            Canvas canvas = canvasGameObject.GetComponent<Canvas>();
            _uiProvider.Canvas = canvas;
        }

        public void CreateEventSystem()
        {
            ValidateWarmUpping().Forget();
            
            GameObject eventSystemGameObject = _instantiator.InstantiatePrefab(_eventSystemPrefab);
            
            EventSystem eventSystem = eventSystemGameObject.GetComponent<EventSystem>();
            _uiProvider.EventSystem = eventSystem;
        }

        public void CreateScoreCounter()
        {
            ValidateWarmUpping().Forget();
            
            ScoreCounter scoreCounter = _instantiator.InstantiatePrefabForComponent<ScoreCounter>(_scoreCounterPrefab, CanvasTransform);
            _uiProvider.ScoreCounter = scoreCounter;
        }

        private async UniTaskVoid ValidateWarmUpping()
        {
            if (_canvasPrefab == null || _eventSystemPrefab == null || _scoreCounterPrefab == null)
            {
                Debug.LogError($"{nameof(UIFactory)} is not warmed up. Call {nameof(WarmUpAsync)} before using factory.");
                await WarmUpAsync();
            }
        }
    }
}