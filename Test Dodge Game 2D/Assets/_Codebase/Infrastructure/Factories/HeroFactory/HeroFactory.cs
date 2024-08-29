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
            await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Hero);

        public async UniTask<Hero> CreateAsync()
        {
            GameObject heroPrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Hero);
            
            Hero hero = _instantiator.InstantiatePrefabForComponent<Hero>(heroPrefab,
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
    }
}