using _Codebase.Gameplay.Projectiles;
using _Codebase.Infrastructure.Services.AddressablesLoader;
using _Codebase.StaticData;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Codebase.Infrastructure.Factories.ProjectileFactory
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly IAddressablesLoader _addressablesLoader;
        private readonly PrefabAddresses _prefabAddresses;
        private readonly IInstantiator _instantiator;
        private readonly ProjectileConfig _projectileConfig;
        
        private GameObject _projectilePrefab;

        public ProjectileFactory(IAddressablesLoader addressablesLoader,
            PrefabAddresses prefabAddresses,
            IInstantiator instantiator,
            ProjectileConfig projectileConfig)
        {
            _addressablesLoader = addressablesLoader;
            _prefabAddresses = prefabAddresses;
            _instantiator = instantiator;
            _projectileConfig = projectileConfig;
        }

        public async UniTask WarmUpAsync() => 
            _projectilePrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Projectile);

        public Projectile Create(Vector3 position)
        {
            ValidateWarmUpping().Forget();
            
            Projectile projectile = _instantiator.InstantiatePrefabForComponent<Projectile>(_projectilePrefab,
                position,
                Quaternion.identity,
                null);
            
            projectile.Construct(_projectileConfig.MoveSpeed);

            return projectile;
        }

        private async UniTaskVoid ValidateWarmUpping()
        {
            if (_projectilePrefab == null)
            {
                Debug.LogError($"{nameof(ProjectileFactory)} is not warmed up. Call {nameof(WarmUpAsync)} before {nameof(Create)}.");
                await WarmUpAsync();
            }
        }
    }
}