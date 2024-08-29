using _Codebase.Gameplay.Projectiles;
using _Codebase.Infrastructure.Services.AddressablesLoader;
using _Codebase.StaticData;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Codebase.Infrastructure.Services.ProjectileFactory
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly IAddressablesLoader _addressablesLoader;
        private readonly PrefabAddresses _prefabAddresses;
        private readonly IInstantiator _instantiator;
        private readonly ProjectileConfig _projectileConfig;

        public async UniTask WarmUpAsync() => 
            await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Projectile);

        public async UniTask<Projectile> CreateAsync(Vector3 position)
        {
            GameObject projectilePrefab = await _addressablesLoader.LoadGameObjectAsync(_prefabAddresses.Hero);
            
            Projectile projectile = _instantiator.InstantiatePrefabForComponent<Projectile>(projectilePrefab,
                position,
                Quaternion.identity,
                null);
            
            projectile.Construct(_projectileConfig.MoveSpeed);

            return projectile;
        }
    }
}