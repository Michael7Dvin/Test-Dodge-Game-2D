using _Codebase.StaticData;
using UnityEngine;
using Zenject;

namespace _Codebase.Infrastructure.Installers
{
    [CreateAssetMenu(fileName = "ConfigsInstaller", menuName = "Installers/ConfigsInstaller")]
    public class ConfigsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private ScenesAddresses _scenesAddresses; 
        [SerializeField] private PrefabAddresses _prefabAddresses;
        
        [SerializeField] private HeroConfig _heroConfig; 
        [SerializeField] private ProjectileConfig _projectileConfig; 

        public override void InstallBindings()
        {
            Container.Bind<ScenesAddresses>().FromInstance(_scenesAddresses).AsSingle();
            Container.Bind<PrefabAddresses>().FromInstance(_prefabAddresses).AsSingle();
        
            Container.Bind<HeroConfig>().FromInstance(_heroConfig).AsSingle();
            Container.Bind<ProjectileConfig>().FromInstance(_projectileConfig).AsSingle();
        }
    }
}