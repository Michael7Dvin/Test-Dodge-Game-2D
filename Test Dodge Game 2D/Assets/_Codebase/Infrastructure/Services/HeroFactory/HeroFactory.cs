using _Codebase.Gameplay.Hero;
using _Codebase.Infrastructure.Services.AddressablesLoader;
using _Codebase.StaticData;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Codebase.Infrastructure.Services.HeroFactory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IAddressablesLoader _addressablesLoader;
        private readonly PrefabAddresses _prefabAddresses;
        private readonly IInstantiator _instantiator;
        private readonly HeroConfig _heroConfig;

        public HeroFactory(IAddressablesLoader addressablesLoader,
            PrefabAddresses prefabAddresses,
            IInstantiator instantiator,
            HeroConfig heroConfig)
        {
            _addressablesLoader = addressablesLoader;
            _prefabAddresses = prefabAddresses;
            _instantiator = instantiator;
            _heroConfig = heroConfig;
        }

        public async UniTask WarmUpAsync() => 
            await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Hero);

        public async UniTask<Hero> CreateAsync()
        {
            GameObject heroPrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Hero);
            
            Hero hero = _instantiator.InstantiatePrefabForComponent<Hero>(heroPrefab,
                _heroConfig.SpawnPoint,
                Quaternion.identity,
                null);
            
            hero.Mover.Construct(_heroConfig.MoveSpeed);

            return hero;
        }
    }
}