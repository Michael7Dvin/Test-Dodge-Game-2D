using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Codebase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Addresses/Prefabs", fileName = "PrefabAddresses")]
    public class PrefabAddresses : ScriptableObject
    {
        [field: SerializeField] public AssetReferenceGameObject Hero { get; private set; }
        [field: SerializeField] public AssetReferenceGameObject Projectile { get; private set; }
        [field: SerializeField] public AssetReferenceGameObject Camera { get; private set; }
        
        [field: SerializeField] public AssetReferenceGameObject Canvas { get; private set; }
        [field: SerializeField] public AssetReferenceGameObject EventSystem { get; private set; }
        [field: SerializeField] public AssetReferenceGameObject ScoreCounter { get; private set; }
     
        [field: SerializeField] public AssetReferenceGameObject GameOverWindowViewPrefab { get; private set; }
    }
}