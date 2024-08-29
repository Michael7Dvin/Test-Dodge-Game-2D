using System.Collections.Generic;
using _Codebase.Gameplay.Projectiles;
using _Codebase.Infrastructure.Factories.ProjectileFactory;
using _Codebase.StaticData;
using UnityEngine;

namespace _Codebase.Infrastructure.Services.ProjectilePool
{
    public class ProjectilePool : IProjectilePool
    {
        private readonly IProjectileFactory _projectileFactory;
        private readonly ProjectileSpawnerConfig _projectileSpawnerConfig;

        private readonly Queue<Projectile> _projectilePool = new();

        public ProjectilePool(IProjectileFactory projectileFactory, ProjectileSpawnerConfig projectileSpawnerConfig)
        {
            _projectileFactory = projectileFactory;
            _projectileSpawnerConfig = projectileSpawnerConfig;
        }
        
        public void Initialize()
        {
            for (int i = 0; i < _projectileSpawnerConfig.InitialPoolSize; i++)
            {
                Projectile projectile = Create(Vector3.zero);
                projectile.gameObject.SetActive(false);
                _projectilePool.Enqueue(projectile);
            }
        }

        public Projectile Get(Vector3 position)
        {
            if (_projectilePool.Count > 0)
            {
                Projectile projectile = _projectilePool.Dequeue();
                projectile.transform.position = position;
                projectile.gameObject.SetActive(true);
                return projectile;
            }

            return Create(position);
        }

        public void Return(Projectile projectile)
        {
            projectile.gameObject.SetActive(false);
            _projectilePool.Enqueue(projectile);
        }

        private Projectile Create(Vector3 position)
        {
            Projectile projectile = _projectileFactory.Create(position);
            projectile.gameObject.SetActive(true);
            return projectile;
        }
    }
}