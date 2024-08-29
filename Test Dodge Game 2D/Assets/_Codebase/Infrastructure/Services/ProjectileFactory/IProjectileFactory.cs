using _Codebase.Gameplay.Projectiles;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Codebase.Infrastructure.Services.ProjectileFactory
{
    public interface IProjectileFactory
    {
        UniTask WarmUpAsync();
        UniTask<Projectile> CreateAsync(Vector3 position);
    }
}