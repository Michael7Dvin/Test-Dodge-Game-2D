using System;
using _Codebase.Gameplay.Projectiles;
using _Codebase.Infrastructure.Factories.ProjectileFactory;
using _Codebase.Infrastructure.Providers.CameraProvider;
using _Codebase.StaticData;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Codebase.Gameplay.Services.ProjectileSpawner
{
    public class ProjectileSpawner : IProjectileSpawner, IDisposable
    {
        private readonly IProjectileFactory _projectileFactory;
        private readonly ICameraProvider _cameraProvider; 
        private readonly ProjectileSpawnerConfig _config;
        
        private readonly CompositeDisposable _compositeDisposable = new();

        public ProjectileSpawner(IProjectileFactory projectileFactory,
            ICameraProvider cameraProvider,
            ProjectileSpawnerConfig config)
        {
            _projectileFactory = projectileFactory;
            _cameraProvider = cameraProvider;
            _config = config;
        }

        public void Enable()
        {
            Observable.Interval(TimeSpan.FromSeconds(_config.SpawnIntervalInSeconds))
                .Subscribe(_ => Spawn())
                .AddTo(_compositeDisposable);
        }

        public void Disable() => 
            _compositeDisposable.Clear();

        private void Spawn()
        {
            Vector2 spawnPosition = GetRandomPointOutsideScreen();
            Projectile projectile = _projectileFactory.Create(spawnPosition);
        }

        private Vector2 GetRandomPointOutsideScreen()
        {
            Vector2 screenBottomLeft = _cameraProvider.Camera.ScreenToWorldPoint(new Vector2(0, 0));
            Vector2 screenTopRight = _cameraProvider.Camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            float borderMargin = _config.ScreenBorderSpawnMargin;
            
            float minX = screenBottomLeft.x - borderMargin;
            float maxX = screenTopRight.x + borderMargin;
            float x = Random.Range(minX, maxX);
            
            float y = screenTopRight.y + borderMargin;
            
            return new Vector2(x, y);
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}