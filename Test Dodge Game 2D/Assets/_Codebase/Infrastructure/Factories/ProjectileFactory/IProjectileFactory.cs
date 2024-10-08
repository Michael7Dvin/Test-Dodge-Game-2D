using _Codebase.Gameplay.Projectiles;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Codebase.Infrastructure.Factories.ProjectileFactory
{
    public interface IProjectileFactory
    {
        UniTask WarmUpAsync();
        Projectile Create(Vector3 position);
    }
}