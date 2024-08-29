using _Codebase.Gameplay.Projectiles;
using UnityEngine;

namespace _Codebase.Infrastructure.Services.ProjectilePool
{
    public interface IProjectilePool
    {
        void Initialize();
        Projectile Get(Vector3 position);
        void Return(Projectile projectile);
    }
}