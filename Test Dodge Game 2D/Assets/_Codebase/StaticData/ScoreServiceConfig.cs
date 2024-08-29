using UnityEngine;

namespace _Codebase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Configs/ScoreService", fileName = "ScoreServiceConfig")]
    public class ScoreServiceConfig : ScriptableObject
    {
        [field: SerializeField] public int ScoreAccrualIntervalInSeconds { get; private set; }
        [field: SerializeField] public int ScorePerSecond { get; private set; }
    }
}