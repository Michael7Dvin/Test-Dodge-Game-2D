using UnityEngine;

namespace _Codebase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Configs/Projectile", fileName = "ProjectileConfig")]
    public class ProjectileConfig : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
    }
}