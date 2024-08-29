using UnityEngine;

namespace _Codebase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Configs/ProjectileSpawner", fileName = "ProjectileSpawnerConfig")]
    public class ProjectileSpawnerConfig : ScriptableObject
    {
        [field: SerializeField] public float SpawnIntervalInSeconds { get; private set; }
        [field: SerializeField] public float ScreenBorderSpawnMargin { get; private set; }
        [field: SerializeField] public int InitialPoolSize { get; private set; }
    }
}