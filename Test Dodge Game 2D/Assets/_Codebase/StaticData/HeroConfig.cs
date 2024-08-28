using UnityEngine;

namespace _Codebase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Configs/Hero", fileName = "HeroConfig")]
    public class HeroConfig : ScriptableObject
    {
        [field: SerializeField] public Vector3 SpawnPoint { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
    }
}