using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Codebase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Addresses/ScenesAddresses", fileName = "ScenesAddresses")]
    public class ScenesAddresses : ScriptableObject
    {
        [field: SerializeField] public AssetReference Forest { get; private set; }
    }
}