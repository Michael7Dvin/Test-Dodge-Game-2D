using _Codebase.Gameplay.Projectiles;
using _Codebase.Infrastructure.Factories.ProjectileFactory;
using _Codebase.StaticData;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Codebase.Gameplay.Services.ProjectileSpawner
{
    public class ProjectileSpawner : IProjectileSpawner
    {
        private readonly IProjectileFactory _projectileFactory;
        private readonly ProjectileSpawnerConfig _config;
        
        private Camera _camera;
        
        private async UniTaskVoid Spawn()
        {
            Vector2 spawnPosition = GetRandomPointOutsideScreen();
            
            Projectile projectile = await _projectileFactory.CreateAsync(spawnPosition);
        }

        private Vector2 GetRandomPointOutsideScreen()
        {
            Vector2 screenBottomLeft = _camera.ScreenToWorldPoint(new Vector2(0, 0));
            Vector2 screenTopRight = _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            float borderMargin = _config.ScreenBorderSpawnMargin;
            
            float minX = screenBottomLeft.x - borderMargin;
            float maxX = screenTopRight.x + borderMargin;
            float x = Random.Range(minX, maxX);
            
            float y = screenTopRight.y + borderMargin;
            
            return new Vector2(x, y);
        }
    }

    public interface IProjectileSpawner
    {
    }
}