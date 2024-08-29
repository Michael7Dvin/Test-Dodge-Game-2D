using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Codebase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Addresses/Prefabs", fileName = "PrefabAddresses")]
    public class PrefabAddresses : ScriptableObject
    {
        [field: SerializeField] public AssetReferenceGameObject Hero { get; private set; }
    }
}