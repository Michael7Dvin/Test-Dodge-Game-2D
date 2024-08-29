using _Codebase.Infrastructure.Providers.UIProvider;
using _Codebase.Infrastructure.Services.AddressablesLoader;
using _Codebase.StaticData;
using _Codebase.UI.Windows.Base;
using _Codebase.UI.Windows.GameOverWindow;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Codebase.Infrastructure.Factories.WindowFactory
{
    public class WindowFactory : IWindowFactory
    {
        private readonly IAddressablesLoader _addressablesLoader;
        private readonly PrefabAddresses _prefabAddresses;
        private readonly IUIProvider _uiProvider;
        private readonly IInstantiator _instantiator;

        private GameObject _gameOverWindowViewPrefab;

        public WindowFactory(IAddressablesLoader addressablesLoader,
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

        public async UniTask WarmUpAsync() => 
            _gameOverWindowViewPrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.GameOverWindowViewPrefab);

        public BaseWindowView CreateGameOverWindow()
        {
            ValidateWarmUpping().Forget();
            
            GameOverWindowViewModel gameOverWindowViewModel = 
                _instantiator.InstantiatePrefabForComponent<GameOverWindowViewModel>(_gameOverWindowViewPrefab, CanvasTransform);

            return gameOverWindowViewModel.View;
        }
        
        private async UniTaskVoid ValidateWarmUpping()
        {
            if (_gameOverWindowViewPrefab == null)
            {
                Debug.LogError($"{nameof(WindowFactory)} is not warmed up. Call {nameof(WarmUpAsync)} before using factory.");
                await WarmUpAsync();
            }
        }
    }
}