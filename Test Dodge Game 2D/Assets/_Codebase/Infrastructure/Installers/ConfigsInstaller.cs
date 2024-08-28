using _Codebase.StaticData;
using UnityEngine;
using Zenject;

namespace _Codebase.Infrastructure.Installers
{
    [CreateAssetMenu(fileName = "ConfigsInstaller", menuName = "Installers/ConfigsInstaller")]
    public class ConfigsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private ScenesAddresses _scenesAddresses; 

        public override void InstallBindings()
        {
            Container.Bind<ScenesAddresses>().FromInstance(_scenesAddresses).AsSingle();
        }
    }
}