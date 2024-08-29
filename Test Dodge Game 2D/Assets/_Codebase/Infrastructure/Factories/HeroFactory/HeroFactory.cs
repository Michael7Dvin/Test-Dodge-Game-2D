using _Codebase.Gameplay.Heroes;
using _Codebase.Gameplay.Heroes.Components;
using _Codebase.Infrastructure.Providers.HeroProvider;
using _Codebase.Infrastructure.Services.AddressablesLoader;
using _Codebase.StaticData;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Codebase.Infrastructure.Factories.HeroFactory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IAddressablesLoader _addressablesLoader;
        private readonly PrefabAddresses _prefabAddresses;
        private readonly IInstantiator _instantiator;
        private readonly HeroConfig _heroConfig;
        private readonly IHeroProvider _heroProvider;

        private GameObject _heroPrefab;

        public HeroFactory(IAddressablesLoader addressablesLoader,
            PrefabAddresses prefabAddresses,
            IInstantiator instantiator,
            HeroConfig heroConfig,
            IHeroProvider heroProvider)
        {
            _addressablesLoader = addressablesLoader;
            _prefabAddresses = prefabAddresses;
            _instantiator = instantiator;
            _heroConfig = heroConfig;
            _heroProvider = heroProvider;
        }

        public async UniTask WarmUpAsync() => 
            _heroPrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Hero);

        public Hero Create()
        {
            ValidateWarmUpping().Forget();
            
            Hero hero = _instantiator.InstantiatePrefabForComponent<Hero>(_heroPrefab,
                _heroConfig.SpawnPoint,
                Quaternion.identity,
                null);

            Mover mover = new Mover(_heroConfig.MoveSpeed, hero.Transform, hero.Rigidbody2D);
            HeroAnimator heroAnimator = new(hero.Animator);
            
            hero.Construct(mover, heroAnimator);
            hero.Initialize();
    
            _heroProvider.SetHero(hero);
            return hero;
        }
        
        private async UniTaskVoid ValidateWarmUpping()
        {
            if (_heroPrefab == null)
            {
                Debug.LogError($"{nameof(HeroFactory)} is not warmed up. Call {nameof(WarmUpAsync)} before {nameof(Create)}.");
                await WarmUpAsync();
            }
        }
    }
}